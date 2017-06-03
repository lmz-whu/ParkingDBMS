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
using System.Threading;
using System.IO;
using System.Diagnostics;

using ParkingDBMS.WCFService;
using CheckStates_py;
using ParkingDBMS.HelpMenu;
using ParkingDBMS.信息发布菜单;

namespace ParkingDBMS
{
    public partial class ParkingView : Form
    {
        public ParkingView()
        {
            InitializeComponent();
            SqlConn = new SqlConnection();  //数据库连接初始化
            stop_refresh_screen = false;
            appRunFile = new StreamWriter("运行日志.txt", true, Encoding.Unicode);
            appRunFile.WriteLine("**********************************************************");
            appRunFile.WriteLine("[{0}] 打开系统", DateTime.Now.ToString());
            appRunFile.Close();
            stopcmd = "";
            
        }

        /**********************以下为文件菜单下面的功能实现****************************/
        private void 连接到数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //补充1 如果当前正在处理数据库，则提示先停止更新操作
            if(thread_refreshDB != null && thread_refreshDB.ThreadState != System.Threading.ThreadState.Aborted)
            {
                MessageBox.Show("数据库正在操作，请先停止更新","连接错误");
                return;
            }
            //补充2 如果数据库连接已经打开，提示用户是否关闭当前连接，重新执行连接操作
            if (SqlConn.State == ConnectionState.Open)
            {
                //弹出系统提示框，让用户确认是否继续操作
                if (MessageBox.Show("是否关闭当前连接，打开新连接", "系统提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    return;
                SqlConn.Close();    //如果当前数据库连接已经打开，则应当先关闭连接
            }

            //补充3 弹出对话框，让用户填写数据库和服务器的名称
            string DataSource = @"MINGMING-PC\LMZWHUDB";    //设置数据库的服务器初始名称
            string DatabaseName = "ParkingDB";              //设置连接的初始数据库初始名称
            ConnDBDialog DBDlg = new ConnDBDialog();
            if (DBDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataSource = DBDlg.textBox_server.Text;
                DatabaseName = DBDlg.textBox_database.Text;
            }
            else
            {
                this.dataGridView_tables.DataSource = null;
                this.dataGridView_tables.Invalidate();
                this.treeView_DataBase.Enabled = false;      
                this.tabControl_ShowTables.Enabled = false;  
                this.开启自动更新ToolStripMenuItem.Enabled = false;    
                this.toolStripButton_StartUpdate.Enabled = false;    
                return;
            }
            appRunFile = new StreamWriter("运行日志.txt", true, Encoding.Unicode);   //打开运行日志文件，如果不存在则创建新的文件，并向其末尾添加记录
            appRunFile.WriteLine("[{0}] 当前连接的数据库为：{1}，{2}", DateTime.Now.ToString(), DataSource, DatabaseName);
            appRunFile.Close();
            //Step1 初始化数据库连接，并打开数据库连接
            connectionString = "Data Source=" + DataSource
                    + ";Initial Catalog=" + DatabaseName 
                    + ";Integrated Security=" + "true;";     //连接字符串
            //判断能否成功连接到数据库
            try
            {
                SqlConn.ConnectionString = connectionString;    //设置连接字符串
                SqlConn.Open(); //打开连接
            }
            catch(Exception e_OpenDB)
            {
                MessageBox.Show(e_OpenDB.Message, "连接到数据库异常");  //如果连接失败，弹出信息框
                return;
            }
            
            //Step2 激活一系列的控件
            this.treeView_DataBase.Enabled = true;        //激活树视图
            this.tabControl_ShowTables.Enabled = true;  //激活表显示窗口
            this.开启自动更新ToolStripMenuItem.Enabled = true;    //激活自动更新菜单项
            this.toolStripButton_StartUpdate.Enabled = true;    //激活开始自动更新工具栏

            //Step3 读取数据库中存在的所有表
            SqlCmd = new SqlCommand("select * from sys.tables", SqlConn);   //初始化，并且设置CommandText，选择数据库中所有的表的名称
            SqlDataReader reader = SqlCmd.ExecuteReader();  //执行SQL语句，将查找的返回值保存在reader中
            List<string> tablesname = new List<string>();   //创建一个列表，用来保存查找的结果
            while (reader.Read())
            {
                tablesname.Add(reader[0].ToString());       //逐行读取reader，然后将结果添加到列表中
            }
            reader.Close(); //关闭读取容器

            //Step4 在treeView中显示所有的表的名称
            this.treeView_DataBase.Nodes.Clear();   //清除当前树视图中的所有节点
            TreeNode rootNode = new TreeNode();     //新创建一个节点，表示根节点
            rootNode.Name = DatabaseName;   //设置根节点的节点名称
            rootNode.Text = DatabaseName;   //设置根节点的显示文本
            foreach(string tablename in tablesname) //遍历已经检测到的数据库中所有的表
            {
                TreeNode leafNode = new TreeNode(); //创建叶子节点
                leafNode.Name = tablename;  //设置叶子节点的名称
                leafNode.Text = tablename;  //设置叶子节点的显示文本
                rootNode.Nodes.Add(leafNode); //将叶子节点添加到根节点中
            }
            this.treeView_DataBase.Nodes.Add(rootNode);//将根节点添加到树视图中
            this.treeView_DataBase.Invalidate();    //刷新树视图显示所有节点
            UpdateLeftPlots();      //刷新状态栏中的剩余停车数

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();   //然后注销所有资源
        }

        

        /*********************以下为树视图控件中的消息响应实现********************************/
        /// <summary>显示数据
        /// 双击控件上相对应的节点时，在TabControl控件中的DataGridView显示表中的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeViewShowTable(object sender, TreeNodeMouseClickEventArgs e)
        {
            //判断选择的控件是否为空 或者选择的是根节点
            if (this.treeView_DataBase.SelectedNode == null || this.treeView_DataBase.SelectedNode == this.treeView_DataBase.Nodes[0])
                return;
            string tablename = this.treeView_DataBase.SelectedNode.Text;    //获取选择的节点的显示文本
            SqlCmd = new SqlCommand("select * from " + tablename, SqlConn); //初始化一个SQL语句，从数据库中查找出该表中的所有记录
            SqlData.SelectCommand = SqlCmd;     //将查询语句复制给SQL数据适配器，得到执行结果数据集
            dataTable.Dispose();
            dataTable = new DataTable();
            SqlData.Fill(dataTable);    //将SQL执行结果填充到数据列表中
            this.dataGridView_tables.DataSource = dataTable;    //将数据列表与显示窗口相关联
            this.tabPage_Table.Text = tablename;    //设置显示窗口的文本为当前打开的表
            this.dataGridView_tables.Enabled = true;
            this.dataGridView_tables.Invalidate();  //刷新显示窗口
        }

        /***************************以下为编辑菜单下面的功能实现*********************************/
        /// <summary>更新数据库
        /// 选择更新文件路径，然后开辟一个进程来后台处理文件
        /// 然后进行数据库更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开启自动更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //step1 弹出对话框，选择更新文件所在的路径
            string folderpath = "";
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = Application.StartupPath;
            folder.Description = "请选择文件夹路径";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                folderpath = folder.SelectedPath;
            }
            else
                return;

            //step2 将开始更新菜单设置成不可用，并将停止更新菜单设置成可用
            this.停止自动更新ToolStripMenuItem.Enabled = true;
            this.开启自动更新ToolStripMenuItem.Enabled = false;
            this.toolStripButton_stopUpdate.Enabled = true; //激活停止自动更新工具栏
            this.toolStripButton_StartUpdate.Enabled = false;   //使开启自动更新工具栏不可用
            this.自动更新程序状态toolStripStatusLabel.Text = "自动更新程序状态：开启";

            //step3 开始更新，开辟一个新的线程来后台自动更新数据库，并将结果刷新显示
            try
            {
                thread_refreshDB = new Thread(new ParameterizedThreadStart(RefreshDB));
                thread_refreshDB.Name = "后台自动刷新数据库";
                thread_refreshDB.Start(folderpath);
                MessageBox.Show("已经开始对数据库的自动更新操作!!\n时间间隔为：5分钟", "通知");
            }
            catch (Exception e_refresh)
            {
                MessageBox.Show(e_refresh.Message);
            }

        }

        /// <summary> 根据文件更新数据库
        /// 内部函数 输入文件夹路径 更具文件夹路径
        /// 遍历文件夹中的所有txt文件然后更新数据库
        /// </summary>
        /// <param name="path"></param>
        private void RefreshDB(Object path)
        {
            //补充1 添加运行日志文件，保存更新程序运行时的进行情况
            appRunFile = new StreamWriter("运行日志.txt", true, Encoding.Unicode);
            appRunFile.WriteLine("[{0}] 自动更新程序已经开启，已经选择的更新文件夹路径：{1}", DateTime.Now.ToString(), path);   //将更新文件夹路径写入日志文件

            //开始读取文件下面的所有txt文件，然后对数据库进行修改
            string folderpath = path as string;
            try
            {
                while (true)
                {
                    string[] filenames = Directory.GetFiles(folderpath, "*.txt", SearchOption.TopDirectoryOnly);
                    foreach (string filename in filenames)
                    {
                        StreamReader sreader = new StreamReader(filename, Encoding.ASCII);
                        string contexts = sreader.ReadToEnd();
                        //关闭文件
                        sreader.Close();
                        //校验文件格式，防止文件为空
                        if (contexts == null)
                        {
                            //MessageBox.Show("文件格式错误" + "\n自动更新模块即将停止", "错误");
                            appRunFile.WriteLine("[{0}] 文件格式错误", DateTime.Now.ToString());
                            StopThread();
                            return;
                        }
                        string[] lineArray = contexts.Split(new char[]{'\n'}, StringSplitOptions.RemoveEmptyEntries);
                        appRunFile.WriteLine("[{0}] 当前选择的更新文件名：{1}", DateTime.Now.ToString(), filename);
                        
                        char[] split_c = { '\t' };    //定义分隔符
                        string tabblename = lineArray[0]; //首先将首行读取出来,获得更新的表的名称
                        
                        //
                        for (int i = 1; i < lineArray.Length; i++ )
                        {
                            //将文件数据分离成单独的数据项
                            string[] data_cob = lineArray[i].Split(split_c, StringSplitOptions.RemoveEmptyEntries);
                            //校验文件格式
                            if (data_cob.Length != 2)
                            {
                                //MessageBox.Show("文件格式错误" + "\n自动更新模块即将停止", "错误");
                                appRunFile.WriteLine("[{0}] 文件格式错误", DateTime.Now.ToString());
                                StopThread();
                                return;
                            }
                            string PositionID = data_cob[0];
                            int state = int.Parse(data_cob[1]);
                            //利用SQL语句更新数据库
                            string SQLString = "update ParkingPlotsState set state=" + state.ToString()
                                + " where PositionID='" + PositionID + "'";
                            SqlCmd = new SqlCommand(SQLString, SqlConn);
                            try
                            {
                                if (SqlCmd.ExecuteNonQuery() == 0)
                                {//说明数据库中不存在该记录，应当插入该记录
                                    //设置新的SQL语句
                                    SQLString = "insert into ParkingPlotsState values('" + PositionID + "', " + state + ");";
                                    SqlCmd.CommandText = SQLString;
                                    SqlCmd.ExecuteNonQuery();   //执行SQL语句
                                }
                            }
                            catch (Exception e_SQLcmd)
                            {
                                //如果数据库操作失败，则通知用户，同时还将编辑菜单开始设置成激活，停止设置成不可用
                                //MessageBox.Show(e_SQLcmd.Message + "\n自动更新模块即将停止", "读数据库操作失败");
                                appRunFile.WriteLine("[{0}] 读数据库操作失败：{1}", DateTime.Now.ToString(), e_SQLcmd.Message);
                                StopThread();
                            }
                        }//对单个文件一行一行读取并修改数据库结束
                        
                        //return;
                    }//对所有文件读取结束
                    appRunFile.WriteLine("[{0}] 对所有文件读取结束", DateTime.Now.ToString());

                    //在显示控件中显示更新后的数据库数据
                    //采用Invoke方式，使得在其他线程中访问主线程中的控件
                    this.Invoke(new Action(delegate()
                    {
                        if (this.tabPage_Table.Text.Equals("表名"))
                            return;
                        RefreshGridView();  //将更新之后的数据库显示出来
                    }));
                    //MessageBox.Show("从文件更新数据库成功");
                    //暂停当前线程5分钟
                    appRunFile.WriteLine("[{0}] 暂停当前线程5分钟", DateTime.Now.ToString());
                    Thread.Sleep(1000 * 1 * 1);
                }
            }
            catch (Exception e_refreshDB)
            {
                if (!e_refreshDB.Message.Equals("正在中止线程。"))
                {
                    if (appRunFile == null)
                    {
                        appRunFile = new StreamWriter("运行日志.txt", true, Encoding.Unicode);
                    }
                    appRunFile.WriteLine("[{0}] 更新据库操作失败：{1}", DateTime.Now.ToString(), e_refreshDB.Message);
                }
            }

            //appRunFile.Close();

        }

        /// <summary>停止当前线程 
        /// 同时还将编辑菜单开始设置成激活，停止设置成不可用
        /// </summary>
        private void StopThread()
        {
            this.Invoke(new Action(delegate()
            {
                this.开启自动更新ToolStripMenuItem.Enabled = true;
                this.停止自动更新ToolStripMenuItem.Enabled = false;
                this.toolStripButton_stopUpdate.Enabled = false; //停止自动更新工具栏不可用
                this.toolStripButton_StartUpdate.Enabled = true;   //使开启自动更新工具栏可用
                this.自动更新程序状态toolStripStatusLabel.Text = "自动更新程序状态：异常关闭";
            }));
            appRunFile.WriteLine("[{0}] 将停止自动更新程序", DateTime.Now.ToString());
            appRunFile.Close();
            thread_refreshDB.Abort();
        }

        private void 停止自动更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //结束自动更新数据库的线程
                appRunFile.WriteLine("[{0}] 将停止自动更新程序", DateTime.Now.ToString());
                appRunFile.Close();
                thread_refreshDB.Abort();
                this.开启自动更新ToolStripMenuItem.Enabled = true;
                this.停止自动更新ToolStripMenuItem.Enabled = false;
                this.toolStripButton_stopUpdate.Enabled = false;    //使停止自动更新工具栏不可用
                this.toolStripButton_StartUpdate.Enabled = true;   //使开启自动更新工具栏可用
                this.自动更新程序状态toolStripStatusLabel.Text = "自动更新程序状态：正常关闭";
                MessageBox.Show("已经停止对数据库的自动更新操作", "通知");

            }
            catch (Exception e_stopRefresh)
            {
                MessageBox.Show(e_stopRefresh.Message);
            }
        }


        void ParkingDetect(Object path)
        {
            //step1 获得文件路径-->字符串
            string filepath = path as string; 
            //step2 创建进程 调用外部EXE，执行视频检测工作
            Process myprocess = new Process();
            myprocess.StartInfo.FileName = @"CheckParking.exe"; //设置外部EXE名称
            char[] split_s = {'\\'};
            myprocess.StartInfo.Arguments = filepath + @" ParkingInfo\" + filepath.Split(split_s).Last() + ".txt";   //设置外部EXE所需的参数
            myprocess.StartInfo.UseShellExecute = false;    //取消DOS界面
            myprocess.StartInfo.CreateNoWindow = true;  //取消窗体
            myprocess.Start();  //开始进程
            myprocess.WaitForExit();    //等待进程执行结束
            //step3 检测线程列表中的所有项，如果有与当前线程名称一致的，则停止线程，并从线程列表中移除
            for (int i = 0; i < Thread_list.Count; i++ )
            {
                if (Thread_list[i].Name.Equals(filepath))
                {
                    Thread td = Thread_list[i];
                    Thread_list.RemoveAt(i);
                    i--;
                    this.Invoke(new Action(delegate()
                    {
                        //设置状态栏中线程数
                        this.toolStripStatusLabel_LeftPlotsCount.Text = "视频更新状态：" + Thread_list.Count.ToString();
                    }));
                    td.Abort();
                }
            }
        }
        /*************************对DataGridView弹出菜单消息响应*****************************/
        /// <summary>将GridView中的数据保存到数据库中
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保存到数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //将当前显示窗口中的表更新到数据库中，如果成功这通知用户成功
                SqlCommandBuilder SCB = new SqlCommandBuilder(SqlData);
                SqlData.Update(dataTable);
                MessageBox.Show("保存成功", "通知");
                UpdateLeftPlots();
            }
            catch (Exception e_update)
            {
                //如果更新过程中出现了异常，通知用户
                MessageBox.Show(e_update.Message, "更新数据库异常");
            }
        }

        /// <summary>从DataGridView中删除选中的某些行
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_delete_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow deleterow in this.dataGridView_tables.SelectedRows) //遍历选中的行
            {
                this.dataGridView_tables.Rows.Remove(deleterow);    //将这些行从视图中移除
            }
            this.dataGridView_tables.Invalidate();  //刷新视图
        }

        private void 从数据库属性列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGridView();
        }

        /// <summary>更新视图
        /// 从数据库中读取数据，然后刷新显示在GridView中，前提是GridView中已经存在数据
        /// </summary>
        private void RefreshGridView()
        {
            string tablename = this.tabPage_Table.Text;    //获取当前显示表格的文本，其对应的表应当从数据库刷新
            SqlCmd = new SqlCommand("select * from " + tablename, SqlConn); //初始化一个SQL语句，从数据库中查找出该表中的所有记录
            SqlData.SelectCommand = SqlCmd;     //将查询语句复制给SQL数据适配器，得到执行结果数据集
            dataTable.Dispose();
            dataTable = new DataTable();
            SqlData.Fill(dataTable);    //将SQL执行结果填充到数据列表中
            this.dataGridView_tables.DataSource = dataTable;    //将数据列表与显示窗口相关联
            this.dataGridView_tables.Invalidate();  //刷新显示窗口

            UpdateLeftPlots();
            
        }

        /// <summary>
        /// 更新状态栏中的剩余停车位的数量
        /// </summary>
        private void UpdateLeftPlots()
        {
            SqlCommand sql_AllCount = new SqlCommand("select count(*) from ParkingPlotsState", SqlConn);
            SqlCommand sql_count = new SqlCommand("select count(*) from ParkingPlotsState where state=1", SqlConn);
            int AllCounts = (int)sql_AllCount.ExecuteScalar();
            int leftCounts = (int)sql_count.ExecuteScalar();
            this.toolStripStatusLabel_LeftPlotsCount.Text = "空闲车位数：" + leftCounts + "/" + AllCounts;
        }
        /******************************以下是对工具栏中的功能响应***********************************/
        /// <summary>连接数据库
        /// 与文件菜单下面的连接功能一样
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_connection_Click(object sender, EventArgs e)
        {
            //调用文件菜单下面的连接功能
            this.连接到数据库ToolStripMenuItem_Click(sender, e);
        }

        /// <summary> 开启自动更新
        /// 与编辑菜单下面的 开启自动更新一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_StartUpdate_Click(object sender, EventArgs e)
        {
            this.开启自动更新ToolStripMenuItem_Click(sender, e);
        }

        /// <summary>停止自动更新
        /// 与编辑菜单下面的 停止自动更新一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_stopUpdate_Click(object sender, EventArgs e)
        {
            this.停止自动更新ToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// 将本地数据库中的数据上传到服务器端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断选择的控件是否为空 或者选择的是根节点
            if (this.treeView_DataBase.SelectedNode == null || this.treeView_DataBase.SelectedNode.Text.Equals(SqlConn.Database))
            {
                MessageBox.Show("请首先选择一张表");
                return;
            }
            string tablename = this.treeView_DataBase.SelectedNode.Text;    //获取选择的节点的显示文本
            SqlCmd = new SqlCommand("select * from " + tablename, SqlConn); //初始化一个SQL语句，从数据库中查找出该表中的所有记录
            SqlData.SelectCommand = SqlCmd;     //将查询语句复制给SQL数据适配器，得到执行结果数据集
            DataTable dt = new DataTable(tablename);
            SqlData.Fill(dt);    //将SQL执行结果填充到数据列表中
            dt.WriteXml("H:\\1.xml");
            

            //DBConnection();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
            //string strcmd = "";
            //int nCount = dt.Columns.Count;
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    if (dc.DataType.Name.Equals("String"))
            //    {
            //        strcmd += dc.ColumnName.ToString() + " nchar(10),";
            //    }
            //    else
            //    {
            //        strcmd += dc.ColumnName.ToString() + " " + dc.DataType.Name + ",";
            //    }
            //}
            //cmd.CommandText = string.Format("create table {0}({1});", dt.TableName, strcmd);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            //UserClient user = new UserClient();
            //if (user.WriteXml(dt))
            //{
            //    MessageBox.Show("OK");
            //}
        }
        SqlConnection conn;
        private bool DBConnection()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=MINGMING-PC\LMZWHUDB;Initial Catalog=WebCollection;Integrated Security=true;";
                conn.Open();
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }

        private void 到屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand sql_A = new SqlCommand("select count(*) from View_Camera_Position where state=0 and DomainID='A'", SqlConn);
            //SqlCommand sql_B = new SqlCommand("select count(*) from View_Camera_Position where state=0 and DomainID='B'", SqlConn);
            string A = sql_A.ExecuteScalar().ToString();
            //string B = sql_B.ExecuteScalar().ToString();
            ListViewItem newitem_A = new ListViewItem(new string[] {"A",  A});
            //ListViewItem newitem_B = new ListViewItem(new string[] { "B", B });
            List<ListViewItem> items = new List<ListViewItem>();
            items.Add(newitem_A);
            //items.Add(newitem_B);

            ShowInfo showinfo = new ShowInfo(items);
            showinfo.Show();
        }

        //--------------------帮助菜单栏-------------------------------//

        /// <summary>
        /// 弹出对话框，显示系统的相关信息，版本号，开发人员，所有权……
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abort abortsys = new Abort();
            abortsys.ShowDialog();
        }

        private void 开启视频检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoCheckSys == null || autoCheckSys.IsDisposed)
            {
                autoCheckSys = new Form_AutoChecksys();
            }
            autoCheckSys.Show();
            autoCheckSys.Activate();

            return;
        }

        private void toolStripButton_ShowParkInfo_Click(object sender, EventArgs e)
        {
            //如果数据库尚未连接，则不进行任何操作
            if (SqlConn == null || SqlConn.State != ConnectionState.Open)
            {
                return;
            }
            
            if (!AddTabPage("tabPage_ParkInfo", "停车位详细信息"))
            {
                return;
            }

            //向DataGridView添加数据
            Thread refreshDGV_ParkInfo = new Thread(RefreshDGV_ParkInfo);
            refreshDGV_ParkInfo.Name = "更新显示停车位详细信息";
            refreshDGV_ParkInfo.Start("select * from View_Camera_Position # tabPage_ParkInfo");
            Thread_list.Add(refreshDGV_ParkInfo);


        }

        /// <summary>
        /// 封装构造TabPage 并向其中添加DataGridView方法
        /// </summary>
        /// <param name="name">TabPage的名称</param>
        /// <param name="text">TabPage的显示的文本</param>
        private bool AddTabPage(string name, string text)
        {
            //保证只会添加一次tabpage控件
            foreach (Control controls in this.tabControl_ShowTables.Controls)
            {
                if (controls.Name.Equals(name))
                {
                    this.tabControl_ShowTables.SelectTab(controls.Name);
                    return false;
                }
            }
            //创建一个tabPage来显示停车位的详细信息
            TabPage tabPage_ParkInfo = new TabPage();
            tabPage_ParkInfo.Location = new System.Drawing.Point(4, 22);
            tabPage_ParkInfo.Name = name;
            tabPage_ParkInfo.Padding = new System.Windows.Forms.Padding(3);
            tabPage_ParkInfo.Size = new System.Drawing.Size(470, 288);
            tabPage_ParkInfo.TabIndex = 1;
            tabPage_ParkInfo.Text = text;
            tabPage_ParkInfo.UseVisualStyleBackColor = true;

            //////////////////////////////////////////////////////////////////////////
            DataGridViewCellStyle DGVCellStyle = new DataGridViewCellStyle();
            DGVCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGVCellStyle.BackColor = Color.Silver;
            DGVCellStyle.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            DGVCellStyle.ForeColor = SystemColors.ControlText;
            DGVCellStyle.SelectionBackColor = SystemColors.Highlight;
            DGVCellStyle.SelectionForeColor = SystemColors.HighlightText;
            DGVCellStyle.WrapMode = DataGridViewTriState.False;

            //为tabpage添加一个DataGridView，用来存储和显示停车位详细信息
            DataGridView DGV_ParkInfo = new DataGridView();
            DGV_ParkInfo.AllowUserToAddRows = false;
            DGV_ParkInfo.AllowUserToDeleteRows = false;
            DGV_ParkInfo.ReadOnly = true;
            DGV_ParkInfo.DefaultCellStyle = DGVCellStyle;
            DGV_ParkInfo.BackgroundColor = System.Drawing.Color.LightGray;
            DGV_ParkInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DGV_ParkInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //DGV_ParkInfo.ContextMenuStrip = this.contextMenuStrip_InGridView;
            DGV_ParkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            DGV_ParkInfo.Enabled = true;
            DGV_ParkInfo.GridColor = System.Drawing.SystemColors.ActiveCaption;
            DGV_ParkInfo.Location = new System.Drawing.Point(3, 3);
            DGV_ParkInfo.Name = "dataGridView_tables";
            DGV_ParkInfo.RowTemplate.Height = 23;
            DGV_ParkInfo.Size = new System.Drawing.Size(464, 282);

            DGV_ParkInfo.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_tables_RowPostPaint);

            tabPage_ParkInfo.Controls.Add(DGV_ParkInfo);
            this.tabControl_ShowTables.Controls.Add(tabPage_ParkInfo);
            this.tabControl_ShowTables.SelectTab(tabPage_ParkInfo.Name);

            return true;
        }

        void DGV_ParkInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        void RefreshDGV_ParkInfo(object parameters)
        {
            string[] parameter = (parameters as string).Split(new char[] { '#' }, 3);
            SqlConnection sConnection = new SqlConnection(connectionString);
            sConnection.Open();
            while (true)
            {
                SqlDataAdapter sDAdapter = new SqlDataAdapter(parameter[0], sConnection); //将查询语句复制给SQL数据适配器，得到执行结果数据集
                DataTable DTable = new DataTable("ParkInfo");
                sDAdapter.Fill(DTable);    //将SQL执行结果填充到数据列表中
                sDAdapter.Dispose();
                
                this.Invoke(new Action(delegate()
                {
                    //
                    (this.tabControl_ShowTables.Controls.Find(parameter[1].Trim(), false)[0].Controls[0] as DataGridView).DataSource = DTable;//将数据列表与显示窗口相关联
                    this.tabControl_ShowTables.Invalidate();  //刷新显示窗口
                }));
                DTable.Dispose();
                Thread.Sleep(500);

                if (stop_refresh_screen || parameter[0].Equals(stopcmd))
                {
                    break;
                }
            }
            sConnection.Close();
                        
        }

        private void toolStripButton_Choose_Click(object sender, EventArgs e)
        {
            //如果数据库尚未连接，则不进行任何操作
            if (SqlConn == null || SqlConn.State != ConnectionState.Open)
            {
                return;
            }

            string tabpage_text = "";
            string cmd = "";
            if (this.toolStripComboBox_FindCondition.SelectedIndex == 0)
            {
                tabpage_text = "空闲车位信息";
                cmd = "select * from View_Camera_Position where state = 0";
                if (stopcmd == "select * from View_Camera_Position where state = 1")
                {
                    return;
                }
                stopcmd = "select * from View_Camera_Position where state = 1";
            }
            else if (this.toolStripComboBox_FindCondition.SelectedIndex == 1)
            {
                tabpage_text = "被占用车位信息";
                cmd = "select * from View_Camera_Position where state = 1";
                if (stopcmd == "select * from View_Camera_Position where state = 0")
                {
                    return;
                }
                stopcmd = "select * from View_Camera_Position where state = 0";
            }
            else
            {
                return;
            }

            if (!AddTabPage("tabPage_Choose", tabpage_text))
            {
                this.tabControl_ShowTables.Controls.Find("tabPage_Choose", false)[0].Text = tabpage_text;
            }

            //利用线程自动更新，向DataGridView添加数据
            Thread refreshDGV_ParkInfo = new Thread(RefreshDGV_ParkInfo);
            refreshDGV_ParkInfo.Name = "更新显示选择的停车位详细信息";
            refreshDGV_ParkInfo.Start(cmd + "# tabPage_Choose");
            Thread_list.Add(refreshDGV_ParkInfo);

        }

        private void 停止刷新界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.停止刷新界面ToolStripMenuItem.Text.Equals("停止刷新界面"))
            {
                stop_refresh_screen = true;
                this.停止刷新界面ToolStripMenuItem.Text = "开始刷新界面";
            }
            else
            {
                stop_refresh_screen = false;
                this.停止刷新界面ToolStripMenuItem.Text = "停止刷新界面";
            }
        }

        private void dataGridView_tables_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers  
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);  
        }

        private void 条件查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConditionalChoose ChooseForm = new ConditionalChoose(connectionString);
            if (ChooseForm.ShowDialog() != DialogResult.OK)
            {
                
            }
            ;
        }

        private void toolStripButton_条件查询_Click(object sender, EventArgs e)
        {
            this.条件查询ToolStripMenuItem_Click(sender, e);
        }
    }
}
