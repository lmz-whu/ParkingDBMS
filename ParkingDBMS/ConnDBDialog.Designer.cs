namespace ParkingDBMS
{
    partial class ConnDBDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnDBDialog));
            this.but_cancel = new System.Windows.Forms.Button();
            this.but_connect = new System.Windows.Forms.Button();
            this.textBox_database = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_cancel
            // 
            this.but_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_cancel.Location = new System.Drawing.Point(352, 172);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(75, 23);
            this.but_cancel.TabIndex = 11;
            this.but_cancel.Text = "取消";
            this.but_cancel.UseVisualStyleBackColor = true;
            // 
            // but_connect
            // 
            this.but_connect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_connect.Location = new System.Drawing.Point(253, 172);
            this.but_connect.Name = "but_connect";
            this.but_connect.Size = new System.Drawing.Size(75, 23);
            this.but_connect.TabIndex = 10;
            this.but_connect.Text = "连接";
            this.but_connect.UseVisualStyleBackColor = true;
            this.but_connect.Click += new System.EventHandler(this.but_connect_Click);
            // 
            // textBox_database
            // 
            this.textBox_database.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_database.Location = new System.Drawing.Point(134, 99);
            this.textBox_database.Name = "textBox_database";
            this.textBox_database.Size = new System.Drawing.Size(242, 26);
            this.textBox_database.TabIndex = 9;
            this.textBox_database.Text = "ParkingDB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "数据库名称";
            // 
            // textBox_server
            // 
            this.textBox_server.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_server.Location = new System.Drawing.Point(134, 45);
            this.textBox_server.Name = "textBox_server";
            this.textBox_server.Size = new System.Drawing.Size(242, 26);
            this.textBox_server.TabIndex = 7;
            this.textBox_server.Text = "MINGMING-PC\\LMZWHUDB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "服务器名称";
            // 
            // ConnDBDialog
            // 
            this.AcceptButton = this.but_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.but_cancel;
            this.ClientSize = new System.Drawing.Size(439, 207);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_connect);
            this.Controls.Add(this.textBox_database);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_server);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnDBDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库连接对话框";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Button but_connect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox_database;
        public System.Windows.Forms.TextBox textBox_server;
    }
}