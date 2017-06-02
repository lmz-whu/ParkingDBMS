using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingDBMS
{
    public partial class ShowInfo : Form
    {
        public ShowInfo(List<ListViewItem> items)
        {
            InitializeComponent();
            this.listView_PlotsInfo.Items.Add(items[0]);
            //this.listView_PlotsInfo.Items.Add(items[1]);
        }

        private void ShowInfo_Load(object sender, EventArgs e)
        {
        }
    }
}
