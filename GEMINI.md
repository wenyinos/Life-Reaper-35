# GEMINI.md

## Project Overview

**Life Reaper (续命)** is a fun Windows desktop application inspired by the infamous WannaCry ransomware interface. It features a themed countdown timer (starting at 9:59) with retro styling, window-shaking effects, and custom dialogs.

- **Primary Stack:** C# / .NET Framework 3.5 / Windows Forms
- **Target Platform:** Windows (x86)
- **Key Characteristics:**
  - Borderless, draggable, and "Always on Top" window.
  - Custom UI components (`CustomMessageBox`, `WarningForm`).
  - GitHub Actions for CI/CD (automated builds and releases).
  - Installer creation via Inno Setup.

## Core Components

- **`Program.cs`**: Application entry point.
- **`Form1.cs`**: Main interface logic, including the countdown timer, "shake" effect, and event handlers for the mock "payment" and "decryption" buttons.
- **`CustomMessageBox.cs`**: Implements a custom-styled message box that matches the project's aesthetic.
- **`WarningForm.cs`**: A specialized form that appears when a user tries to close the application, reinforcing the "WannaCry" theme.
- **`IMPROVEMENTS.md`**: A comprehensive roadmap for future refactoring, including resource leak fixes (Fonts/Timers), DPI scaling support, and internationalization.

## Building and Running

### Development Requirements
- .NET Framework 3.5
- Visual Studio or MSBuild
- Inno Setup 6 (optional, for building the installer)

### Build Commands
- **Compile Project:**
  ```powershell
  msbuild "Life Reaper.csproj" /p:Configuration=Release
  ```
- **Build Installer:**
  Run `build-installer.bat` from the root directory. This script performs a `dotnet publish` and then invokes the Inno Setup compiler (`ISCC.exe`).

### Running the App
- The compiled executable will be located in `bin\Release\LifeReaper.exe`.
- The portable version can be run directly from the ZIP artifact in the GitHub Releases.

## Development Conventions

- **Framework Compatibility:** Maintain compatibility with **.NET Framework 3.5** to ensure it runs on older Windows systems without requiring modern .NET runtimes.
- **UI Design:** Adhere to the retro "WannaCry" aesthetic. Most UI logic is custom-coded rather than using standard Windows borders.
- **Resource Management:** Be mindful of GDI+ resources. `IMPROVEMENTS.md` highlights existing issues with `Font` and `Timer` disposal that should be addressed in future updates.
- **Draggable Forms:** Use the `mouseOffset` pattern implemented in `Form1.cs` for custom title bar dragging logic.

## Roadmap & Maintenance

Refer to `IMPROVEMENTS.md` for a prioritized list of technical debt and feature enhancements:
1.  **Resource Leaks:** Proper disposal of `Font` and `Timer` objects.
2.  **Magic Numbers:** Moving hardcoded countdown values and UI constants to configuration or class constants.
3.  **DPI Scaling:** Improving layout responsiveness on high-DPI displays.
4.  **Persistence:** Saving window position and state.
