using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPTestFramework
{
    public partial class Form1 : Form
    {
        readonly Communication updater = Communication.Instance;
        readonly Stopwatch stopwatch = new Stopwatch();
        readonly List<Label> labels1 = new List<Label>();
        readonly List<Label> labels2 = new List<Label>();
        //readonly Random random = new Random();
        private bool isConnected;
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                if (isConnected)
                    InvokeOnThread(LB_IsConnected, new Action(() => LB_IsConnected.BackColor = Color.Green));
                else
                    InvokeOnThread(LB_IsConnected, new Action(() => LB_IsConnected.BackColor = Color.Yellow));
            }
        }
        bool isUpdate = false;
        string[] variableNames;

        public Form1()
        {
            InitializeComponent();
            
            try
            {
                if (!IsConnected)
                {
                    updater.Compolet.Open();
                    //MessageBox.Show("打开了端口", "打开端口");
                    IsConnected = true;
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                MessageBox.Show(ex.Message, "打开端口");
            }

            CB_VariableNameList.Items.Add(nameof(updater.PlcOutIOName));
            CB_VariableNameList.Items.Add(nameof(updater.PlcOutLocationName));
            CB_VariableNameList.Items.Add(nameof(updater.PlcOutAlarmName));
            CB_VariableNameList.Items.Add(nameof(updater.PlcInPmtName));
            CB_VariableNameList.Items.Add(nameof(updater.PLC标志位Name));
            CB_VariableNameList.Items.Add(nameof(updater.PLC测试信息Name));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataUpdate();
            //Type type = typeof(bool);
            //MethodInfo method = type.GetMethod("InterfaceUpdate");
            //MethodInfo runner = method.MakeGenericMethod(typeof(bool));
            //runner.Invoke(this, new object[] { variableNames });
        }

        #region 界面更新方法
        public static void InvokeOnThread(Control control, Action method)
        {
            if (control.IsHandleCreated)
            {
                control.Invoke(method);
            }
            else
            {
                method();
            }
        }
        /// <summary>
        /// 得到一个矩形阵列的坐标
        /// </summary>
        /// <param name="x">阵列起始X坐标</param>
        /// <param name="y">阵列起始Y坐标</param>
        /// <param name="count">阵列元素个数</param>
        /// <param name="length">每行的元素个数</param>
        /// <param name="xInterval">阵列坐标x方向间距</param>
        /// <param name="yInterval">阵列坐标y方向间距</param>
        /// <returns>阵列坐标列表</returns>
        public static List<Point> SetLocation(int x, int y, int count, int length, int xInterval, int yInterval)
        {
            int o = x;
            List<Point> locationList = new List<Point>();
            for (int i = 0; i < count; i++)
            {
                locationList.Add(new Point(x, y));
                x = x + xInterval;
                if ((i + 1) % length == 0)
                {
                    x = o;
                    y = y + yInterval;
                }
            }
            return locationList;
        }

        public void DataUpdate()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(500);
                        updater.RefreshData();
                    }
                    catch (Exception)
                    {
                        //logfile.Writelog($"PLC读取数据。{e.Message}", "更新数据记录");
                    }
                }
            });
        }

        public void InitializeDisplayLabel(Control control, int labelCount, List<Label> labels1, List<Label> labels2)
        {
            control.Controls.Clear();
            labels1.Clear();
            labels2.Clear();
            List<Point> points = SetLocation(10, 10, labelCount, 9, 120, 50);
            for (int i = 0; i < labelCount; i++)
            {
                labels1.Add(new Label() { Width = 120, Location = points[i] });
            }
            foreach (var item in labels1)
            {
                control.Controls.Add(item);
            }
            for (int i = 0; i < labelCount; i++)
            {
                labels2.Add(new Label() { Width = 120, Location = new Point(points[i].X, points[i].Y + 25) });
            }
            foreach (var item in labels2)
            {
                control.Controls.Add(item);
            }
        }

        public void InterfaceUpdate(string[] variableNames)
        {
            while (isUpdate)
            {
                try
                {
                    stopwatch.Restart();
                    Thread.Sleep(100);
                    ShowData(updater.Compolet.ReadVariablesKeyArray(variableNames), labels1);
                    ShowData(updater.Compolet.ReadVariablesValueArray(variableNames), labels2);
                    stopwatch.Stop();
                    InvokeOnThread(LB_Interval, new Action(() => LB_Interval.Text = $"{stopwatch.ElapsedMilliseconds}ms"));
                }
                catch (Exception e)
                {
                    InvokeOnThread(LB_Interval, new Action(() => LB_Interval.Text = e.Message));
                }
            }
        }

        public void ShowData<T>(T[] array, List<Label> labels)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length; i++)
                labels[i].Invoke(new Action(() => labels[i].Text = array[i].ToString()));
        }

        public void ShowData(object[] array, List<Label> labels)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length; i++)
                labels[i].Invoke(new Action(() => labels[i].Text = array[i].ToString()));
        }
        #endregion

        private void BTN_连接_Click(object sender, EventArgs e)
        {
            //打开通信端口
            try
            {
                if (IsConnected) return;
                updater.Compolet.Open();
                IsConnected = true;
                MessageBox.Show("打开了端口", "打开端口");
            }
            catch (Exception ex)
            {
                IsConnected = false;
                MessageBox.Show(ex.Message, "打开端口");
            }
        }

        private void BTN_断开_Click(object sender, EventArgs e)
        {
            //关闭通信端口
            try
            {
                updater.Compolet.Close();
                IsConnected = false;
                MessageBox.Show("关闭了端口", "打开端口");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "关闭端口");
            }
        }

        private void CB_VariableNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            variableNames = (string[])updater.GetType().GetField(CB_VariableNameList.Text).GetValue(updater);
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (variableNames == null) return;
                InitializeDisplayLabel(PN_Data, variableNames.Length, labels1, labels2);
                isUpdate = true;
                Task.Run(() => InterfaceUpdate(variableNames));
                //switch (CB_VariableNameList.Text)
                //{
                //    case nameof(updater.PlcOutIOName):
                //        Task.Run(() => InterfaceUpdate<bool>(variableNames));
                //        break;
                //    case nameof(updater.PlcOutLocationName):
                //        Task.Run(() => InterfaceUpdate<double>(variableNames));
                //        break;
                //    case nameof(updater.PlcOutAlarmName):
                //        Task.Run(() => InterfaceUpdate<bool>(variableNames));
                //        break;
                //    case nameof(updater.PlcInPmtName):
                //        Task.Run(() => InterfaceUpdate<double>(variableNames));
                //        break;
                //    case nameof(updater.PLC标志位Name):
                //        Task.Run(() => InterfaceUpdate<bool>(variableNames));
                //        break;
                //    case nameof(updater.PLC测试信息Name):
                //        Task.Run(() => InterfaceUpdate<string>(variableNames));
                //        break;
                //    default:
                //        variableNames = null;
                //        break;
                //}
                BTN_Start.Enabled = false;
                BTN_Stop.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                isUpdate = false;
                PN_Data.Controls.Clear();
                BTN_Start.Enabled = true;
                BTN_Stop.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void BTN_数据写入_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_VariableIndex.Text == "") return;
                if (TB_Variable.Text == "") return;
                string variableName = CB_VariableNameList.Text.Replace("Name", "");
                switch (CB_VariableNameList.Text)
                {
                    case nameof(updater.PlcOutIOName):
                        if (TB_Variable.Text == "0")
                            updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", false);
                        if (TB_Variable.Text == "1")
                            updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", true);
                        break;
                    case nameof(updater.PlcOutLocationName):
                        updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", double.Parse(TB_Variable.Text));
                        break;
                    case nameof(updater.PlcOutAlarmName):
                        if (TB_Variable.Text == "0")
                            updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", false);
                        if (TB_Variable.Text == "1")
                            updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", true);
                        break;
                    case nameof(updater.PlcInPmtName):
                        updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", double.Parse(TB_Variable.Text));
                        break;
                    case nameof(updater.PLC标志位Name):
                        if (TB_Variable.Text == "0")
                            updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", false);
                        if (TB_Variable.Text == "1")
                            updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", true);
                        break;
                    case nameof(updater.PLC测试信息Name):
                        updater.Compolet.WriteVariable($"{variableName}[{TB_VariableIndex.Text}]", TB_Variable.Text);
                        break;
                    default:
                        variableNames = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入失败。" + ex.Message);
            }
        }
    }
}
