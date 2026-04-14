# AGENTS.md

## Build & Run
- Target: .NET Framework 3.5, x86 architecture
- Build command: `msbuild "Life Reaper.csproj" /p:Configuration=Release /p:TargetFrameworkVersion=v3.5`
- Output: `bin\Release\LifeReaper.exe`

## CI/CD
- GitHub Actions auto-builds on push to main/master
- Tag format `v*` triggers GitHub Release with ZIP artifact

## Project Structure
- Entry point: `Program.cs`
- Main UI: `Form1.cs`, `Form1.Designer.cs`
- Additional forms: `CustomMessageBox.cs`, `WarningForm.cs`

## Important Notes
- Requires Windows and .NET Framework 3.5
- Portable ZIP release includes EXE, PDB, config files, README, LICENSE