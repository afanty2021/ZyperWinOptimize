using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ZyperWin__
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.bilibili.com/opus/1054761358514454535");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://space.bilibili.com/1645147838");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ZyperWave/ZyperWinOptimize");
        }
    }
}
