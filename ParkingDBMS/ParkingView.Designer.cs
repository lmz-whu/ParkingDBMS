namespace ParkingDBMS
{
    partial class ParkingView
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
            if (System.Windows.Forms.MessageBox.Show("是否确定退出系统", "提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            //首先关闭数据库连接
            if (SqlConn.State == System.Data.ConnectionState.Open)
                SqlConn.Close();
            //停止自动更新进程
            if (!this.开启自动更新ToolStripMenuItem.Enabled && this.停止自动更新ToolStripMenuItem.Enabled)
            {
                thread_refreshDB.Abort();
            }
            //
            for (int i = 0; i < Thread_list.Count; i++)
            {
                System.Threading.Thread td = Thread_list[i];
                td.Abort();
            }
            //关闭日志记录文件
            try
            {
                appRunFile = new System.IO.StreamWriter("运行日志.txt", true, System.Text.Encoding.Unicode);
                appRunFile.WriteLine("[{0}] 退出系统", System.DateTime.Now.ToString());
                appRunFile.Close();
            }
            catch (System.Exception ex)
            {

            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("数据库名称");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParkingView));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接到数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启自动更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止自动更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停车位检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.云端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.到屏幕ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.自动更新程序状态toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LeftPlotsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_connection = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_StartUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_stopUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.treeView_DataBase = new System.Windows.Forms.TreeView();
            this.tabControl_ShowTables = new System.Windows.Forms.TabControl();
            this.tabPage_Table = new System.Windows.Forms.TabPage();
            this.dataGridView_tables = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_InGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从数据库属性列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启视频检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.Panel2.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            this.tabControl_ShowTables.SuspendLayout();
            this.tabPage_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tables)).BeginInit();
            this.contextMenuStrip_InGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.停车位检测ToolStripMenuItem,
            this.云端ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(784, 25);
            this.menuStrip_main.TabIndex = 0;
            this.menuStrip_main.Text = "menuStrip_main";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接到数据库ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem,
            this.toolStripSeparator3});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 连接到数据库ToolStripMenuItem
            // 
            this.连接到数据库ToolStripMenuItem.Name = "连接到数据库ToolStripMenuItem";
            this.连接到数据库ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.连接到数据库ToolStripMenuItem.Text = "连接到数据库";
            this.连接到数据库ToolStripMenuItem.Click += new System.EventHandler(this.连接到数据库ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启自动更新ToolStripMenuItem,
            this.停止自动更新ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.编辑ToolStripMenuItem.Text = "自动更新";
            // 
            // 开启自动更新ToolStripMenuItem
            // 
            this.开启自动更新ToolStripMenuItem.Enabled = false;
            this.开启自动更新ToolStripMenuItem.Name = "开启自动更新ToolStripMenuItem";
            this.开启自动更新ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开启自动更新ToolStripMenuItem.Text = "开启自动更新";
            this.开启自动更新ToolStripMenuItem.Click += new System.EventHandler(this.开启自动更新ToolStripMenuItem_Click);
            // 
            // 停止自动更新ToolStripMenuItem
            // 
            this.停止自动更新ToolStripMenuItem.Enabled = false;
            this.停止自动更新ToolStripMenuItem.Name = "停止自动更新ToolStripMenuItem";
            this.停止自动更新ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.停止自动更新ToolStripMenuItem.Text = "停止自动更新";
            this.停止自动更新ToolStripMenuItem.Click += new System.EventHandler(this.停止自动更新ToolStripMenuItem_Click);
            // 
            // 停车位检测ToolStripMenuItem
            // 
            this.停车位检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启视频检测ToolStripMenuItem});
            this.停车位检测ToolStripMenuItem.Name = "停车位检测ToolStripMenuItem";
            this.停车位检测ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.停车位检测ToolStripMenuItem.Text = "停车位检测";
            // 
            // 云端ToolStripMenuItem
            // 
            this.云端ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上传ToolStripMenuItem,
            this.到屏幕ToolStripMenuItem});
            this.云端ToolStripMenuItem.Name = "云端ToolStripMenuItem";
            this.云端ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.云端ToolStripMenuItem.Text = "停车位信息发布";
            // 
            // 上传ToolStripMenuItem
            // 
            this.上传ToolStripMenuItem.Name = "上传ToolStripMenuItem";
            this.上传ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.上传ToolStripMenuItem.Text = "上传";
            this.上传ToolStripMenuItem.Click += new System.EventHandler(this.上传ToolStripMenuItem_Click);
            // 
            // 到屏幕ToolStripMenuItem
            // 
            this.到屏幕ToolStripMenuItem.Name = "到屏幕ToolStripMenuItem";
            this.到屏幕ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.到屏幕ToolStripMenuItem.Text = "到屏幕";
            this.到屏幕ToolStripMenuItem.Click += new System.EventHandler(this.到屏幕ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动更新程序状态toolStripStatusLabel,
            this.toolStripStatusLabel_LeftPlotsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // 自动更新程序状态toolStripStatusLabel
            // 
            this.自动更新程序状态toolStripStatusLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.自动更新程序状态toolStripStatusLabel.Name = "自动更新程序状态toolStripStatusLabel";
            this.自动更新程序状态toolStripStatusLabel.Size = new System.Drawing.Size(140, 17);
            this.自动更新程序状态toolStripStatusLabel.Text = "自动更新程序状态：关闭";
            // 
            // toolStripStatusLabel_LeftPlotsCount
            // 
            this.toolStripStatusLabel_LeftPlotsCount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripStatusLabel_LeftPlotsCount.Name = "toolStripStatusLabel_LeftPlotsCount";
            this.toolStripStatusLabel_LeftPlotsCount.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel_LeftPlotsCount.Text = "空闲车位数：0";
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_connection,
            this.toolStripButton_StartUpdate,
            this.toolStripButton_stopUpdate,
            this.toolStripSeparator2});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 25);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.Size = new System.Drawing.Size(784, 25);
            this.toolStrip_main.TabIndex = 2;
            this.toolStrip_main.Text = "toolStrip_main";
            // 
            // toolStripButton_connection
            // 
            this.toolStripButton_connection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_connection.Image = global::ParkingDBMS.Properties.Resources.连接;
            this.toolStripButton_connection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_connection.Name = "toolStripButton_connection";
            this.toolStripButton_connection.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_connection.Text = "连接到数据库";
            this.toolStripButton_connection.Click += new System.EventHandler(this.toolStripButton_connection_Click);
            // 
            // toolStripButton_StartUpdate
            // 
            this.toolStripButton_StartUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_StartUpdate.Enabled = false;
            this.toolStripButton_StartUpdate.Image = global::ParkingDBMS.Properties.Resources.开启;
            this.toolStripButton_StartUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_StartUpdate.Name = "toolStripButton_StartUpdate";
            this.toolStripButton_StartUpdate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_StartUpdate.Text = "开启自动更新";
            this.toolStripButton_StartUpdate.Click += new System.EventHandler(this.toolStripButton_StartUpdate_Click);
            // 
            // toolStripButton_stopUpdate
            // 
            this.toolStripButton_stopUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_stopUpdate.Enabled = false;
            this.toolStripButton_stopUpdate.Image = global::ParkingDBMS.Properties.Resources.关;
            this.toolStripButton_stopUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_stopUpdate.Name = "toolStripButton_stopUpdate";
            this.toolStripButton_stopUpdate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_stopUpdate.Text = "停止自动更新";
            this.toolStripButton_stopUpdate.Click += new System.EventHandler(this.toolStripButton_stopUpdate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer_main
            // 
            this.splitContainer_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main.Location = new System.Drawing.Point(0, 50);
            this.splitContainer_main.Name = "splitContainer_main";
            // 
            // splitContainer_main.Panel1
            // 
            this.splitContainer_main.Panel1.AutoScroll = true;
            this.splitContainer_main.Panel1.Controls.Add(this.treeView_DataBase);
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.Controls.Add(this.tabControl_ShowTables);
            this.splitContainer_main.Size = new System.Drawing.Size(784, 489);
            this.splitContainer_main.SplitterDistance = 172;
            this.splitContainer_main.TabIndex = 3;
            // 
            // treeView_DataBase
            // 
            this.treeView_DataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_DataBase.Enabled = false;
            this.treeView_DataBase.Location = new System.Drawing.Point(0, 0);
            this.treeView_DataBase.Name = "treeView_DataBase";
            treeNode1.Name = "节点_DataBase";
            treeNode1.Text = "数据库名称";
            this.treeView_DataBase.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView_DataBase.Size = new System.Drawing.Size(170, 487);
            this.treeView_DataBase.TabIndex = 0;
            this.treeView_DataBase.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnTreeViewShowTable);
            // 
            // tabControl_ShowTables
            // 
            this.tabControl_ShowTables.Controls.Add(this.tabPage_Table);
            this.tabControl_ShowTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_ShowTables.Enabled = false;
            this.tabControl_ShowTables.Location = new System.Drawing.Point(0, 0);
            this.tabControl_ShowTables.Name = "tabControl_ShowTables";
            this.tabControl_ShowTables.SelectedIndex = 0;
            this.tabControl_ShowTables.Size = new System.Drawing.Size(606, 487);
            this.tabControl_ShowTables.TabIndex = 0;
            // 
            // tabPage_Table
            // 
            this.tabPage_Table.Controls.Add(this.dataGridView_tables);
            this.tabPage_Table.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Table.Name = "tabPage_Table";
            this.tabPage_Table.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Table.Size = new System.Drawing.Size(598, 461);
            this.tabPage_Table.TabIndex = 0;
            this.tabPage_Table.Text = "表名";
            this.tabPage_Table.UseVisualStyleBackColor = true;
            // 
            // dataGridView_tables
            // 
            this.dataGridView_tables.AllowUserToResizeRows = false;
            this.dataGridView_tables.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView_tables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tables.ContextMenuStrip = this.contextMenuStrip_InGridView;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_tables.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_tables.Enabled = false;
            this.dataGridView_tables.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_tables.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_tables.Name = "dataGridView_tables";
            this.dataGridView_tables.RowTemplate.Height = 23;
            this.dataGridView_tables.Size = new System.Drawing.Size(592, 455);
            this.dataGridView_tables.TabIndex = 0;
            // 
            // contextMenuStrip_InGridView
            // 
            this.contextMenuStrip_InGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_delete,
            this.保存到数据库ToolStripMenuItem,
            this.从数据库属性列表ToolStripMenuItem});
            this.contextMenuStrip_InGridView.Name = "contextMenuStrip_InGridView";
            this.contextMenuStrip_InGridView.Size = new System.Drawing.Size(173, 70);
            // 
            // toolStripMenuItem_delete
            // 
            this.toolStripMenuItem_delete.Name = "toolStripMenuItem_delete";
            this.toolStripMenuItem_delete.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem_delete.Text = "删除行";
            this.toolStripMenuItem_delete.Click += new System.EventHandler(this.toolStripMenuItem_delete_Click);
            // 
            // 保存到数据库ToolStripMenuItem
            // 
            this.保存到数据库ToolStripMenuItem.Name = "保存到数据库ToolStripMenuItem";
            this.保存到数据库ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.保存到数据库ToolStripMenuItem.Text = "保存到数据库";
            this.保存到数据库ToolStripMenuItem.Click += new System.EventHandler(this.保存到数据库ToolStripMenuItem_Click);
            // 
            // 从数据库属性列表ToolStripMenuItem
            // 
            this.从数据库属性列表ToolStripMenuItem.Name = "从数据库属性列表ToolStripMenuItem";
            this.从数据库属性列表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.从数据库属性列表ToolStripMenuItem.Text = "从数据库刷新列表";
            this.从数据库属性列表ToolStripMenuItem.Click += new System.EventHandler(this.从数据库属性列表ToolStripMenuItem_Click);
            // 
            // 开启视频检测ToolStripMenuItem
            // 
            this.开启视频检测ToolStripMenuItem.Name = "开启视频检测ToolStripMenuItem";
            this.开启视频检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开启视频检测ToolStripMenuItem.Text = "开启视频检测";
            this.开启视频检测ToolStripMenuItem.Click += new System.EventHandler(this.开启视频检测ToolStripMenuItem_Click);
            // 
            // ParkingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer_main);
            this.Controls.Add(this.toolStrip_main);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "ParkingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于视频的停车场车位状态信息检测与管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.splitContainer_main.Panel1.ResumeLayout(false);
            this.splitContainer_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            this.tabControl_ShowTables.ResumeLayout(false);
            this.tabPage_Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tables)).EndInit();
            this.contextMenuStrip_InGridView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接到数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启自动更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止自动更新ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripButton toolStripButton_connection;
        private System.Windows.Forms.ToolStripButton toolStripButton_StartUpdate;
        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.TreeView treeView_DataBase;
        private System.Windows.Forms.TabControl tabControl_ShowTables;
        private System.Windows.Forms.TabPage tabPage_Table;
        private System.Windows.Forms.DataGridView dataGridView_tables;

        //创建ＳＱＬ数据库的连接
        private System.Data.SqlClient.SqlConnection SqlConn;
        private System.Data.SqlClient.SqlCommand SqlCmd;
        private System.Data.SqlClient.SqlDataAdapter SqlData = new System.Data.SqlClient.SqlDataAdapter();
        private System.Data.DataTable dataTable = new System.Data.DataTable();    //用来与DataGridView相关联
        string connectionString = "";   //数据库连接字符串

        private System.Threading.Thread thread_refreshDB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_InGridView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_delete;
        private System.Windows.Forms.ToolStripMenuItem 保存到数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从数据库属性列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_stopUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


        System.IO.StreamWriter appRunFile;
        private System.Windows.Forms.ToolStripStatusLabel 自动更新程序状态toolStripStatusLabel;

        //读取停车场视频文件生成刷新数据库的txt文件的线程的列表
        System.Collections.Generic.List<System.Threading.Thread> Thread_list = new System.Collections.Generic.List<System.Threading.Thread>();
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LeftPlotsCount;
        private System.Windows.Forms.ToolStripMenuItem 云端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传ToolStripMenuItem;

        private CheckStates_py.Form_AutoChecksys autoCheckSys = new CheckStates_py.Form_AutoChecksys();
        private System.Windows.Forms.ToolStripMenuItem 到屏幕ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停车位检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启视频检测ToolStripMenuItem;
    }
}

