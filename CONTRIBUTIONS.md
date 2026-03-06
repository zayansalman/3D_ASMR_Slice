# Contributions and Value

This document summarises **what was built for this project** and **what value each part adds**—for assessors, recruiters, or anyone reviewing the repo.

**Author:** Zayan Khan  
**Project:** 3D ASMR Stress Relief Game (Final Year, Computer Science)

---

## 1. Project vision and rationale

**Contribution:** Defined the project focus and research angle: using ideas from **satisfying videos** and **ASMR** to design an interactive 3D game that could help reduce **stress, anxiety, and potentially depression** over time.

**Value:**  
- Turns a “fun game” into a **thesis-backed concept** with a clear hypothesis (satisfying/ASMR → stress relief → interactive 3D as a delivery mechanism).  
- Gives the project a **research-oriented narrative** suitable for final-year reports and portfolios.  
- Explains *why* the mechanics (slicing, touch, deformation, sound) were chosen—not just *what* was built.

---

## 2. Core gameplay systems

### 2.1 Slicing (Slicer, SliceListener)

**Contribution:**  
- Integrated **EzySlice** with Unity: trigger-based detection (`SliceListener`), `Physics.OverlapBox` to find sliceable objects, and per-type handling (onion, garlic, sand).  
- Assigned materials and physics (MeshCollider, Rigidbody) to upper/lower hulls so slices behave realistically.  
- Special handling for **sand** (custom BzKovSoft-style shader and rolling parameters) so cut sand looks and feels distinct.

**Value:**  
- Delivers the main “satisfying” mechanic: **repetitive, controlled cutting** with immediate visual and physical feedback.  
- Shows ability to **integrate a third-party plugin** (EzySlice) and extend it with game-specific logic (tags, materials, layers).  
- Demonstrates **physics and mesh workflow** (colliders, rigidbodies, layer masks).

### 2.2 Touch controls (TouchControl2)

**Contribution:**  
- Implemented **two-finger touch** for the knife: one finger to move in X/Y, second finger to rotate.  
- Tuned with configurable speed modifiers so the game feels responsive on phones/tablets.

**Value:**  
- Makes the game **mobile-first** and **tactile**, matching how many people consume ASMR/satisfying content.  
- Demonstrates **Unity input handling** and **multi-touch** design.

### 2.3 ASMR audio (chopSound)

**Contribution:**  
- Wired **AudioSource** to trigger on collision with onion/garlic (and optional extension to other tags).  
- Used a short delay so the chop sound lines up with the slice.

**Value:**  
- Adds **auditory ASMR-style feedback** and reinforces the satisfying feel of cutting.  
- Shows simple **event-driven audio** design (trigger → play).

### 2.4 Deformable surfaces (MeshDeformer, MeshDeformerInput)

**Contribution:**  
- Implemented **spring–mass mesh deformation**: vertices are displaced by a force, then spring back with configurable spring force and damping.  
- Applied **distance attenuation** so only nearby vertices move (localised dents).  
- Wired **mouse input** (raycast from camera) to apply force at the hit point for PC/editor testing.

**Value:**  
- Delivers a **stress-ball style** interaction: poke something soft and watch it recover.  
- Demonstrates **mesh manipulation**, **basic physics modelling** (spring–damper), and **camera raycasting**.

### 2.5 Jelly wobble (Jelly)

**Contribution:**  
- Built a **per-vertex “jelly” simulation** so meshes jiggle and settle.  
- Varied intensity by height so the object feels more organic.

**Value:**  
- Adds a **second soft-body style** interaction and increases variety for stress relief.  
- Shows **custom vertex-level animation** and understanding of mesh data.

---

## 3. Procedural content and tools

### 3.1 Procedural meshes (RoundedCube, CubeSphere, Grid)

**Contribution:**  
- **RoundedCube:** Generated rounded-cube geometry and combined BoxCollider and CapsuleCollider for better collision.  
- **CubeSphere:** Implemented cube-to-sphere vertex mapping (Catlike Coding–style) and generated vertices/triangles/colliders.  
- **Grid:** Generated a 2D grid mesh (vertices and triangles) as a base for stress-ball or surface effects.

**Value:**  
- Provides **sliceable and squishable** content without relying only on art assets.  
- Demonstrates **3D math**, **mesh topology**, and **procedural generation**—strong for a CS final-year project.

### 3.2 Helpers and editor (Control, CircleGizmo, LerpTest)

**Contribution:**  
- **Control:** Script to move a “shape” and “cutter” along axes (for UI or automated testing).  
- **CircleGizmo:** Editor gizmo to visualise cube–sphere mapping.  
- **LerpTest:** Simple motion test (e.g. for debugging or animation).

**Value:**  
- Supports **iteration and debugging** and shows awareness of **editor tooling** and **reusable control logic**.

---

## 4. Testing

**Contribution:**  
- Introduced **Unity Test Framework** (Edit Mode and Play Mode).  
- Added **testable helpers** (e.g. `Grid.GetExpectedVertexCount`, `Grid.GetExpectedTriangleCount`, `MeshDeformer.SpringStep`, `CubeSphere.GetExpectedVertexCount`) and **unit tests** for:  
  - Grid vertex and triangle counts.  
  - MeshDeformer spring–damping behaviour.  
  - CubeSphere vertex count formula.  
- Documented how to run tests (Test Runner window).

**Value:**  
- Ensures **procedural mesh math** and **spring physics** stay correct as the project evolves.  
- Shows **test-driven thinking** and **maintainability**—useful for portfolios and further development.

---

## 5. Documentation and repo quality

**Contribution:**  
- **README:** Project summary, rationale, features, tech stack, quick start, structure, and links to docs.  
- **docs/PROJECT_REPORT.md:** Report-style document (aims, background, design, implementation, limitations, future work).  
- **docs/BUILD_AND_RUN.md:** How to open in Unity, run in editor, and build for WebGL, Android, and iOS.  
- **docs/ARCHITECTURE.md:** Folder layout and **script-by-script** description of responsibilities and data flow.  
- **CONTRIBUTIONS.md:** This file—contributions and value.  
- **LICENSE:** MIT.  
- **Script headers:** Short comments on main scripts so the codebase is easy to navigate.

**Value:**  
- Makes the repo **presentable** and **easy to run** for assessors, recruiters, or open-source readers.  
- Separates **“what I built”** (CONTRIBUTIONS) from **“how it works”** (ARCHITECTURE) and **“why and how to run it”** (README, REPORT, BUILD_AND_RUN).

---

## 6. Summary table

| Area | Contribution | Value |
|------|--------------|--------|
| **Vision** | Stress/ASMR/satisfying rationale and game hypothesis | Research angle and report-ready narrative |
| **Slicing** | EzySlice integration, tags, materials, sand shader | Core satisfying mechanic, plugin integration, physics |
| **Touch** | Two-finger knife control | Mobile-first, tactile play |
| **Audio** | Trigger-based chop sounds | ASMR-style feedback |
| **Deformation** | Spring–mass mesh deformer + mouse input | Stress-ball interaction, mesh + physics |
| **Jelly** | Per-vertex wobble | Second soft-body feel, vertex animation |
| **Procedural** | RoundedCube, CubeSphere, Grid | Sliceable/squishable content, 3D math and generation |
| **Testing** | Helpers + Edit/Play Mode tests | Correctness and maintainability |
| **Docs** | README, report, build guide, architecture, CONTRIBUTIONS | Presentable, runnable, understandable repo |

---

## 7. How to run the tests

1. Open the project in **Unity**.  
2. **Window → General → Test Runner** (or **Window → Testing → Test Runner** depending on version).  
3. Open the **EditMode** tab → **Run All** for Grid, MeshDeformer, and CubeSphere tests.  
4. Open the **PlayMode** tab → **Run All** for the Slicer tag test (optional).

If the Test Runner is not available, install the **Test Framework** package via **Window → Package Manager** (Unity 2019+).
