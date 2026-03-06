# Building and running the 3D ASMR Stress Relief Game

This guide covers opening the project in Unity, playing in the editor, and building for **Web (WebGL)**, **Android**, and **iOS** so the game can be run (or shared) on different platforms.

---

## Prerequisites

- **Unity Hub** — [Download](https://unity.com/download)
- **Unity 2019.4 LTS or newer** (2020 LTS or 2021 LTS are good choices)
  - For **Android/iOS**: install the corresponding build support modules in Unity Hub.
  - For **WebGL**: install the WebGL Build Support module.
- **Git** (optional) — for cloning the repo.

---

## 1. Open the project in Unity

1. Clone or download the repo:
   ```bash
   git clone https://github.com/YOUR_USERNAME/3D_ASMR_Slice.git
   cd 3D_ASMR_Slice
   ```
2. In **Unity Hub**: **Add** → select the `3D_ASMR_Slice` folder → **Add Project**.
3. Open the project. Unity will import assets and compile scripts (first time may take a few minutes).

---

## 2. Run in the editor

1. In the **Project** window, locate your main scene (e.g. under `Assets/Scenes` or similar).
2. Double-click the scene to open it.
3. Press **Play** in the editor.

**If you don’t have a scene yet:**

- Create a new scene: **File → New Scene**.
- Add a plane or ground, your knife prefab (from `PreFab`), and sliceable/deformable prefabs.
- Assign the scripts (Slicer, TouchControl2, chopSound, MeshDeformer, etc.) to the appropriate GameObjects and wire up references in the Inspector.
- Save the scene (e.g. `MainScene.unity`).

**Testing touch on PC:**

- Use **Unity Remote** ([Android](https://docs.unity3d.com/Manual/UnityRemote5.html)) so your phone’s touch input controls the game in the editor.
- Or temporarily map keyboard/ mouse to the same axes as the knife for testing.

---

## 3. Build for Web (WebGL) — “runnable in the browser”

This lets anyone with a link play in the browser (great for portfolios and sharing).

1. **File → Build Settings**.
2. Select **WebGL** in the Platform list → **Switch Platform** (if needed).
3. **Player Settings** (optional):
   - **Resolution and Presentation**: default template is fine; adjust fullscreen if you like.
   - **Publishing Settings**: enable **Compression** (e.g. Gzip) to reduce load time.
4. **Build** (or **Build And Run**):
   - Choose an empty folder, e.g. `Builds/WebGL`.
   - Unity will produce an `index.html` and a `Build` folder (and related files).

**Hosting:**

- **GitHub Pages:** Push the contents of the WebGL build folder to a `gh-pages` branch or to `docs/` in the repo, then enable GitHub Pages in the repo settings.
- **itch.io:** Create a project, upload the WebGL build as a zip (or drag the folder), set “This file will be played in the browser” and choose the correct index.

**Note:** WebGL has limited touch support depending on the browser; for the best “touch a carpet” / slice experience, mobile builds (Android/iOS) are ideal.

---

## 4. Build for Android

1. **File → Build Settings** → select **Android** → **Switch Platform**.
2. **Player Settings → Android**:
   - Set **Company Name** and **Product Name**.
   - Set **Minimum API Level** (e.g. 24) and **Target API Level** as required.
   - Under **Other Settings**, set **Package Name** (e.g. `com.yourname.asmrslice`).
3. Connect a device (USB debugging on) or use an emulator.
4. **Build And Run** (or **Build** to produce an APK).

Install the APK on your phone to play with real touch and headphones.

---

## 5. Build for iOS

1. **File → Build Settings** → select **iOS** → **Switch Platform**.
2. **Player Settings → iOS**:
   - Set **Company Name**, **Product Name**, **Bundle Identifier**.
   - Configure signing and capabilities if you plan to distribute.
3. **Build** to generate an Xcode project.
4. Open the generated project in **Xcode**, select your device/simulator, and run.

---

## 6. Dependencies in this repo

- **EzySlice** — used in `Slicer.cs`. Ensure the EzySlice plugin is present under `Assets` (e.g. `Assets/Plugins/EzySlice` or as a package). If the project was exported without the plugin, re-import it from the [EzySlice repository](https://github.com/DavidArayan/ezy-slice).
- **Custom shader** — `Slicer.cs` references `Custom/BzKovSoft/RollProgressed` for the sand effect. If that shader is missing, the sand slice will fall back to the default material or you can assign another shader in the Inspector.

---

## 7. Troubleshooting

| Issue | What to try |
|-------|-------------|
| Scene is empty or missing | Create a new scene and add prefabs from `PreFab`; attach scripts and set references. |
| “EzySlice” not found | Add the EzySlice package/plugin to the project (see Dependencies above). |
| No sound on slice | Ensure the GameObject with `chopSound` has an `AudioSource` and an assigned clip; object tags must be `onion` or `garlic` (or extend `chopSound` for more tags). |
| Touch not moving knife | Confirm `TouchControl2` is on the knife GameObject and the scene is receiving touch (e.g. test on device or with Unity Remote). |
| WebGL build fails | Check that no unsupported APIs are used; simplify or strip optional features for WebGL. |

For script-level details and how systems connect, see [Architecture & scripts](ARCHITECTURE.md).
