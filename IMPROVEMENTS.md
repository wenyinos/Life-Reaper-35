# 项目改进方案

## 修复 1: Timer 资源泄漏

**问题**: `timerCountdown` 在窗口关闭时未释放。

**修复方案**: 在 `Form1.cs` 中重写 `Dispose` 方法，确保计时器被正确释放。

```csharp
// Form1.cs - 添加 Dispose 模式

public class Form1 : Form
{
    private TimeSpan timeLeft;
    private Point mouseOffset;
    private int secondsElapsed;
    private bool isEmphasized;
    private Point originalLocation;
    private bool isDisposed = false;

    // ... 现有构造函数 ...

    protected override void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                if (timerCountdown != null)
                {
                    timerCountdown.Stop();
                    timerCountdown.Dispose();
                    timerCountdown = null;
                }
            }
            isDisposed = true;
        }
        base.Dispose(disposing);
    }
}
```

---

## 修复 2: Font 资源泄漏

**问题**: 多处 `new Font(...)` 未释放。

**修复方案**: 定义静态只读字体字段，在类级别复用，组件销毁时一并释放。

```csharp
// Form1.cs 或新建 Theme.cs

public static class Theme
{
    public static readonly Font TitleFont;
    public static readonly Font HeadingFont;
    public static readonly Font BodyFont;
    public static readonly Font CountdownFont;
    public static readonly Font TimerFont;

    static Theme()
    {
        TitleFont = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        HeadingFont = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        BodyFont = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        CountdownFont = new Font("Consolas", 32F, FontStyle.Bold, GraphicsUnit.Point);
        TimerFont = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
    }

    public static void Dispose()
    {
        TitleFont.Dispose();
        HeadingFont.Dispose();
        BodyFont.Dispose();
        CountdownFont.Dispose();
        TimerFont.Dispose();
    }
}
```

```csharp
// 使用方式
lblTitle.Font = Theme.TitleFont;
lblCountdown.Font = Theme.CountdownFont;
```

**对于 CustomMessageBox 和 WarningForm 中的动态字体尺寸**:
```csharp
// 使用 using 语句创建临时字体
using (var font = new Font("Microsoft YaHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point))
{
    lblWarning.Font = font;
}
```

---

## 修复 3: 硬编码魔法数字

**问题**: 倒计时时长硬编码在构造函数中。

**修复方案**: 添加常量定义。

```csharp
// Form1.cs

public partial class Form1 : Form
{
    private const int CountdownMinutes = 9;
    private const int CountdownSeconds = 59;
    private const int EmphasisInterval = 59; // 每 59 秒强调一次
    private const int ShakeCount = 10;
    private const int ShakeDistance = 15;
    private const int ShakeDelay = 50;
    private const int ResetDelay = 1500;

    public Form1()
    {
        InitializeComponent();
        timeLeft = TimeSpan.FromMinutes(CountdownMinutes).Add(TimeSpan.FromSeconds(CountdownSeconds));
        secondsElapsed = 0;
        isEmphasized = false;
        originalLocation = Location;
        UpdateCountdownDisplay();
    }

    private void TimerCountdown_Tick(object sender, EventArgs e)
    {
        if (timeLeft.TotalSeconds > 0)
        {
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
            secondsElapsed++;
            UpdateCountdownDisplay();

            if (secondsElapsed % EmphasisInterval == 0 && !isEmphasized)
            {
                EmphasizeCountdown();
            }
        }
        else
        {
            timerCountdown.Stop();
            lblCountdown.Text = "00:00:00";
            CustomMessageBox.Show(this, "时间已到！你的生命已贡献给长者。", "拖出去续了");
        }
    }
}
```

---

## 修复 4: 添加异常处理和日志

**问题**: Timer 事件缺少异常处理。

**修复方案**: 添加 try-catch 和日志记录。

```csharp
// 新建 Logger.cs
public static class Logger
{
    private static readonly string LogPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "LifeReaper",
        "app.log");

    static Logger()
    {
        var dir = Path.GetDirectoryName(LogPath);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
    }

    public static void Log(string message, Exception ex = null)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var entry = ex != null
            ? $"[{timestamp}] ERROR: {message}\n{ex}"
            : $"[{timestamp}] INFO: {message}";
        
        File.AppendAllText(LogPath, entry + Environment.NewLine);
    }
}
```

```csharp
// Form1.cs 中的 Timer 事件处理
private void TimerCountdown_Tick(object sender, EventArgs e)
{
    try
    {
        if (timeLeft.TotalSeconds > 0)
        {
            // ... 现有逻辑 ...
        }
        else
        {
            timerCountdown.Stop();
            lblCountdown.Text = "00:00:00";
            CustomMessageBox.Show(this, "时间已到！你的生命已贡献给长者。", "拖出去续了");
        }
    }
    catch (Exception ex)
    {
        Logger.Log("TimerCountdown_Tick 执行时发生错误", ex);
        timerCountdown.Stop();
    }
}
```

---

## 修复 5: DPI 缩放支持

**问题**: 固定尺寸在非标准 DPI 下显示异常。

**修复方案**: 修改 `AutoScaleMode` 并使用 `RequestWindowsDesktop` 或百分比布局。

```csharp
// Form1.Designer.cs - 修改 Form1 初始化部分

//
// Form1
//
AutoScaleDimensions = new SizeF(9F, 20F);
AutoScaleMode = AutoScaleMode.Font;  // 改为 Font 或 Dpi
ClientSize = new Size(1003, 747);
Controls.Add(panelContent);
Controls.Add(panelTitleBar);
FormBorderStyle = FormBorderStyle.None;
Margin = new Padding(4);
Name = "Form1";
StartPosition = FormStartPosition.CenterScreen;
Text = "续命 26.08.17";
TopMost = true;

// 或使用 TableLayoutPanel / FlowLayoutPanel 实现响应式布局
```

---

## 修复 6: 窗口位置持久化

**问题**: 窗口位置重启后不保留。

**修复方案**: 使用 App.config 或 JSON 文件保存配置。

```csharp
// 新建 Settings.cs
public class AppSettings
{
    private static readonly string ConfigPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "LifeReaper",
        "settings.json");

    public int Left { get; set; }
    public int Top { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public void Load()
    {
        if (File.Exists(ConfigPath))
        {
            var json = File.ReadAllText(ConfigPath);
            var settings = JsonSerializer.Deserialize<AppSettings>(json);
            if (settings != null)
            {
                Left = settings.Left;
                Top = settings.Top;
                Width = settings.Width;
                Height = settings.Height;
            }
        }
    }

    public void Save()
    {
        var dir = Path.GetDirectoryName(ConfigPath);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        var json = JsonSerializer.Serialize(this);
        File.WriteAllText(ConfigPath, json);
    }
}
```

```csharp
// Form1.cs - 在构造函数中加载，重写 OnFormClosing 保存
public Form1()
{
    InitializeComponent();
    var settings = new AppSettings();
    settings.Load();
    
    if (settings.Width > 0 && settings.Height > 0)
    {
        StartPosition = FormStartPosition.Manual;
        Location = new Point(settings.Left, settings.Top);
        Size = new Size(settings.Width, settings.Height);
    }
    // ... 其他初始化 ...
}

protected override void OnFormClosing(FormClosingEventArgs e)
{
    var settings = new AppSettings
    {
        Left = Left,
        Top = Top,
        Width = Width,
        Height = Height
    };
    settings.Save();
    base.OnFormClosing(e);
}
```

---

## 修复 7: 提取拖拽逻辑到基类

**问题**: 三处窗体重复相同的拖拽代码。

**修复方案**: 创建 `DraggableForm` 基类。

```csharp
// 新建 DraggableForm.cs
public class DraggableForm : Form
{
    private Point mouseOffset;

    public DraggableForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterParent;
        ShowInTaskbar = false;
        TopMost = true;
    }

    protected void AttachDraggable(Panel titleBar)
    {
        titleBar.MouseDown += TitleBar_MouseDown;
    }

    protected void AttachDraggable(params Control[] controls)
    {
        foreach (var ctrl in controls)
        {
            ctrl.MouseDown += TitleBar_MouseDown;
        }
    }

    private void TitleBar_MouseDown(object sender, MouseEventArgs e)
    {
        mouseOffset = new Point(-e.X, -e.Y);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (e.Button == MouseButtons.Left)
        {
            Point mousePos = Control.MousePosition;
            mousePos.Offset(mouseOffset.X, mouseOffset.Y);
            Location = mousePos;
        }
    }
}
```

```csharp
// Form1.cs - 继承基类
public partial class Form1 : DraggableForm
{
    // 移除原有的 mouseOffset 字段和拖拽相关代码
    
    public Form1()
    {
        InitializeComponent();
        AttachDraggable(panelTitleBar, btnClose, btnMinimize, lblTitle);
    }
}
```

---

## 修复 8: 键盘快捷键

**问题**: 缺少键盘支持。

**修复方案**: 重写 `ProcessCmdKey` 方法。

```csharp
// Form1.cs

protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    switch (keyData)
    {
        case Keys.Escape:
            ShowCloseWarning();
            return true;
        case Keys.Enter:
            btnDecrypt.PerformClick();
            return true;
        case Keys.Space:
            if (timerCountdown.Enabled)
                timerCountdown.Stop();
            else
                timerCountdown.Start();
            return true;
        case Keys.M | Keys.Control:
            WindowState = FormWindowState.Minimized;
            return true;
    }
    return base.ProcessCmdKey(ref msg, keyData);
}
```

---

## 修复 9: Unicode 字符长度计算

**问题**: CJK 字符宽度计算不准确。

**修复方案**: 使用 `TextRenderer.MeasureText` 或 `StringInfo` 计算实际显示宽度。

```csharp
// CustomMessageBox.cs - 修改窗口大小计算逻辑

private Size CalculateSize(string message)
{
    using (var g = CreateGraphics())
    {
        var size = TextRenderer.MeasureText(message, lblMessage.Font);
        
        if (size.Width > 400)
            return new Size(550, 280);
        if (size.Width > 300)
            return new Size(500, 240);
        return new Size(450, 200);
    }
}

// 在构造函数中调用
private CustomMessageBox(string message, string title)
{
    var size = CalculateSize(message);
    InitializeMessageBox(message, title, size);
}
```

---

## 修复 10: 国际化/本地化

**问题**: 所有文本硬编码。

**修复方案**: 使用资源文件 (.resx) 管理多语言。

```csharp
// 新建 Resources.zh-CN.resx 和 Resources.en-US.resx
// 或使用 Dictionary 实现简单本地化

public static class Localization
{
    private static readonly Dictionary<string, Dictionary<string, string>> _resources = new()
    {
        ["zh-CN"] = new Dictionary<string, string>
        {
            ["Title"] = "续命",
            ["Warning"] = "哎呀，你的寿命正在快速消失！",
            ["Question1"] = "你的寿命怎么了？",
            ["ButtonDecrypt"] = "背诵三个代表",
            ["TimeExpired"] = "时间已到！你的生命已贡献给长者。"
        },
        ["en-US"] = new Dictionary<string, string>
        {
            ["Title"] = "Life Reaper",
            ["Warning"] = "Oh no, your life is rapidly disappearing!",
            ["Question1"] = "What happened to your life?",
            ["ButtonDecrypt"] = "Recite Three Represents",
            ["TimeExpired"] = "Time's up! Your life has been contributed."
        }
    };

    public static string Get(string key)
    {
        var culture = Thread.CurrentThread.CurrentUICulture.Name;
        if (_resources.TryGetValue(culture, out var dict) && dict.TryGetValue(key, out var value))
            return value;
        return _resources["zh-CN"][key]; // 默认中文
    }
}

// 使用方式
lblTitle.Text = Localization.Get("Title");
lblWarning.Text = Localization.Get("Warning");
```

---

## 修复 11: 无边框窗口的任务栏支持

**问题**: 无边框窗口缺少系统菜单。

**修复方案**: 添加自定义任务栏上下文菜单。

```csharp
// Form1.cs

private ContextMenuStrip taskbarMenu;

private void SetupTaskbarMenu()
{
    taskbarMenu = new ContextMenuStrip();
    
    var closeItem = new ToolStripMenuItem("关闭", null, (s, e) => ShowCloseWarning());
    var minimizeItem = new ToolStripMenuItem("最小化", null, (s, e) => WindowState = FormWindowState.Minimized);
    
    taskbarMenu.Items.AddRange(new ToolStripItem[] { minimizeItem, closeItem });
}

// 重写 WndProc 捕获右键点击
private const int WM_CONTEXTMENU = 0x007B;

protected override void WndProc(ref Message m)
{
    if (m.Msg == WM_CONTEXTMENU)
    {
        var p = PointToClient(new Point(MousePosition.X, MousePosition.Y));
        if (!panelContent.Bounds.Contains(p))
        {
            taskbarMenu.Show(this, p);
            return;
        }
    }
    base.WndProc(ref m);
}
```

---

## 项目结构改进建议

```
Life-Reaper-35/
├── Program.cs
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
├── CustomMessageBox.cs
├── WarningForm.cs
├── Theme.cs                 # 新增：主题/字体定义
├── Logger.cs                # 新增：日志记录
├── AppSettings.cs           # 新增：配置持久化
├── DraggableForm.cs         # 新增：拖拽基类
├── Localization.cs          # 新增：国际化
├── Resources/              # 新增：资源文件夹
│   ├── strings.zh-CN.resx
│   └── strings.en-US.resx
└── Life Reaper.csproj
```

---

## 工时估算

| 修复项 | 预估工时 |
|--------|----------|
| 1. Timer 资源泄漏 | 15 分钟 |
| 2. Font 资源泄漏 | 30 分钟 |
| 3. 魔法数字常量化 | 10 分钟 |
| 4. 异常处理和日志 | 45 分钟 |
| 5. DPI 缩放修复 | 30 分钟 |
| 6. 位置持久化 | 45 分钟 |
| 7. 基类抽取 | 30 分钟 |
| 8. 键盘快捷键 | 20 分钟 |
| 9. 字符计算修复 | 15 分钟 |
| 10. 国际化 | 2 小时 |
| 11. 任务栏支持 | 30 分钟 |
| **总计** | **约 6.5 小时** |