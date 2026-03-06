# Architecture and scripts

Overview of the 3D ASMR Stress Relief Game codebase: folder layout and what each script does.

---

## Folder structure

```
3D_ASMR_Slice/
├── Audio/              # Sound clips (chop, ASMR-style sounds)
├── PreFab/             # Unity prefabs (knife, sliceables, deformable objects)
├── Scripts/            # All C# game logic
│   └── Stress Ball/    # Grid and related stress-ball mesh scripts
├── Tests/              # Unity Test Framework (Edit Mode + Play Mode)
│   ├── EditMode/      # Grid, MeshDeformer, CubeSphere unit tests
│   └── PlayMode/      # Slicer tag / integration-style tests
├── docs/               # Project report, build guide, this file
├── README.md
├── CONTRIBUTIONS.md    # Author contributions and value
└── LICENSE
```

---

## Scripts (by responsibility)

### Slicing

| Script | Purpose |
|--------|---------|
| **Slicer.cs** | Core slicing logic. Uses a trigger flag (`isTouched`); when set, runs `Physics.OverlapBox` to find sliceable objects (layer mask). For each object tagged `onion`, `garlic`, or `sand`, calls EzySlice to create upper/lower hulls, assigns materials (outside + inside), adds `MeshCollider` and `Rigidbody`, and destroys the original. For `sand`, applies the BzKovSoft rolling shader and sets `_PointY` / `_PointX` for the fall effect. |
| **SliceListener.cs** | Placed on a trigger volume (e.g. knife). On `OnTriggerEnter` with a sliceable, sets `slicer.isTouched = true` so `Slicer` performs the cut on the next frame. |

### Input and control

| Script | Purpose |
|--------|---------|
| **TouchControl2.cs** | Touch controls for the knife. First finger drag: move knife in X/Y using `touch.deltaPosition` and speed modifiers. Second finger drag: rotate knife (Y rotation from delta X). |
| **Control.cs** | Utility to move a “shape” and a “cutter” along axes (`MoveShape(float x)`, `MoveCutter(float y)`). Can be driven by UI or other input. |

### Audio

| Script | Purpose |
|--------|---------|
| **chopSound.cs** | Requires `AudioSource`. On `OnTriggerEnter` with colliders tagged `onion` or `garlic`, plays the clip with a short delay (`PlayDelayed(0.1f)`). Attach to the knife or slice trigger object. |

### Deformation and soft body

| Script | Purpose |
|--------|---------|
| **MeshDeformer.cs** | Mesh deformer (spring–mass style). Stores original and displaced vertices and per-vertex velocities. `AddDeformingForce(point, force)` applies distance-attenuated force to nearby vertices. In `Update()`, integrates velocity and position with spring and damping so the mesh dents and recovers. |
| **MeshDeformerInput.cs** | Mouse input for `MeshDeformer`. On mouse down, raycasts from camera; if the hit collider has a `MeshDeformer`, computes contact point and calls `AddDeformingForce`. |
| **Jelly.cs** | Jelly-style wobble. Clones mesh into a set of “JellyVertex” nodes with position, velocity, and force. In `FixedUpdate()`, applies a per-vertex “Shake” and lerps mesh vertices toward the shaken positions. Wobble intensity can vary by height in the mesh. |

### Procedural geometry

| Script | Purpose |
|--------|---------|
| **RoundedCube.cs** | Builds a procedural rounded cube: corner/edge/face vertices pushed outward from an inner box. Multiple submeshes and a mix of `BoxCollider`s and `CapsuleCollider`s, plus `Rigidbody`. |
| **CubeSphere.cs** | Builds a cube-sphere (cube vertices warped onto a sphere). Adds `SphereCollider` and `Rigidbody`. |
| **Stress Ball/Grid.cs** | Builds a 2D grid mesh (vertices and triangles). Used as a base for stress-ball or surface meshes. |

### Editor and helpers

| Script | Purpose |
|--------|---------|
| **CircleGizmo.cs** | Editor gizmo: draws circle vs square boundary points to visualize cube-to-sphere mapping. |
| **LerpTest.cs** | Simple test: moves an object back and forth between two X positions using `Mathf.Lerp`. |

---

## Data flow (high level)

1. **Touch** → `TouchControl2` updates knife position/rotation.
2. **Knife overlaps sliceable** → `SliceListener` sets `Slicer.isTouched`.
3. **Slicer.Update()** → `OverlapBox` → EzySlice → new hulls with materials, colliders, rigidbodies; optional shader params for sand.
4. **Knife triggers onion/garlic** → `chopSound.OnTriggerEnter` → `AudioSource.PlayDelayed`.
5. **Mouse down on deformable** → `MeshDeformerInput` raycast → `MeshDeformer.AddDeformingForce`.
6. **Every frame** → `MeshDeformer` and `Jelly` update vertex positions from their spring/wobble logic.

---

## Tags and layers (used in code)

- **Tags:** `onion`, `garlic`, `sand` (sliceables); slice results may be re-tagged (e.g. `Sliceable`) for further cuts.
- **Layers:** `Slicer` uses a `sliceMask` (LayerMask) to filter which colliders can be sliced. Configure in Unity: assign objects to the chosen layer and set `sliceMask` in the Inspector.

---

## Dependencies

- **EzySlice** — `using EzySlice;` in `Slicer.cs`. Must be present under `Assets` (plugin or package).
- **Unity built-in** — `AudioSource`, `Rigidbody`, `MeshCollider`, `MeshFilter`, `Material`, `Physics.OverlapBox`, `ScreenPointToRay`, etc.
- **Custom shader** — `Shader.Find("Custom/BzKovSoft/RollProgressed")` in `Slicer.cs` for sand; optional if you replace or remove sand slicing.

For build and run steps, see [Building & running](BUILD_AND_RUN.md). For project rationale and design, see [Project report](PROJECT_REPORT.md).
