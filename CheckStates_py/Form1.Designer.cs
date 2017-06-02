namespace CheckStates_py
{
    partial class Form_AutoChecksys
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
            //当系统退出时，停止所有的进程
            System.Diagnostics.Process[] proList_parkingDetect = System.Diagnostics.Process.GetProcessesByName("ParkingDetect");
            for (int i = 0; i < proList_parkingDetect.Length; i++)
            {
                proList_parkingDetect[i].Kill();
            }
            System.Diagnostics.Process[] proList_getPosition = System.Diagnostics.Process.GetProcessesByName("GetPosition");
            for (int i = 0; i < proList_getPosition.Length; i++)
            {
                proList_getPosition[i].Kill();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AutoChecksys));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_devices = new System.Windows.Forms.ComboBox();
            this.but_AddVideo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Change = new System.Windows.Forms.DataGridViewButtonColumn();
            this.but_genCoorFile = new System.Windows.Forms.Button();
            this.menuStrip_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(431, 25);
            this.menuStrip_main.TabIndex = 0;
            this.menuStrip_main.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewVideoToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // NewVideoToolStripMenuItem
            // 
            this.NewVideoToolStripMenuItem.Name = "NewVideoToolStripMenuItem";
            this.NewVideoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NewVideoToolStripMenuItem.Text = "新建视频";
            this.NewVideoToolStripMenuItem.Click += new System.EventHandler(this.NewVideoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置阈值ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 设置阈值ToolStripMenuItem
            // 
            this.设置阈值ToolStripMenuItem.Name = "设置阈值ToolStripMenuItem";
            this.设置阈值ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置阈值ToolStripMenuItem.Text = "设置阈值";
            this.设置阈值ToolStripMenuItem.Click += new System.EventHandler(this.设置阈值ToolStripMenuItem_Click);
            // 
            // comboBox_devices
            // 
            this.comboBox_devices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_devices.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_devices.FormattingEnabled = true;
            this.comboBox_devices.Location = new System.Drawing.Point(12, 38);
            this.comboBox_devices.Name = "comboBox_devices";
            this.comboBox_devices.Size = new System.Drawing.Size(195, 22);
            this.comboBox_devices.TabIndex = 1;
            // 
            // but_AddVideo
            // 
            this.but_AddVideo.Location = new System.Drawing.Point(214, 37);
            this.but_AddVideo.Name = "but_AddVideo";
            this.but_AddVideo.Size = new System.Drawing.Size(40, 23);
            this.but_AddVideo.TabIndex = 2;
            this.but_AddVideo.Text = "添加";
            this.but_AddVideo.UseVisualStyleBackColor = true;
            this.but_AddVideo.Click += new System.EventHandler(this.but_AddVideo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Name,
            this.Col_index,
            this.Col_State,
            this.Col_Change});
            this.dataGridView1.Location = new System.Drawing.Point(12, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(407, 244);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Col_Name
            // 
            this.Col_Name.HeaderText = "名称";
            this.Col_Name.MinimumWidth = 10;
            this.Col_Name.Name = "Col_Name";
            this.Col_Name.ReadOnly = true;
            this.Col_Name.Width = 150;
            // 
            // Col_index
            // 
            this.Col_index.HeaderText = "序列";
            this.Col_index.Name = "Col_index";
            this.Col_index.ReadOnly = true;
            this.Col_index.Width = 60;
            // 
            // Col_State
            // 
            this.Col_State.HeaderText = "开始时间";
            this.Col_State.Name = "Col_State";
            this.Col_State.ReadOnly = true;
            // 
            // Col_Change
            // 
            this.Col_Change.HeaderText = "更改";
            this.Col_Change.MinimumWidth = 10;
            this.Col_Change.Name = "Col_Change";
            this.Col_Change.ReadOnly = true;
            this.Col_Change.Text = "";
            this.Col_Change.Width = 50;
            // 
            // but_genCoorFile
            // 
            this.but_genCoorFile.Location = new System.Drawing.Point(261, 37);
            this.but_genCoorFile.Name = "but_genCoorFile";
            this.but_genCoorFile.Size = new System.Drawing.Size(86, 23);
            this.but_genCoorFile.TabIndex = 5;
            this.but_genCoorFile.Text = "创建坐标文件";
            this.but_genCoorFile.UseVisualStyleBackColor = true;
            this.but_genCoorFile.Click += new System.EventHandler(this.but_genCoorFile_Click);
            // 
            // Form_AutoChecksys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 318);
            this.Controls.Add(this.but_genCoorFile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.but_AddVideo);
            this.Controls.Add(this.comboBox_devices);
            this.Controls.Add(this.menuStrip_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_main;
            this.MaximizeBox = false;
            this.Name = "Form_AutoChecksys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自动检测系统";
            this.Load += new System.EventHandler(this.Form_AutoChecksys_Load);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_devices;
        private System.Windows.Forms.Button but_AddVideo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button but_genCoorFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_State;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Change;

        private AForge.Video.DirectShow.FilterInfoCollection videoDevices;
        private System.Diagnostics.Process[] processList;
        private System.Threading.Thread threadGenCoorFile;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置阈值ToolStripMenuItem;


        //阈值
        private int varThreshold;
        private int kpThreshold;
    }
}

