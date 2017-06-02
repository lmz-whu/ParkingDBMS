namespace ParkingDBMS
{
    partial class ShowInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.listView_PlotsInfo = new System.Windows.Forms.ListView();
            this.Domain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Remain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "空闲车位";
            // 
            // listView_PlotsInfo
            // 
            this.listView_PlotsInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.listView_PlotsInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Domain,
            this.Remain});
            this.listView_PlotsInfo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_PlotsInfo.ForeColor = System.Drawing.Color.Red;
            this.listView_PlotsInfo.GridLines = true;
            this.listView_PlotsInfo.Location = new System.Drawing.Point(12, 41);
            this.listView_PlotsInfo.MultiSelect = false;
            this.listView_PlotsInfo.Name = "listView_PlotsInfo";
            this.listView_PlotsInfo.Size = new System.Drawing.Size(170, 241);
            this.listView_PlotsInfo.TabIndex = 1;
            this.listView_PlotsInfo.UseCompatibleStateImageBehavior = false;
            this.listView_PlotsInfo.View = System.Windows.Forms.View.Details;
            // 
            // Domain
            // 
            this.Domain.Text = "区域";
            this.Domain.Width = 75;
            // 
            // Remain
            // 
            this.Remain.Text = "空车位";
            this.Remain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Remain.Width = 75;
            // 
            // ShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(194, 291);
            this.Controls.Add(this.listView_PlotsInfo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowInfo";
            this.Load += new System.EventHandler(this.ShowInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_PlotsInfo;
        private System.Windows.Forms.ColumnHeader Domain;
        private System.Windows.Forms.ColumnHeader Remain;
    }
}