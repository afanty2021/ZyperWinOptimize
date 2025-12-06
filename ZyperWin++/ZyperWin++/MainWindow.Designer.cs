namespace ZyperWin__
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem3 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem4 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem5 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem6 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem7 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem8 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem9 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem10 = new AntdUI.MenuItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menu1 = new AntdUI.Menu();
            this.panel1 = new AntdUI.Panel();
            this.pageHeader1 = new AntdUI.PageHeader();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.tableLayoutPanel1.Controls.Add(this.menu1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 507);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // menu1
            // 
            this.menu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Font = new System.Drawing.Font("微软雅黑", 10F);
            menuItem1.BadgeSvg = "";
            menuItem1.IconSvg = "HomeOutlined";
            menuItem1.Text = "主页";
            menuItem2.IconSvg = "ControlOutlined";
            menuItem2.Text = "系统优化";
            menuItem3.IconSvg = "SafetyOutlined";
            menuItem3.Text = "安全中心";
            menuItem4.IconSvg = "SyncOutlined";
            menuItem4.Text = "还原选项";
            menuItem5.IconSvg = "RestOutlined";
            menuItem5.Text = "垃圾清理";
            menuItem6.IconSvg = "FileOutlined";
            menuItem6.Text = "Office管理";
            menuItem7.IconSvg = "KeyOutlined";
            menuItem7.Text = "系统激活";
            menuItem8.IconSvg = "AppstoreAddOutlined";
            menuItem8.Text = "Appx管理";
            menuItem9.IconSvg = "QuestionCircleOutlined";
            menuItem9.Text = "疑难解答";
            menuItem10.IconSvg = "EllipsisOutlined";
            menuItem10.Text = "关于软件";
            this.menu1.Items.Add(menuItem1);
            this.menu1.Items.Add(menuItem2);
            this.menu1.Items.Add(menuItem3);
            this.menu1.Items.Add(menuItem4);
            this.menu1.Items.Add(menuItem5);
            this.menu1.Items.Add(menuItem6);
            this.menu1.Items.Add(menuItem7);
            this.menu1.Items.Add(menuItem8);
            this.menu1.Items.Add(menuItem9);
            this.menu1.Items.Add(menuItem10);
            this.menu1.Location = new System.Drawing.Point(3, 3);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(131, 501);
            this.menu1.TabIndex = 0;
            this.menu1.Text = "menu1";
            this.menu1.SelectChanged += new AntdUI.SelectEventHandler(this.menu1_SelectChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(140, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 501);
            this.panel1.TabIndex = 1;
            this.panel1.Text = "panel1";
            // 
            // pageHeader1
            // 
            this.pageHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageHeader1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.pageHeader1.Icon = global::ZyperWin__.Properties.Resources.zw_;
            this.pageHeader1.Location = new System.Drawing.Point(0, 0);
            this.pageHeader1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageHeader1.MaximizeBox = false;
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowButton = true;
            this.pageHeader1.ShowIcon = true;
            this.pageHeader1.Size = new System.Drawing.Size(860, 33);
            this.pageHeader1.TabIndex = 0;
            this.pageHeader1.Text = "ZyperWin++ v4.1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 540);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pageHeader1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(860, 540);
            this.MinimumSize = new System.Drawing.Size(860, 540);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZyperWin++ v4.1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AntdUI.Panel panel1;
        public AntdUI.Menu menu1;
    }
}

