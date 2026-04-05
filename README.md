# Life Reaper

一个受经典 WannaCry 勒索软件界面启发的 Windows Forms 应用程序，重新演绎为"续命"主题的趣味桌面程序。

## 功能特性

- 复古勒索软件风格界面设计
- 59 分 59 秒倒计时器，实时显示
- 每 59 秒自动放大字体强调效果
- 自定义标题栏（最小化、关闭按钮）
- 支持拖拽移动窗口
- 始终置顶显示
- 全中文界面

## 环境要求

- .NET 10.0
- Windows 操作系统

## 快速开始

### 前置条件

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)

### 构建项目

```bash
dotnet build
```

### 运行程序

```bash
dotnet run
```

### 发布便携版

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishReadyToRun=true --output publish
```

发布后的 `publish/Life Reaper.exe` 可直接运行，无需安装 .NET 运行时。

### 构建安装包

1. 安装 [Inno Setup 6](https://jrsoftware.org/isdl.php)
2. 双击运行 `build-installer.bat`
3. 安装包将生成在 `installer/output/LifeReaper-Setup.exe`

## 项目结构

```
Life Reaper/
├── Form1.cs                   # 主窗体逻辑
├── Form1.Designer.cs          # 窗体界面设计
├── Program.cs                 # 应用程序入口
├── Life Reaper.csproj         # 项目配置文件
├── Life Reaper.slnx           # 解决方案文件
├── build-installer.bat        # 一键构建安装包脚本
└── installer/
    └── setup.iss              # Inno Setup 安装包脚本
```

## 开源许可证

本项目采用 MIT 许可证 - 详见 [LICENSE](LICENSE) 文件。

## 免责声明

本项目仅用于**学习和娱乐目的**，不包含任何恶意功能。不会加密或损坏任何文件。
