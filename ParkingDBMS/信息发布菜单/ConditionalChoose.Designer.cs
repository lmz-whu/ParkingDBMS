namespace ParkingDBMS.信息发布菜单
{
    partial class ConditionalChoose
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
            this.textBox_Condition = new System.Windows.Forms.TextBox();
            this.but_Search = new System.Windows.Forms.Button();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_DomainID = new System.Windows.Forms.Button();
            this.but_PositionID = new System.Windows.Forms.Button();
            this.but_CameraID = new System.Windows.Forms.Button();
            this.but_State = new System.Windows.Forms.Button();
            this.but_等于 = new System.Windows.Forms.Button();
            this.but_不等于 = new System.Windows.Forms.Button();
            this.but_大于 = new System.Windows.Forms.Button();
            this.but_小于 = new System.Windows.Forms.Button();
            this.but_and = new System.Windows.Forms.Button();
            this.but_or = new System.Windows.Forms.Button();
            this.listBox_Values = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox_Condition
            // 
            this.textBox_Condition.Location = new System.Drawing.Point(3, 221);
            this.textBox_Condition.Multiline = true;
            this.textBox_Condition.Name = "textBox_Condition";
            this.textBox_Condition.Size = new System.Drawing.Size(318, 75);
            this.textBox_Condition.TabIndex = 0;
            // 
            // but_Search
            // 
            this.but_Search.Location = new System.Drawing.Point(165, 302);
            this.but_Search.Name = "but_Search";
            this.but_Search.Size = new System.Drawing.Size(75, 30);
            this.but_Search.TabIndex = 1;
            this.but_Search.Text = "查询";
            this.but_Search.UseVisualStyleBackColor = true;
            this.but_Search.Click += new System.EventHandler(this.but_Search_Click);
            // 
            // but_Cancel
            // 
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Location = new System.Drawing.Point(246, 302);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(75, 30);
            this.but_Cancel.TabIndex = 2;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_DomainID
            // 
            this.but_DomainID.Location = new System.Drawing.Point(3, 12);
            this.but_DomainID.Name = "but_DomainID";
            this.but_DomainID.Size = new System.Drawing.Size(75, 23);
            this.but_DomainID.TabIndex = 3;
            this.but_DomainID.Text = "DomainID";
            this.but_DomainID.UseVisualStyleBackColor = true;
            this.but_DomainID.Click += new System.EventHandler(this.but_DomainID_Click);
            // 
            // but_PositionID
            // 
            this.but_PositionID.Location = new System.Drawing.Point(3, 41);
            this.but_PositionID.Name = "but_PositionID";
            this.but_PositionID.Size = new System.Drawing.Size(75, 23);
            this.but_PositionID.TabIndex = 3;
            this.but_PositionID.Text = "PositionID";
            this.but_PositionID.UseVisualStyleBackColor = true;
            this.but_PositionID.Click += new System.EventHandler(this.but_PositionID_Click);
            // 
            // but_CameraID
            // 
            this.but_CameraID.Location = new System.Drawing.Point(3, 70);
            this.but_CameraID.Name = "but_CameraID";
            this.but_CameraID.Size = new System.Drawing.Size(75, 23);
            this.but_CameraID.TabIndex = 3;
            this.but_CameraID.Text = "CameraID";
            this.but_CameraID.UseVisualStyleBackColor = true;
            this.but_CameraID.Click += new System.EventHandler(this.but_CameraID_Click);
            // 
            // but_State
            // 
            this.but_State.Location = new System.Drawing.Point(3, 99);
            this.but_State.Name = "but_State";
            this.but_State.Size = new System.Drawing.Size(75, 23);
            this.but_State.TabIndex = 3;
            this.but_State.Text = "State";
            this.but_State.UseVisualStyleBackColor = true;
            this.but_State.Click += new System.EventHandler(this.but_State_Click);
            // 
            // but_等于
            // 
            this.but_等于.Location = new System.Drawing.Point(112, 12);
            this.but_等于.Name = "but_等于";
            this.but_等于.Size = new System.Drawing.Size(26, 23);
            this.but_等于.TabIndex = 4;
            this.but_等于.Text = "=";
            this.but_等于.UseVisualStyleBackColor = true;
            this.but_等于.Click += new System.EventHandler(this.but_等于_Click);
            // 
            // but_不等于
            // 
            this.but_不等于.Location = new System.Drawing.Point(112, 41);
            this.but_不等于.Name = "but_不等于";
            this.but_不等于.Size = new System.Drawing.Size(26, 23);
            this.but_不等于.TabIndex = 4;
            this.but_不等于.Text = "!=";
            this.but_不等于.UseVisualStyleBackColor = true;
            this.but_不等于.Click += new System.EventHandler(this.but_不等于_Click);
            // 
            // but_大于
            // 
            this.but_大于.Location = new System.Drawing.Point(112, 70);
            this.but_大于.Name = "but_大于";
            this.but_大于.Size = new System.Drawing.Size(26, 23);
            this.but_大于.TabIndex = 4;
            this.but_大于.Text = ">";
            this.but_大于.UseVisualStyleBackColor = true;
            this.but_大于.Click += new System.EventHandler(this.but_or_Click);
            // 
            // but_小于
            // 
            this.but_小于.Location = new System.Drawing.Point(112, 99);
            this.but_小于.Name = "but_小于";
            this.but_小于.Size = new System.Drawing.Size(26, 23);
            this.but_小于.TabIndex = 4;
            this.but_小于.Text = "<";
            this.but_小于.UseVisualStyleBackColor = true;
            this.but_小于.Click += new System.EventHandler(this.but_or_Click);
            // 
            // but_and
            // 
            this.but_and.Location = new System.Drawing.Point(112, 128);
            this.but_and.Name = "but_and";
            this.but_and.Size = new System.Drawing.Size(41, 23);
            this.but_and.TabIndex = 4;
            this.but_and.Text = "and";
            this.but_and.UseVisualStyleBackColor = true;
            this.but_and.Click += new System.EventHandler(this.but_and_Click);
            // 
            // but_or
            // 
            this.but_or.Location = new System.Drawing.Point(112, 157);
            this.but_or.Name = "but_or";
            this.but_or.Size = new System.Drawing.Size(41, 23);
            this.but_or.TabIndex = 4;
            this.but_or.Text = "or";
            this.but_or.UseVisualStyleBackColor = true;
            this.but_or.Click += new System.EventHandler(this.but_or_Click);
            // 
            // listBox_Values
            // 
            this.listBox_Values.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Values.FormattingEnabled = true;
            this.listBox_Values.ItemHeight = 16;
            this.listBox_Values.Location = new System.Drawing.Point(194, 12);
            this.listBox_Values.Name = "listBox_Values";
            this.listBox_Values.Size = new System.Drawing.Size(120, 164);
            this.listBox_Values.TabIndex = 5;
            this.listBox_Values.SelectedIndexChanged += new System.EventHandler(this.listBox_Values_SelectedIndexChanged);
            this.listBox_Values.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Values_MouseDoubleClick);
            // 
            // ConditionalChoose
            // 
            this.AcceptButton = this.but_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(326, 334);
            this.Controls.Add(this.listBox_Values);
            this.Controls.Add(this.but_or);
            this.Controls.Add(this.but_and);
            this.Controls.Add(this.but_小于);
            this.Controls.Add(this.but_大于);
            this.Controls.Add(this.but_不等于);
            this.Controls.Add(this.but_等于);
            this.Controls.Add(this.but_State);
            this.Controls.Add(this.but_CameraID);
            this.Controls.Add(this.but_PositionID);
            this.Controls.Add(this.but_DomainID);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_Search);
            this.Controls.Add(this.textBox_Condition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConditionalChoose";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条件查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Condition;
        private System.Windows.Forms.Button but_Search;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_DomainID;
        private System.Windows.Forms.Button but_PositionID;
        private System.Windows.Forms.Button but_CameraID;
        private System.Windows.Forms.Button but_State;
        private System.Windows.Forms.Button but_等于;
        private System.Windows.Forms.Button but_不等于;
        private System.Windows.Forms.Button but_大于;
        private System.Windows.Forms.Button but_小于;
        private System.Windows.Forms.Button but_and;
        private System.Windows.Forms.Button but_or;
        private System.Windows.Forms.ListBox listBox_Values;

        public string conditiontext;
        private System.Data.SqlClient.SqlConnection sConnection;


    }
}