using CIPCommunication;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CIPTestFramework
{
    public class Communication
    {
        private static readonly Communication instance = new Communication();
        public static Communication Instance { get { return instance; } }
        public NJCompoletLibrary Compolet;
        readonly IComparer stringValueComparer = new StringValueComparer();
        public string Error;

        #region 要读取的变量名
        public readonly string[] PlcOutIOName;
        public readonly string[] PlcOutLocationName;
        public readonly string[] PlcOutAlarmName;
        public readonly string[] PlcInPmtName;
        public readonly string[] PLC标志位Name;
        public readonly string[] PLC测试信息Name;
        #endregion

        #region 读取到的哈希表
        public Hashtable PLCIO;
        public Hashtable Location;
        public Hashtable Alarm;
        public Hashtable PLCPmt;
        public Hashtable FlagBits;
        public Hashtable TestInformation;
        #endregion

        private Communication()
        {
            Compolet = new NJCompoletLibrary();
            #region 初始化变量
            //PLC Out IO
            PlcOutIOName = InitializeStringArray("PlcOutIO", 0, 162);
            PLCIO = InitializeHashtable<bool>(PlcOutIOName, false);
            //位置信息
            PlcOutLocationName = InitializeStringArray("PlcOutLocation", 0, 180);
            Location = InitializeHashtable<double>(PlcOutLocationName, 0);
            //报警信息
            PlcOutAlarmName = InitializeStringArray("PlcOutAlarm", 0, 174);
            Alarm = InitializeHashtable<bool>(PlcOutAlarmName, false);
            //参数信息
            PlcInPmtName = InitializeStringArray("PlcInPmt", 0, 34);
            PLCPmt = InitializeHashtable<double>(PlcInPmtName, 0);

            PLC标志位Name = InitializeStringArray("PLC标志位", 0, 2);
            FlagBits = InitializeHashtable<bool>(PLC标志位Name, false);

            PLC测试信息Name = InitializeStringArray("PLC测试信息", 0, 41);
            TestInformation = InitializeHashtable<string>(PLC测试信息Name, "noData");
            #endregion
        }

        public static string[] InitializeStringArray(string mainValue, int start, int end)
        {
            List<string> arrayList = new List<string>();
            for (int i = start; i <= end; i++)
                arrayList.Add($"{mainValue}[{i}]");
            return arrayList.ToArray();
        }

        public static Hashtable InitializeHashtable<T>(string[] key, T value)
        {
            if (key == null) return null;
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < key.Length; i++)
            {
                hashtable.Add(key[i], value);
            }
            return hashtable;
        }

        public void GetValue(Hashtable sourceTable, Hashtable targetTable)
        {
            foreach (DictionaryEntry keyValue in sourceTable)
            {
                if (targetTable.ContainsKey(keyValue.Key))
                    targetTable[keyValue.Key] = keyValue.Value;
            }
        }

        public void HashtableToArray<T>(Hashtable sourceTable, T[] array)
        {
            if (sourceTable == null) return;
            string[] keys = new string[sourceTable.Count];
            sourceTable.Keys.CopyTo(keys, 0);
            if (array == null || array.Length < sourceTable.Count)
            {
                array = new T[sourceTable.Count];
            }
            sourceTable.Values.CopyTo(array, 0);
            Array.Sort(keys, array, stringValueComparer);
        }

        public void RefreshData()
        {
            try
            {
                #region 方式一更新数据
                GetValue(Compolet.GetHashtable(PlcOutIOName), PLCIO);
                GetValue(Compolet.GetHashtable(PlcOutLocationName), Location);
                GetValue(Compolet.GetHashtable(PlcOutAlarmName), Alarm);
                GetValue(Compolet.GetHashtable(PlcInPmtName), PLCPmt);
                GetValue(Compolet.GetHashtable(PLC标志位Name), FlagBits);
                GetValue(Compolet.GetHashtable(PLC测试信息Name), TestInformation);
                #endregion

                #region 方式二更新数据
                //#region 读IO信息
                //PLCIO = Compolet.GetHashtable(plcOutIOName);
                //#endregion

                //#region 读位置信息
                //Location = Compolet.GetHashtable(plcOutLocationName);
                //#endregion

                //#region 读报警信息
                //Alarm = Compolet.GetHashtable(plcOutAlarmName);
                //#endregion

                //#region 读参数信息
                //PLCPmt = Compolet.GetHashtable(plcInPmtName);
                //#endregion
                #endregion

                #region 从PLC读取标志位
                //FlagBits = Compolet.GetHashtable(plcOutFlagName);
                //GetValue(Compolet.GetHashtable(plcOutFlagName), FlagBits);
                //托盘扫码完成
                //ReadFlagBits[0] = compolet.ReadVariableBool("PLC标志位[0]");
                //探测器测试完成
                //ReadFlagBits[1] = compolet.ReadVariableBool("PLC标志位[1]");
                //20个托盘已摆好
                //ReadFlagBits[2] = compolet.ReadVariableBool("PLC标志位[2]");
                #endregion

                #region 读取测试信息（字符串变量）
                //TestInformation = Compolet.GetHashtable(plcTestInfoName);
                //GetValue(Compolet.GetHashtable(plcTestInfoName), TestInformation);
                ////产品编码
                //ReadTestInformation[0] = compolet.ReadVariableString("PLC测试信息[0]");
                ////类型
                //ReadTestInformation[1] = compolet.ReadVariableString("PLC测试信息[1]");
                ////测试工位
                //ReadTestInformation[2] = compolet.ReadVariableString("PLC测试信息[2]");
                ////结果
                //ReadTestInformation[3] = compolet.ReadVariableString("PLC测试信息[3]");
                ////托盘编号
                //ReadTestInformation[4] = compolet.ReadVariableString("PLC测试信息[4]");
                ////托盘位置
                //ReadTestInformation[5] = compolet.ReadVariableString("PLC测试信息[5]");
                ////外观
                //ReadTestInformation[6] = compolet.ReadVariableString("PLC测试信息[6]");
                ////开始时间
                //ReadTestInformation[7] = compolet.ReadVariableString("PLC测试信息[7]");
                ////完成时间
                //ReadTestInformation[8] = compolet.ReadVariableString("PLC测试信息[8]");
                ////当前托盘索引
                //ReadTestInformation[20] = compolet.ReadVariableString("PLC测试信息[20]");
                ////良率
                //ReadTestInformation[21] = compolet.ReadVariableString("PLC测试信息[21]");
                ////探针次数
                //ReadTestInformation[22] = compolet.ReadVariableString("PLC测试信息[22]");
                ////当前控制器时间
                //ReadTestInformation[29] = compolet.ReadVariableString("PLC测试信息[29]");
                ////上视觉1扫码信息
                //ReadTestInformation[30] = compolet.ReadVariableString("PLC测试信息[30]");
                ////下视觉对位X
                //ReadTestInformation[32] = compolet.ReadVariableString("PLC测试信息[32]");
                ////下视觉对位Y
                //ReadTestInformation[33] = compolet.ReadVariableString("PLC测试信息[33]");
                ////下视觉对位θ
                //ReadTestInformation[34] = compolet.ReadVariableString("PLC测试信息[34]");
                ////上视觉2对位X
                //ReadTestInformation[36] = compolet.ReadVariableString("PLC测试信息[36]");
                ////上视觉2对位Y
                //ReadTestInformation[37] = compolet.ReadVariableString("PLC测试信息[37]");
                ////上视觉2对位θ
                //ReadTestInformation[38] = compolet.ReadVariableString("PLC测试信息[38]");
                ////计算对位X
                //ReadTestInformation[39] = compolet.ReadVariableString("PLC测试信息[39]");
                ////计算对位Y
                //ReadTestInformation[40] = compolet.ReadVariableString("PLC测试信息[40]");
                ////计算对位θ
                //ReadTestInformation[41] = compolet.ReadVariableString("PLC测试信息[41]");
                #endregion
            }
            catch (Exception ex)
            {
                this.Error = ex.ToString();
            }
        }

        public void WriteVariables<T>(T[] variableArray, string variableName, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Compolet.WriteVariable($"{variableName}[{i}]", variableArray[i]);
            }
        }

    }
}
