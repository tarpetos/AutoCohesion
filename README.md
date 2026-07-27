# AutoCohesion

Single-player module for Mount & Blade II: Bannerlord. It takes the micromanagement out of leading an army by automatically maintaining your army's cohesion.

## What it does

- **Automatic Refill**: If you are leading an army and its cohesion drops below 90, the mod automatically spends your influence to boost it back up.
- **Hourly Check**: The mod checks cohesion once every in-game hour. If you have enough influence, it will seamlessly purchase a cohesion boost (10 points).
- **Configurable via MCM**: You can toggle this feature on or off directly from the Mod Configuration Menu in-game.

## Release contents

The build scripts produce a self-contained module in the `dist/AutoCohesion` directory.

## Compatibility and dependencies

- Single-player only.
- Depends on the **Mod Configuration Menu (MCM)** for settings. Ensure MCM is installed and loaded before this mod.
- Safe to add to or remove from existing saves.

## Build from WSL/Linux

You must provide the path to your Bannerlord installation using the `BANNERLORD_DIR` environment variable. With Mono installed, run:

```bash
chmod +x build-linux.sh
BANNERLORD_DIR="/path/to/Mount & Blade II Bannerlord" ./build-linux.sh
```

**Important note for WSL users:** Windows restricts executing `.dll` files generated or copied from WSL environments (Mark of the Web issue). After copying the module to your game directory on Windows, you must unblock the files. Open PowerShell and run:

```powershell
Get-ChildItem -Path "C:\Your\Path\To\Mount & Blade II Bannerlord\Modules\AutoCohesion" -Recurse | Unblock-File
```

## Build from Windows

Run the PowerShell script. If your game is not in the default Steam directory, specify the `-BannerlordDir` parameter:

```powershell
.\build-windows.ps1 -BannerlordDir "\path\to\Mount & Blade II Bannerlord"
```

## Install

Copy the contents of `dist/AutoCohesion` to:

```text
Mount & Blade II Bannerlord/Modules/AutoCohesion
```

Then enable **AutoCohesion** in the Bannerlord launcher, after the official single-player modules and MCM.
