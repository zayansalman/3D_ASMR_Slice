# Touch / swipe input prototype

An early Unity test (November 2020) used to try out touch input on a phone before the game existed. `Swipe` detects taps and four-direction swipes from either mouse or touch, and `SwipeTest` moves a cube in response.

It was an early step toward the touch-first controls in `Scripts/TouchControl2.cs`, where one finger moves the knife and a second finger rotates it.

The folder name ends in `~` so Unity ignores it when the repo is opened as a project. To try it, copy both scripts into a Unity project, add `Swipe` and `SwipeTest` to an empty object and a cube, and assign the references.
