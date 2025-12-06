using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

namespace ZyperWin__
{
    public partial class Defender : UserControl
    {
        public Defender()
        {
            InitializeComponent();
            RefreshDefenderStatus();
        }

        private void RefreshDefenderStatus()
        {
            CheckWinDefendExistence();
        }

        private void CheckWinDefendExistence()
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();
                bool winDefendExists = services.Any(service => service.ServiceName.Equals("WinDefend", StringComparison.OrdinalIgnoreCase));

                if (winDefendExists)
                {
                    label2.Text = " 系统已存在Defender 服务";
                    label2.ForeColor = Color.FromArgb(76, 175, 80);
                    label2.PrefixColor = Color.FromArgb(76, 175, 80);
                    label2.PrefixSvg = "CheckCircleOutlined";

                    // Defender存在，继续检测其他状态
                    CheckWinDefendServiceStatus();
                    CheckSecurityHealthServiceStatus();

                    // 启用按钮
                    button1.Enabled = true;
                    button2.Enabled = true;

                    // 调用UpdateIconState来更新状态
                    UpdateIconState();
                }
                else
                {
                    label2.Text = " 系统未存在Defender 服务";
                    label2.ForeColor = Color.FromArgb(244, 67, 54);
                    label2.PrefixColor = Color.FromArgb(244, 67, 54);
                    label2.PrefixSvg = "CloseCircleOutlined";

                    // Defender不存在，清空其他标签并冻结按钮
                    ClearOtherLabels();
                    FreezeButtons();

                    // Defender不存在时直接设置为Error状态
                    iconState1.State = AntdUI.TType.Error;
                }
            }
            catch
            {
                label2.Text = " 检测服务存在性时出错";
                label2.ForeColor = Color.FromArgb(244, 67, 54);
                label2.PrefixColor = Color.FromArgb(244, 67, 54);
                label2.PrefixSvg = "CloseCircleOutlined";

                // 出错时也清空其他标签
                ClearOtherLabels();
                FreezeButtons();

                // 出错时也设置为Error状态
                iconState1.State = AntdUI.TType.Error;
            }
        }

        private void ClearOtherLabels()
        {
            // 清空label3、4、7的内容
            label3.Text = " ";
            label4.Text = " ";
            label7.Text = " ";

            // 重置颜色和图标为默认状态
            label3.ForeColor = SystemColors.ControlText;
            label4.ForeColor = SystemColors.ControlText;
            label7.ForeColor = SystemColors.ControlText;

            // 如果有PrefixColor和PrefixSvg属性，也重置
            try
            {
                label3.PrefixColor = SystemColors.ControlText;
                label4.PrefixColor = SystemColors.ControlText;
                label7.PrefixColor = SystemColors.ControlText;

                // 设置为空图标或默认图标
                label3.PrefixSvg = "";
                label4.PrefixSvg = "";
                label7.PrefixSvg = "";
            }
            catch
            {
                // 如果设置失败，忽略
            }
        }

        private void FreezeButtons()
        {
            // 冻结按钮
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void CheckWinDefendServiceStatus()
        {
            try
            {
                ServiceController winDefendService = ServiceController.GetServices()
                    .FirstOrDefault(service => service.ServiceName.Equals("WinDefend", StringComparison.OrdinalIgnoreCase));

                if (winDefendService == null)
                {
                    label3.Text = " Defender 服务未允许运行";
                    label3.ForeColor = Color.FromArgb(244, 67, 54);
                    label3.PrefixColor = Color.FromArgb(244, 67, 54);
                    label3.PrefixSvg = "CloseCircleOutlined";

                    label4.Text = " Defender 服务未在运行";
                    label4.ForeColor = Color.FromArgb(244, 67, 54);
                    label4.PrefixColor = Color.FromArgb(244, 67, 54);
                    label4.PrefixSvg = "CloseCircleOutlined";
                    return;
                }

                bool isDisabled = IsServiceDisabled(winDefendService.ServiceName);

                if (isDisabled)
                {
                    label3.Text = " Defender 服务未允许运行";
                    label3.ForeColor = Color.FromArgb(244, 67, 54);
                    label3.PrefixColor = Color.FromArgb(244, 67, 54);
                    label3.PrefixSvg = "CloseCircleOutlined";
                }
                else
                {
                    label3.Text = " Defender 服务已允许运行";
                    label3.ForeColor = Color.FromArgb(76, 175, 80);
                    label3.PrefixColor = Color.FromArgb(76, 175, 80);
                    label3.PrefixSvg = "CheckCircleOutlined";
                }

                if (winDefendService.Status == ServiceControllerStatus.Running)
                {
                    label4.Text = " Defender 服务正在运行";
                    label4.ForeColor = Color.FromArgb(76, 175, 80);
                    label4.PrefixColor = Color.FromArgb(76, 175, 80);
                    label4.PrefixSvg = "CheckCircleOutlined";
                }
                else
                {
                    label4.Text = " Defender 服务未在运行";
                    label4.ForeColor = Color.FromArgb(244, 67, 54);
                    label4.PrefixColor = Color.FromArgb(244, 67, 54);
                    label4.PrefixSvg = "CloseCircleOutlined";
                }
            }
            catch
            {
                label3.Text = " 检测服务状态时出错";
                label3.ForeColor = Color.FromArgb(244, 67, 54);
                label3.PrefixColor = Color.FromArgb(244, 67, 54);
                label3.PrefixSvg = "CloseCircleOutlined";

                label4.Text = " 检测服务运行时出错";
                label4.ForeColor = Color.FromArgb(244, 67, 54);
                label4.PrefixColor = Color.FromArgb(244, 67, 54);
                label4.PrefixSvg = "CloseCircleOutlined";
            }
        }

        private void CheckSecurityHealthServiceStatus()
        {
            try
            {
                ServiceController securityHealthService = ServiceController.GetServices()
                    .FirstOrDefault(service => service.ServiceName.Equals("SecurityHealthService", StringComparison.OrdinalIgnoreCase));

                if (securityHealthService == null)
                {
                    label7.Text = " 已禁用安全中心";
                    label7.ForeColor = Color.FromArgb(244, 67, 54);
                    label7.PrefixColor = Color.FromArgb(244, 67, 54);
                    label7.PrefixSvg = "CloseCircleOutlined";
                    return;
                }

                bool isDisabled = IsServiceDisabled(securityHealthService.ServiceName);

                if (isDisabled)
                {
                    label7.Text = " 已禁用安全中心";
                    label7.ForeColor = Color.FromArgb(244, 67, 54);
                    label7.PrefixColor = Color.FromArgb(244, 67, 54);
                    label7.PrefixSvg = "CloseCircleOutlined";
                }
                else
                {
                    label7.Text = " 已启用安全中心";
                    label7.ForeColor = Color.FromArgb(76, 175, 80);
                    label7.PrefixColor = Color.FromArgb(76, 175, 80);
                    label7.PrefixSvg = "CheckCircleOutlined";
                }
            }
            catch
            {
                label7.Text = " 检测安全中心时出错";
                label7.ForeColor = Color.FromArgb(244, 67, 54);
                label7.PrefixColor = Color.FromArgb(244, 67, 54);
                label7.PrefixSvg = "CloseCircleOutlined";
            }
        }

        private void UpdateIconState()
        {
            int disabledCount = 0;

            // 检查label3 - 只有当有内容时才计数
            if (!string.IsNullOrWhiteSpace(label3.Text) &&
                (label3.Text.Contains("未允许运行") || label3.ForeColor == Color.FromArgb(244, 67, 54)))
            {
                disabledCount++;
            }

            // 检查label4 - 只有当有内容时才计数
            if (!string.IsNullOrWhiteSpace(label4.Text) &&
                (label4.Text.Contains("未在运行") || label4.ForeColor == Color.FromArgb(244, 67, 54)))
            {
                disabledCount++;
            }

            // 检查label7 - 只有当有内容时才计数
            if (!string.IsNullOrWhiteSpace(label7.Text) &&
                (label7.Text.Contains("已禁用") || label7.ForeColor == Color.FromArgb(244, 67, 54)))
            {
                disabledCount++;
            }

            // 设置iconState1的状态
            if (disabledCount == 3)
            {
                iconState1.State = AntdUI.TType.Error;
            }
            else if (disabledCount > 0)
            {
                iconState1.State = AntdUI.TType.Warn;
            }
            else
            {
                iconState1.State = AntdUI.TType.Success;
            }
        }

        private bool IsServiceDisabled(string serviceName)
        {
            try
            {
                using (var serviceKey = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}"))
                {
                    if (serviceKey != null)
                    {
                        var startValue = serviceKey.GetValue("Start");
                        if (startValue != null && startValue is int start)
                        {
                            return start == 4;
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MainWindow = this.ParentForm as MainWindow;
            if (MainWindow == null) return;
            button1.Enabled = false;
            button2.Enabled = false;
            MainWindow.menu1.Enabled = false;
            DialogResult result = MessageBox.Show("是否禁用Windows Defender？", "ZyperWin++", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = @".\Bin\NSudoLG.exe",
                        Arguments = @"-U:T -P:E -ShowWindowMode:Hide Defender\DisableWD.bat",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    System.Diagnostics.Process.Start(psi)?.WaitForExit();
                    Process.Start(".\\Bin\\Defender\\NoticeOFF.bat");

                    MessageBox.Show("已禁用完成，请立即重启系统以生效。", "ZyperWin++", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDefenderStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"禁用失败: {ex.Message}", "ZyperWin++", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button1.Enabled = true;
                button2.Enabled = true;
                MainWindow.menu1.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                MainWindow.menu1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var MainWindow = this.ParentForm as MainWindow;
            if (MainWindow == null) return;
            button1.Enabled = false;
            button2.Enabled = false;
            MainWindow.menu1.Enabled = false;

            DialogResult result = MessageBox.Show("是否启用Windows Defender？", "ZyperWin++", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = @".\Bin\NSudoLG.exe",
                        Arguments = @"-U:T -P:E -ShowWindowMode:Hide Defender\EnableWD.bat",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    System.Diagnostics.Process.Start(psi)?.WaitForExit();
                    Process.Start(".\\Bin\\Defender\\NoticeON.bat");

                    MessageBox.Show("已启用完成，需要重启系统以生效。", "ZyperWin++", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDefenderStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"启用失败: {ex.Message}", "ZyperWin++", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button1.Enabled = true;
                button2.Enabled = true;
                MainWindow.menu1.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                MainWindow.menu1.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.123912.com/s/PJv7Vv-BxGr");
        }
    }
}