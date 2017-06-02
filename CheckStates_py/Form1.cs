using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

using AForge.Video;
using AForge.Controls;
using AForge;
using AForge.Imaging;
using AForge.Video.DirectShow;

namespace CheckStates_py
{
    public partial class Form_AutoChecksys : Form
    {
        public Form_AutoChecksys()
        {
            InitializeComponent();
            this.varThreshold = 3000;
            this.kpThreshold = 30;
        }

        private void but_AddVideo_Click(object sender, EventArgs e)
        {
            try
            {
                //Step1 获取comboBox中的对象，并设置新的一行的单元格的值
                DataGridViewTextBoxCell dgtb_name = new DataGridViewTextBoxCell();
                dgtb_name.Value = this.videoDevices[this.comboBox_devices.SelectedIndex].Name;
                DataGridViewTextBoxCell dgtb_index = new DataGridViewTextBoxCell();
                dgtb_index.Value = this.comboBox_devices.SelectedIndex;
                DataGridViewTextBoxCell dgtb_state = new DataGridViewTextBoxCell();
                dgtb_state.Value = "打开";
                DataGridViewButtonCell dgvb_change = new DataGridViewButtonCell();
                dgvb_change.Value = "删除";

                
                foreach(DataGridViewRow row in this.dataGridView1.Rows){
                    if (row.Cells[1].Value.Equals(dgtb_index.Value))
                    {
                        MessageBox.Show("该摄像机已存在，请选择其它摄像机", "警告");
                        return;
                    }
                }

                string coordinateFile = Application.StartupPath + "\\coordinate\\" + dgtb_index.Value.ToString() + ".txt";
                if (!File.Exists(coordinateFile))
                {
                    coordinateFile = OpenCoordinateFile();
                    if (coordinateFile.Equals("")) return;
                }

                //Step2 添加摄像机处理模块，设定指定摄像机序列号
                Thread newThread = new Thread(CheckStateFromCamera);
                newThread.Name = dgtb_index.Value.ToString();

                //设置检测过程中使用的阈值
                string parameters = dgtb_index.Value.ToString() + "%" + coordinateFile + "%" + 
                    this.varThreshold + "%" + this.kpThreshold;
                newThread.Start(parameters);


                //Step3 如果以上没有出错，则会将新的一行结果添加到显示界面上
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.Cells.Add(dgtb_name);
                dgvr.Cells.Add(dgtb_index);
                dgvr.Cells.Add(dgtb_state);
                dgvr.Cells.Add(dgvb_change);

                this.dataGridView1.Rows.Add(dgvr);
                this.comboBox_devices.SelectedIndex = -1;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "异常错误:");
            }
            
        }

        private string OpenCoordinateFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath + "\\coordinate";
            dialog.Filter = "txt file(*.txt)|*.txt";
            //dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 该函数是用来调用外部exe处理摄像机数据
        /// 
        /// </summary>
        /// <param name="argvs">包含摄像机序列号的整数</param>
        void CheckStateFromCamera(object argvs)
        {
            string[] parameters = (argvs as string).Split(new char[]{'%'}, 4);
            string Camera_index = parameters[0];
            string coordinateFile = parameters[1];
            int varThreshold = int.Parse(parameters[2]);
            int kpThreshold = int.Parse(parameters[3]);

            Process myprocess = new Process();
            myprocess.StartInfo.FileName = @"ParkingDetect.exe"; //设置外部EXE名称
            //设置外部EXE所需的参数，在坐标文件名前后加上双引号，防止路径出现空格
            myprocess.StartInfo.Arguments = "\"" + Camera_index + "\"" + " " + "\"" + coordinateFile + "\"" + " " + varThreshold + " " + kpThreshold;
            myprocess.StartInfo.UseShellExecute = false;    //取消DOS界面
            myprocess.StartInfo.CreateNoWindow = true;  //取消窗体
            myprocess.Start();  //开始进程
            //在显示界面上添加上当前进程的开始时间
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++ )
            {
                if (this.dataGridView1.Rows[i].Cells[1].Value.ToString() == Camera_index)
                {
                    this.Invoke(new Action(delegate()
                    {
                        this.dataGridView1.Rows[i].Cells[2].Value = myprocess.StartTime;
                    }));
                    break;
                }
            }
            
            myprocess.WaitForExit();    //等待进程执行结束


            Thread.Sleep(100);//暂定一段时间，用于在终止执行和异常情况下的调节
            //运行结束时删除显示列表中的对应项目
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (row.Cells[1].Value.ToString() == Camera_index)
                {
                    this.Invoke(new Action(delegate()
                    {
                        this.dataGridView1.Rows.Remove(row);
                    }));
                    break;
                }
            }
        }

        private void Form_AutoChecksys_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                this.comboBox_devices.Items.Add(device.Name);
            }
        }

        /// <summary>
        /// 响应显示窗口（dataGridView）中的删除按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">包含了一系列的点击的信息</param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //确保点击是在有效的范围之内
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            //获取所有的名称为ParkingDetect的进程，然后再计算每个进程的开始时间与显示列表中要删除的进程的开始时间的间隔
            //当时间间隔小于一定阈值，则删除该进程
            string but_index = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (but_index == "删除")
            {
                DateTime processTime = (DateTime)this.dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                processList = Process.GetProcessesByName("ParkingDetect");
                for (int i = 0; i < processList.Length;i++ )
                {
                    DateTime time = processList[i].StartTime;
                    TimeSpan tSpan = time - processTime;
                    if (tSpan.TotalSeconds < 1.0)
                    {
                        processList[i].Kill();
                    }
                }
                //清除显示窗口上的记录
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void but_genCoorFile_Click(object sender, EventArgs e)
        {
            string cameraIndex = this.comboBox_devices.SelectedIndex.ToString();
            if (cameraIndex.Equals("-1")) return;
            string outputFile = Application.StartupPath + "\\coordinate\\" + cameraIndex + ".txt";
            if (File.Exists(outputFile))
            {
                if(MessageBox.Show(outputFile + "\n该文件已经存在，是否覆盖", "警告", MessageBoxButtons.YesNo)
                    != DialogResult.Yes) return;
            }

            if (threadGenCoorFile == null || threadGenCoorFile.ThreadState ==  System.Threading.ThreadState.Stopped)
            {
                threadGenCoorFile = new System.Threading.Thread(GenerateCoordinateFile);
                threadGenCoorFile.Name = cameraIndex;
                threadGenCoorFile.Start(cameraIndex + " " + outputFile);
            }

        }

        void GenerateCoordinateFile(object argvs)
        {
            string[] parameters = (argvs as string).Split(new char[] { ' ' }, 2);
            int Camera_index = int.Parse(parameters[0]);
            string outputFile = parameters[1];

            Process genProcess = new Process();
            genProcess.StartInfo.FileName = @"GetPosition.exe"; //设置外部EXE名称
            //设置外部EXE所需的参数，在坐标文件名前后加上双引号，防止路径出现空格
            genProcess.StartInfo.Arguments = Camera_index + " " + "\"" + outputFile + "\"";
            genProcess.StartInfo.UseShellExecute = false;    //DOS界面
            genProcess.StartInfo.CreateNoWindow = true;  //窗体
            genProcess.Start();  //开始进程
            Thread.Sleep(1000);
            genProcess.WaitForExit();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 设置阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetThresholdValueDialog setThreshold = new SetThresholdValueDialog(varThreshold, kpThreshold);
            if (setThreshold.ShowDialog() == DialogResult.OK)
            {
                varThreshold = int.Parse(setThreshold.textBox_方差.Text);
                kpThreshold = int.Parse(setThreshold.textBox_特征点.Text);
            }
        }

        private void NewVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string vedioname = "";
                OpenFileDialog vedioFile = new OpenFileDialog();
                vedioFile.Filter = "(*.*)|*.*";
                if (vedioFile.ShowDialog() == DialogResult.OK)
                {
                    vedioname = vedioFile.FileName;
                }


                //Step1 获取comboBox中的对象，并设置新的一行的单元格的值
                DataGridViewTextBoxCell dgtb_name = new DataGridViewTextBoxCell();
                dgtb_name.Value = vedioname;
                DataGridViewTextBoxCell dgtb_index = new DataGridViewTextBoxCell();
                dgtb_index.Value = vedioname;
                DataGridViewTextBoxCell dgtb_state = new DataGridViewTextBoxCell();
                dgtb_state.Value = "打开";
                DataGridViewButtonCell dgvb_change = new DataGridViewButtonCell();
                dgvb_change.Value = "删除";


                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.Equals(dgtb_index.Value))
                    {
                        MessageBox.Show("该视频已存在，请选择其它摄像机", "警告");
                        return;
                    }
                }

                string coordinateFile = Application.StartupPath + "\\coordinate\\" + dgtb_index.Value + ".txt";
                if (!File.Exists(coordinateFile))
                {
                    coordinateFile = OpenCoordinateFile();
                    if (coordinateFile.Equals("")) return;
                }

                //Step2 添加摄像机处理模块，设定指定摄像机序列号
                Thread newThread = new Thread(CheckStateFromCamera);
                newThread.Name = dgtb_index.Value.ToString();

                //设置检测过程中使用的阈值
                string parameters = dgtb_index.Value.ToString() + "%" + coordinateFile + "%" +
                    this.varThreshold + "%" + this.kpThreshold;
                newThread.Start(parameters);


                //Step3 如果以上没有出错，则会将新的一行结果添加到显示界面上
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.Cells.Add(dgtb_name);
                dgvr.Cells.Add(dgtb_index);
                dgvr.Cells.Add(dgtb_state);
                dgvr.Cells.Add(dgvb_change);

                this.dataGridView1.Rows.Add(dgvr);
                this.comboBox_devices.SelectedIndex = -1;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "异常错误:");
            }
        }


    }
}
