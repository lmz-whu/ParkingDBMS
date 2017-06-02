namespace CheckStates_py
{
    partial class SetThresholdValueDialog
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
            this.but_cancel = new System.Windows.Forms.Button();
            this.but_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_方差 = new System.Windows.Forms.TextBox();
            this.textBox_特征点 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // but_cancel
            // 
            this.but_cancel.Location = new System.Drawing.Point(123, 80);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(75, 28);
            this.but_cancel.TabIndex = 0;
            this.but_cancel.Text = "取消";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // but_ok
            // 
            this.but_ok.Location = new System.Drawing.Point(12, 80);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(75, 28);
            this.but_ok.TabIndex = 1;
            this.but_ok.Text = "确定";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "方差阈值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "特征点阈值";
            // 
            // textBox_方差
            // 
            this.textBox_方差.Location = new System.Drawing.Point(95, 10);
            this.textBox_方差.Name = "textBox_方差";
            this.textBox_方差.Size = new System.Drawing.Size(96, 21);
            this.textBox_方差.TabIndex = 4;
            this.textBox_方差.Text = "3000";
            this.textBox_方差.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_方差_KeyPress);
            // 
            // textBox_特征点
            // 
            this.textBox_特征点.Location = new System.Drawing.Point(96, 44);
            this.textBox_特征点.Name = "textBox_特征点";
            this.textBox_特征点.Size = new System.Drawing.Size(95, 21);
            this.textBox_特征点.TabIndex = 5;
            this.textBox_特征点.Text = "30";
            this.textBox_特征点.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_特征点_KeyPress);
            // 
            // SetThresholdValueDialog
            // 
            this.AcceptButton = this.but_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.but_cancel;
            this.ClientSize = new System.Drawing.Size(231, 115);
            this.Controls.Add(this.textBox_特征点);
            this.Controls.Add(this.textBox_方差);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.but_cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetThresholdValueDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置阈值";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox_方差;
        public System.Windows.Forms.TextBox textBox_特征点;
    }
}