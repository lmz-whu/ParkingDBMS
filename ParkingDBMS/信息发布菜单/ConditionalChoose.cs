using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ParkingDBMS.信息发布菜单
{
    public partial class ConditionalChoose : Form
    {
        public ConditionalChoose(string connectiontext)
        {
            InitializeComponent();
            conditiontext = "";
            sConnection = new SqlConnection(connectiontext);
            sConnection.Open();
        }

        private void but_Search_Click(object sender, EventArgs e)
        {
            conditiontext = this.textBox_Condition.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void but_DomainID_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "DomainID ";
            SqlCommand scmd = new SqlCommand("select DomainID from View_Camera_Position group by DomainID", sConnection);
            SqlDataReader sDataReader = scmd.ExecuteReader();
            this.listBox_Values.Items.Clear();
            while (sDataReader.Read())
            {
                this.listBox_Values.Items.Add(sDataReader[0]);
            }
            sDataReader.Close();
            scmd.Dispose();
        }

        private void but_PositionID_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "PositionID ";
            SqlCommand scmd = new SqlCommand("select PositionID from View_Camera_Position group by PositionID", sConnection);
            SqlDataReader sDataReader = scmd.ExecuteReader();
            this.listBox_Values.Items.Clear();
            while (sDataReader.Read())
            {
                this.listBox_Values.Items.Add(sDataReader[0]);
            }
            sDataReader.Close();
            scmd.Dispose();
        }

        private void but_CameraID_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "CameraID ";
            SqlCommand scmd = new SqlCommand("select CameraID from View_Camera_Position group by CameraID", sConnection);
            SqlDataReader sDataReader = scmd.ExecuteReader();
            this.listBox_Values.Items.Clear();
            while (sDataReader.Read())
            {
                this.listBox_Values.Items.Add(sDataReader[0]);
            }
            sDataReader.Close();
            scmd.Dispose();
        }

        private void but_State_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "state ";
            SqlCommand scmd = new SqlCommand("select state from View_Camera_Position group by state", sConnection);
            SqlDataReader sDataReader = scmd.ExecuteReader();
            this.listBox_Values.Items.Clear();
            while (sDataReader.Read())
            {
                this.listBox_Values.Items.Add(sDataReader[0]);
            }
            sDataReader.Close();
            scmd.Dispose();
        }

        private void but_等于_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "= ";
        }

        private void but_不等于_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "!= ";
        }

        private void but_and_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "and ";
        }
        private void but_or_Click(object sender, EventArgs e)
        {
            this.textBox_Condition.Text += "or ";
        }

        private void listBox_Values_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox_Values_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listBox_Values.SelectedItem != null)
            {
                this.textBox_Condition.Text += "'" + this.listBox_Values.SelectedItem.ToString().Trim() + "'" + " ";
            }
            
        }


    }
}
