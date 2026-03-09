# 3D ASMR Stress Relief Game

**A final-year project exploring how satisfying, ASMR-style interactions in a 3D game can help reduce stress, anxiety, and low mood.**

[![Unity](https://img.shields.io/badge/Unity-2019%2B-000?logo=unity)](https://unity.com)
[![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## [Play Now in Your Browser](https://zayansalman.github.io/3D_ASMR_Slice/)

> No install needed — click the link above to play the web version. The browser build is a faithful JavaScript/Three.js port of the original C# Unity scripts in `Scripts/`. Every physics formula, variable name, and constant is preserved from the dissertation code, with inline comments referencing the original C# source files and line numbers. See [`web-build/index.html`](web-build/index.html) for the port.

### Dissertation evidence

| Evidence | Link |
|----------|------|
| **Playable game** | [https://zayansalman.github.io/3D_ASMR_Slice/](https://zayansalman.github.io/3D_ASMR_Slice/) |
| **Original C# implementation** | [Scripts/](Scripts/) (MeshDeformer, Jelly, Slicer, TouchControl2, chopSound, CubeSphere, etc.) |
| **Web port (faithful translation)** | [web-build/index.html](web-build/index.html) — same algorithms and constants, with inline references to C# source lines |

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
| **30 levels across 3 worlds** | Slice (cut vegetables), Squish (stress-ball deformation), Jelly (wobble physics). Escalating difficulty with time pressure. |
| **Scoring & combos** | Rapid actions within 1.5s build a combo multiplier (x2, x3, x4…). Time bonuses on timed levels. |
| **Star ratings** | 1–3 stars per level based on score. Collect stars to unlock cosmetics. |
| **Unlockable knives** | Classic, Cleaver (★10), Katana (★25), Laser (★45) — each with unique geometry and materials. |
| **Background themes** | Midnight, Deep Space (★15), Sunset (★30), Ocean (★50). |
| **Slice onions, garlic, carrots, watermelon, cucumber** | Objects split with physics; chop sounds play on slice. |
| **Deformable surfaces** | Tap or drag on stress balls; they dent and spring back. |
| **Jelly wobble** | Squishy jelly cubes that jiggle and settle on poke. |
| **Touch controls** | One finger to interact, second finger to rotate (slice mode). Built for phones/tablets. |
| **Juice** | Screen shake, haptic feedback, combo float text, slow-motion on level completion, particle bursts scaled to combo. |

**Best experience:** Touch screen + headphones (play on your phone for the full effect).

### Monetization roadmap

This codebase is structured for mobile wrapping via [Capacitor](https://capacitorjs.com/). Next steps:

1. `npm init` + Capacitor setup to wrap as iOS/Android app
2. [AdMob](https://admob.google.com/) interstitial ads between levels (ad placement div already wired)
3. App Store / Google Play submission with screenshots and metadata

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

4. **Play in the browser**
   - The game is live at **https://zayansalman.github.io/3D_ASMR_Slice/**
   - No install needed — works on desktop and mobile browsers
   - This is a faithful Three.js port of the C# scripts (same physics, same constants)

5. **On a touch device**
   - Build to Android/iOS from **File → Build Settings**, or use [Unity Remote](https://docs.unity3d.com/Manual/UnityRemote5.html) for quick testing

For detailed setup, build options (WebGL, mobile), CI-based WebGL deployment, and troubleshooting, see **[Building & running](docs/BUILD_AND_RUN.md)**.

---

## Project structure

```
3D_ASMR_Slice/
├── Audio/          # ASMR / chop sound clips
├── PreFab/         # Prefabs (knife, sliceables, deformable objects)
├── Scripts/        # All game logic (slicing, touch, deformation, procedural meshes)
├── web-build/      # Browser port (Three.js) — faithful translation of the C# scripts
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
