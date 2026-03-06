# Tests

Unity Test Framework tests for the 3D ASMR Stress Relief Game.

## Layout

- **EditMode/** — Runs in the editor without entering Play Mode.
  - `GridMeshTests.cs` — Grid vertex and triangle count formulas.
  - `MeshDeformerSpringTests.cs` — MeshDeformer spring-damper step.
  - `CubeSphereVertexCountTests.cs` — CubeSphere vertex count formula.
- **PlayMode/** — Runs in Play Mode.
  - `SlicerTagTests.cs` — Documents and guards Slicer tag contract (onion, garlic, sand).

## How to run

1. Open the project in Unity.
2. **Window → General → Test Runner** (or **Window → Testing → Test Runner**).
3. Select **EditMode** or **PlayMode** and click **Run All**.

If the Test Runner window is missing, install **Test Framework** via **Window → Package Manager**.

## Note

If your project has an **Assets** folder at the root, place this **Tests** folder inside it (**Assets/Tests**) so Unity compiles the test assembly. The asmdef references **Assembly-CSharp** (the default script assembly).
