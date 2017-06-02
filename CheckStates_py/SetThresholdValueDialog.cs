using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckStates_py
{
    public partial class SetThresholdValueDialog : Form
    {
        public SetThresholdValueDialog(int varThresh, int kpThresh)
        {
            InitializeComponent();
            this.textBox_方差.Text = varThresh.ToString();
            this.textBox_特征点.Text = kpThresh.ToString();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if (this.textBox_方差.Text.Equals(null))
            {
                this.textBox_方差.Text = "0";
            }
            if (this.textBox_特征点.Text.Equals(null))
            {
                this.textBox_特征点.Text = "0";
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox_方差_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox_特征点_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                e.Handled = true;
        }


        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
