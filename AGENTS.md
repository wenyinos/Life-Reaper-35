# AGENTS.md

## Build & Run
- Target: .NET Framework 3.5, x86 architecture
- Build command: `msbuild "Life Reaper.csproj" /p:Configuration=Release /p:TargetFrameworkVersion=v3.5`
- Output: `bin\Release\LifeReaper.exe`
- Solution file: `Life Reaper.slnx`

## CI/CD
- GitHub Actions auto-builds on push to `main`/`master`
- Tag format `v*` (e.g., `v1.0.0`) triggers GitHub Release with ZIP artifact

## Project Structure
- Entry point: `Program.cs`
- Main form: `Form1.cs` + `Form1.Designer.cs`
- Additional forms: `CustomMessageBox.cs`, `WarningForm.cs`

## Constraints
- Requires Windows + .NET Framework 3.5
- x86 only (WinForms app)