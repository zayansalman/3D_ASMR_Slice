# 3D ASMR Stress Relief Game

**A final-year project exploring how satisfying, ASMR-style interactions in a 3D game can help reduce stress, anxiety, and low mood.**

[![Unity](https://img.shields.io/badge/Unity-2019%2B-000?logo=unity)](https://unity.com)
[![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

---

## Why this project?

Satisfying videos and ASMR content are hugely popular—and research suggests they can ease stress and anxiety. This project asks: **what if we put those same triggers into something you can actually play?**

- **Repetition, control, and predictability** — slicing, tapping, and squishing with clear cause-and-effect
- **Multisensory feedback** — real-time physics, sounds, and tactile-style interaction (especially on touch devices)
- **A 3D game** — so you’re not just watching; you’re *doing* it, with your hands

The goal is a small, playable proof-of-concept that could support stress relief and, over time, potentially help with anxiety and low mood—backed by the ideas behind satisfying and ASMR media.

---

## What you can do in the game

| Feature | Description |
|--------|-------------|
| **Slice onions, garlic & sand** | Cut objects with a knife; they split with physics and materials. Chop sounds play on slice. |
| **Touch controls** | One finger to move the knife, second finger to rotate it. Built for phones/tablets. |
| **Deformable surfaces** | Tap or drag on soft meshes; they dent and spring back (stress-ball style). |
| **Jelly wobble** | Squishy objects that jiggle and settle. |
| **Procedural shapes** | Rounded cubes and cube-spheres generated at runtime for slicing and squishing. |

**Best experience:** Touch screen + headphones (play on your phone for the full effect).

---

## Tech stack

- **Engine:** [Unity](https://unity.com) (C#)
- **Slicing:** [EzySlice](https://github.com/DavidArayan/ezy-slice) for real-time mesh cutting
- **Interaction:** Unity `AudioSource`, `Rigidbody`, `MeshCollider`; custom spring-mass deformation and jelly simulation

---

## Quick start

### Prerequisites

- [Unity Hub](https://unity.com/download) + Unity **2019.4 LTS or newer** (or another compatible version)
- For touch gameplay: Android/iOS device or Unity Remote; for desktop: mouse (deformation only; slicing uses touch or mapped input)

### Run in the editor

1. **Clone the repo**
   ```bash
   git clone https://github.com/YOUR_USERNAME/3D_ASMR_Slice.git
   cd 3D_ASMR_Slice
   ```

2. **Open in Unity**
   - Open Unity Hub → **Add** → select the `3D_ASMR_Slice` folder
   - Open the project and wait for Unity to import assets

3. **Open a scene and play**
   - In the Project window, go to **Scenes** (or wherever your main scene is saved)
   - Double-click the main scene (e.g. slicing + deformation setup)
   - Press **Play**

4. **On a touch device**
   - Build to Android/iOS from **File → Build Settings**, or use [Unity Remote](https://docs.unity3d.com/Manual/UnityRemote5.html) for quick testing

For detailed setup, build options (WebGL, mobile), and troubleshooting, see **[Building & running](docs/BUILD_AND_RUN.md)**.

---

## Project structure

```
3D_ASMR_Slice/
├── Audio/          # ASMR / chop sound clips
├── PreFab/         # Prefabs (knife, sliceables, deformable objects)
├── Scripts/        # All game logic (slicing, touch, deformation, procedural meshes)
├── docs/           # Report, architecture, build instructions
├── README.md       # This file
└── LICENSE         # MIT
```

**Key scripts:** [Architecture & scripts](docs/ARCHITECTURE.md) — what each script does and how they fit together.

---

## Tests

The project includes **Unity Test Framework** tests (Edit Mode and Play Mode):

- **Edit Mode:** Grid vertex/triangle counts, MeshDeformer spring-damper math, CubeSphere vertex count.
- **Play Mode:** Slicer tag contract (onion/garlic/sand).

**How to run:** Open Unity → **Window → General → Test Runner** (or **Window → Testing → Test Runner**) → **EditMode** or **PlayMode** tab → **Run All**.  
If the Test Runner does not appear, install the **Test Framework** package via **Window → Package Manager**.

See [CONTRIBUTIONS.md](CONTRIBUTIONS.md) for what is covered and why tests were added.

---

## Documentation

| Document | Description |
|----------|-------------|
| [**Project report**](docs/PROJECT_REPORT.md) | Rationale, design, implementation, and reflection (report-style). |
| [**Building & running**](docs/BUILD_AND_RUN.md) | Unity setup, building for Web (WebGL), Android, iOS. |
| [**Architecture & scripts**](docs/ARCHITECTURE.md) | Codebase layout and script responsibilities. |
| [**Contributions & value**](CONTRIBUTIONS.md) | What was built, by whom, and what value each part adds. |

---

## License

This project is licensed under the **MIT License** — see [LICENSE](LICENSE).

---

## Author

**Zayan Khan** — Final year Computer Science project.

If you use this repo for learning or as a reference, a link back or credit is appreciated.
