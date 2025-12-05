# ZyperWin++ 项目上下文

## 项目概述
ZyperWin++ 是一个基于 .NET Framework 4.0 开发的 Windows 系统优化工具，适用于 Win7-Win11 系统。该项目采用 C# 开发，使用 SunnyUI 框架构建用户界面，提供系统性能优化、垃圾清理、服务管理、Office 安装等多种功能。

## 核心技术栈

### 开发框架
- **.NET Framework 4.0** - 基础运行时
- **Windows Forms** - UI 框架
- **SunnyUI** - 第三方 UI 组件库
- **C#** - 主要编程语言

### 项目架构
- **模块化设计**：每个功能独立为 UserControl
- **主窗口架构**：基于 TreeView 的导航系统
- **异步编程**：使用 Task 进行耗时操作

## 项目结构

```
ZyperWinOptimize/
├── ZyperWin++/                 # 主项目目录
│   ├── MainWindow.cs          # 主窗口入口
│   ├── MainWindow.Designer.cs # 主窗口设计器
│   ├── Program.cs             # 程序入口点
│   ├── Modules/               # 功能模块
│   │   ├── MainMenu.cs        # 主页模块
│   │   ├── kuaisuyouhua.cs    # 快速优化模块
│   │   ├── xingneng.cs        # 性能优化模块
│   │   ├── fuwu.cs            # 服务优化模块
│   │   ├── laji.cs            # 垃圾清理模块
│   │   ├── edge.cs            # Edge优化模块
│   │   ├── office.cs          # Office安装模块
│   │   ├── appx.cs            # Appx管理模块
│   │   ├── jihuo.cs           # 系统激活模块
│   │   ├── recover.cs         # 优化还原模块
│   │   └── ...                # 其他功能模块
│   ├── Properties/            # 项目属性
│   └── Bin/                   # 外部工具目录
└── README.md                  # 项目说明文档
```

## 核心功能模块

### 1. 快速优化系统 (kuaisuyouhua.cs)
- **基本优化**：轻度系统优化
- **深度优化**：中度系统优化
- **极限优化**：最大性能优化
- **Defender管理**：智能检测和处理

### 2. 性能优化设置 (xingneng.cs)
- 处理器性能调优
- 内存管理优化
- 网络参数优化
- 系统响应速度提升

### 3. 服务项管理 (fuwu.cs)
- Windows 服务禁用/启用
- 服务状态实时监控
- 批量服务操作

### 4. 垃圾清理 (laji.cs)
- 系统垃圾文件清理
- 浏览器缓存清理
- 临时文件清理
- 分组选择性清理

### 5. Edge浏览器优化 (edge.cs)
- Edge 性能设置
- 隐私保护配置
- 插件管理

## 开发约定

### 代码规范
1. **命名约定**：
   - 类名使用 PascalCase
   - 方法名使用 PascalCase
   - 变量名使用 camelCase
   - 常量使用 UPPER_CASE

2. **文件组织**：
   - 每个 UserControl 对应一个 .cs 和 .Designer.cs 文件
   - 功能相关的类放在同一模块中
   - 使用 partial class 分离界面和逻辑

3. **异常处理**：
   - 使用 try-catch 块处理异常
   - 提供用户友好的错误提示
   - 记录详细的错误日志

### UI 设计原则
- 使用 SunnyUI 的统一风格
- 响应式布局设计
- 进度条显示长时间操作
- 状态反馈及时更新

## 外部依赖

### 第三方工具
- **Defender_Control.exe** - Windows Defender 控制工具
- **Office 安装脚本** - 自动化 Office 部署
- **系统优化批处理** - 底层系统操作

### 系统要求
- Windows 7/8/10/11
- .NET Framework 4.0 或更高版本
- 管理员权限（推荐）

## 扩展开发指南

### 添加新功能模块
1. 创建新的 UserControl 类
2. 在 MainWindow 中添加导航节点
3. 实现模块具体功能
4. 更新主窗口的导航逻辑

### 优化建议
1. 使用异步操作避免 UI 阻塞
2. 实现详细的操作日志
3. 添加用户确认机制
4. 提供操作回退功能

## 版本信息
- **当前版本**：3.1
- **开发语言**：C#
- **UI框架**：SunnyUI + WinForms
- **目标平台**：Windows 7-11