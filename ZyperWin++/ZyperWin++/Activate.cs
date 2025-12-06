using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZyperWin__
{
    public partial class Activate : UserControl
    {
        public Activate()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/cmontage/mas-cn");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "执行中...";

            try
            {
                // 检查文件是否存在
                string cmdFilePath = Path.Combine(Application.StartupPath, "Bin", "MAS_AIO_CN.cmd");

                if (!File.Exists(cmdFilePath))
                {
                    MessageBox.Show("未找到 MAS_AIO_CN.cmd 文件！\n请确保文件位于 .\\Bin\\ 目录下。",
                                  "文件未找到",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                await ExecuteCmdFile(cmdFilePath);

                MessageBox.Show("MAS激活执行完成！", "ZyperWin++", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"执行失败：\n{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 恢复按钮状态
                button1.Enabled = true;
                button1.Text = "开始激活";
            }
        }

        private async Task ExecuteCmdFile(string filePath)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.Arguments = $"/c \"{filePath}\"";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = false; // 设置为false可以看到CMD窗口
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;
                        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);

                        process.Start();

                        // 读取输出（可选）
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();

                        process.WaitForExit();

                        if (process.ExitCode != 0)
                        {
                            throw new Exception($"CMD执行失败，退出码: {process.ExitCode}\n错误信息: {error}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"执行CMD文件时出错: {ex.Message}");
                }
            });
        }
    }
}
