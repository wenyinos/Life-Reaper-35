# 续命 Life Reaper 💀

一个受经典 WannaCry 界面启发的趣味桌面程序，以"续命"为主题的倒计时应用。

## ✨ 特性

- ⏰ 9分59秒倒计时器
- 🎨 复古风格界面设计
- 🖱️ 支持拖拽移动、始终置顶
- 📦 便携版 ZIP 发布

## 🚀 快速开始

### 环境要求
- .NET Framework 3.5
- Windows 系统 (x86)

### 运行程序
直接下载 Release 中的 ZIP 文件，解压后运行 `LifeReaper.exe`。

### 从源码编译
```bash
# 使用 MSBuild (需要 Visual Studio 或 .NET Framework SDK)
msbuild "Life Reaper.csproj" /p:Configuration=Release
```

## 📥 下载

前往 [Releases](https://github.com/wenyinos/Life-Reaper-35/releases) 下载最新版本:
- **便携版 ZIP** - 解压后运行 `LifeReaper.exe`

## 🔧 CI/CD

本项目使用 GitHub Actions 自动构建和发布：
- 每次推送到 main 分支都会触发自动构建
- 创建 `v*` 格式的 tag (如 `v1.0.0`) 会自动创建 GitHub Release

## 📄 许可证

MIT License - 详见 [LICENSE](LICENSE)

---

⚠️ **免责声明**: 本项目仅用于学习和娱乐目的，不包含任何恶意功能。
