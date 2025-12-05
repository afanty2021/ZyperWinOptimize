# ZyperWin++ 开发指南与最佳实践

## 开发环境配置

### 必需工具
1. **Visual Studio 2019+** 或 Visual Studio Community
2. **.NET Framework 4.0+** SDK
3. **Windows 7/10/11** 开发环境（推荐 Windows 10）

### 项目设置
```xml
<!-- 项目属性配置 -->
<TargetFrameworkVersion>v4.0</TargetFrameworkVersion>
<UseWindowsForms>true</UseWindowsForms>
<OutputType>WinExe</OutputType>
```

### SunnyUI 集成
```csharp
// 安装 SunnyUI NuGet 包
Install-Package SunnyUI

// 或手动添加引用
// 下载 SunnyUI.dll 并添加到项目引用
```

## 代码规范与最佳实践

### 1. 命名约定

#### 类命名 (PascalCase)
```csharp
public class PerformanceOptimizer
public class ServiceManager
public class GarbageCleaner
```

#### 方法命名 (PascalCase)
```csharp
public void ExecuteOptimization()
public bool IsServiceRunning()
private void UpdateProgressBar()
```

#### 变量命名 (camelCase)
```csharp
private bool isDefenderRunning;
private string optimizationPath;
private ProcessStartInfo processInfo;
```

#### 常量命名 (UPPER_CASE)
```csharp
private const string DEFENDER_TOOL_PATH = ".\\Bin\\Defender_Control.exe";
private const int DEFAULT_TIMEOUT = 5000;
```

### 2. 异常处理模式

#### 标准异常处理
```csharp
public bool ExecuteCommand(string command)
{
    try
    {
        // 执行操作
        using (Process process = new Process())
        {
            // 配置进程
            process.Start();
            process.WaitForExit();
            return process.ExitCode == 0;
        }
    }
    catch (UnauthorizedAccessException ex)
    {
        MessageBox.Show($"权限不足: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        LogError($"权限不足: {ex}");
        return false;
    }
    catch (FileNotFoundException ex)
    {
        MessageBox.Show($"找不到文件: {ex.FileName}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        LogError($"文件缺失: {ex}");
        return false;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"操作失败: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        LogError($"未知错误: {ex}");
        return false;
    }
}
```

#### 日志记录模式
```csharp
private void LogError(string message)
{
    string logPath = Path.Combine(Application.StartupPath, "logs", "error.log");
    Directory.CreateDirectory(Path.GetDirectoryName(logPath));

    File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n");
}

private void LogOperation(string operation)
{
    string logPath = Path.Combine(Application.StartupPath, "logs", "operations.log");
    Directory.CreateDirectory(Path.GetDirectoryName(logPath));

    File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {operation}\n");
}
```

### 3. UI 响应性最佳实践

#### 异步操作模式
```csharp
private async void btnOptimize_Click(object sender, EventArgs e)
{
    // 禁用UI控件
    SetUIControlsEnabled(false);
    btnOptimize.Text = "优化中...";

    try
    {
        // 显示进度
        progressBar.Value = 10;
        await Task.Delay(100); // 允许UI更新

        // 执行耗时操作
        bool success = await Task.Run(() => PerformOptimization());

        progressBar.Value = 100;
        if (success)
        {
            MessageBox.Show("优化完成！", "成功",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    finally
    {
        // 恢复UI状态
        SetUIControlsEnabled(true);
        btnOptimize.Text = "开始优化";
        progressBar.Value = 0;
    }
}

private void SetUIControlsEnabled(bool enabled)
{
    // 批量设置控件状态
    foreach (Control control in this.Controls)
    {
        if (control is Button button && button != btnCancel)
        {
            button.Enabled = enabled;
        }
    }
}
```

### 4. 资源管理模式

#### Using 语句使用
```csharp
public void CleanTempFiles()
{
    string[] tempPaths = GetTempPaths();

    foreach (string path in tempPaths)
    {
        try
        {
            if (Directory.Exists(path))
            {
                // 使用 DirectoryInfo 管理目录
                using (DirectoryInfo dirInfo = new DirectoryInfo(path))
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (Exception ex)
                        {
                            LogError($"删除文件失败 {file.FullName}: {ex.Message}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError($"清理目录失败 {path}: {ex.Message}");
        }
    }
}
```

### 5. 模块开发模式

#### 标准 UserControl 结构
```csharp
public partial class CustomOptimizationModule : UserControl
{
    public CustomOptimizationModule()
    {
        InitializeComponent();
        InitializeCustomComponents();
        SetupEventHandlers();
    }

    private void InitializeCustomComponents()
    {
        // 自定义组件初始化
        progressBar.Minimum = 0;
        progressBar.Maximum = 100;
        progressBar.Value = 0;
    }

    private void SetupEventHandlers()
    {
        // 事件绑定
        btnExecute.Click += BtnExecute_Click;
        btnCancel.Click += BtnCancel_Click;
    }

    private async void BtnExecute_Click(object sender, EventArgs e)
    {
        // 执行逻辑
        await ExecuteOptimization();
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        // 取消逻辑
        CancelOptimization();
    }
}
```

## 主窗口扩展指南

### 添加新功能模块

#### 1. 创建模块文件
```csharp
// NewModule.cs
public partial class NewModule : UserControl
{
    public NewModule()
    {
        InitializeComponent();
    }

    // 模块功能实现
}
```

#### 2. 更新 MainWindow.cs
```csharp
public partial class MainWindow : UIForm
{
    // 添加模块字段
    public NewModule f16; // 新模块

    private void uiTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        uiTreeView1.ExpandAll();

        // 添加新模块导航
        if (e.Node.Text.ToString() == "新功能模块")
        {
            f16 = new NewModule();
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(f16);
        }
    }
}
```

#### 3. 更新设计器文件
```csharp
// MainWindow.Designer.cs
// 在树节点中添加新节点
TreeNode treeNode16 = new TreeNode("新功能模块");
// 添加到树结构中
```

## 外部工具集成

### 工具集成模式
```csharp
public class ExternalToolManager
{
    private readonly string toolBasePath;

    public ExternalToolManager()
    {
        toolBasePath = Path.Combine(Application.StartupPath, "Bin");
    }

    public bool ExecuteTool(string toolName, string arguments = "")
    {
        string toolPath = Path.Combine(toolBasePath, toolName);

        if (!File.Exists(toolPath))
        {
            throw new FileNotFoundException($"工具文件不存在: {toolPath}");
        }

        try
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = toolPath;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                process.Start();
                process.WaitForExit();

                return process.ExitCode == 0;
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"执行工具失败: {ex.Message}", ex);
        }
    }
}
```

## 测试与调试

### 单元测试模式
```csharp
[Test]
public void TestOptimizationExecution()
{
    // Arrange
    var optimizer = new SystemOptimizer();

    // Act
    bool result = optimizer.ExecuteBasicOptimization();

    // Assert
    Assert.IsTrue(result);
}

[Test]
public void TestDefenderStatusCheck()
{
    // Arrange
    var defenderManager = new DefenderManager();

    // Act
    bool isRunning = defenderManager.IsRunning();

    // Assert
    Assert.IsNotNull(isRunning); // 应该返回状态，不抛异常
}
```

### 调试技巧
1. **日志记录**: 详细记录操作步骤
2. **异常追踪**: 捕获并记录所有异常
3. **状态监控**: 监控关键变量状态
4. **性能分析**: 使用 Stopwatch 测量执行时间

## 性能优化建议

### 1. 异步编程
```csharp
// 使用 async/await 避免UI阻塞
public async Task<bool> PerformHeavyOperation()
{
    return await Task.Run(() => {
        // 耗时操作
        return DoWork();
    });
}
```

### 2. 资源缓存
```csharp
// 缓存频繁访问的数据
private static readonly Dictionary<string, bool> ServiceStatusCache =
    new Dictionary<string, bool>();

public bool GetServiceStatus(string serviceName)
{
    if (ServiceStatusCache.ContainsKey(serviceName))
    {
        return ServiceStatusCache[serviceName];
    }

    bool status = CheckServiceStatus(serviceName);
    ServiceStatusCache[serviceName] = status;
    return status;
}
```

### 3. 内存管理
```csharp
// 及时释放资源
public void CleanupResources()
{
    // 清理缓存
    ServiceStatusCache.Clear();

    // 释放事件处理器
    foreach (Control control in Controls)
    {
        control.Dispose();
    }

    // 强制垃圾回收
    GC.Collect();
}
```

## 安全考虑

### 1. 权限检查
```csharp
public bool CheckAdministratorPrivileges()
{
    using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
    {
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}
```

### 2. 输入验证
```csharp
public bool ValidatePath(string path)
{
    try
    {
        // 检查路径格式
        if (string.IsNullOrWhiteSpace(path))
            return false;

        // 检查非法字符
        char[] invalidChars = Path.GetInvalidPathChars();
        if (path.IndexOfAny(invalidChars) >= 0)
            return false;

        return true;
    }
    catch
    {
        return false;
    }
}
```

## 版本控制与发布

### Git 工作流
```bash
# 功能开发分支
git checkout -b feature/new-optimization-module

# 提交更改
git add .
git commit -m "Add new optimization module"

# 合并到主分支
git checkout main
git merge feature/new-optimization-module
```

### 发布清单
- [ ] 编译 Release 版本
- [ ] 检查依赖完整性
- [ ] 测试所有功能模块
- [ ] 验证 Windows 版本兼容性
- [ ] 更新版本号
- [ ] 创建发布包

## 故障排除

### 常见问题及解决方案

1. **.NET Framework 版本不兼容**
   - 确保目标机器安装了 .NET Framework 4.0+
   - 检查 App.config 配置

2. **权限不足错误**
   - 以管理员身份运行
   - 添加 UAC 清单文件

3. **外部工具缺失**
   - 确保 Bin 目录包含所有必需工具
   - 检查文件路径配置

4. **UI 响应缓慢**
   - 使用异步操作
   - 优化耗时操作

5. **内存使用过高**
   - 及时释放资源
   - 检查内存泄漏

这个开发指南为 ZyperWin++ 项目提供了完整的开发规范和最佳实践，确保代码质量和项目可维护性。