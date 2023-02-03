namespace CIPTestFramework
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PN_Data = new System.Windows.Forms.Panel();
            this.LB_Interval = new System.Windows.Forms.Label();
            this.GB_连接 = new System.Windows.Forms.GroupBox();
            this.BTN_断开 = new System.Windows.Forms.Button();
            this.BTN_连接 = new System.Windows.Forms.Button();
            this.BTN_数据写入 = new System.Windows.Forms.Button();
            this.CB_VariableNameList = new System.Windows.Forms.ComboBox();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.BTN_Stop = new System.Windows.Forms.Button();
            this.TB_VariableIndex = new System.Windows.Forms.TextBox();
            this.TB_Variable = new System.Windows.Forms.TextBox();
            this.GB_ReadData = new System.Windows.Forms.GroupBox();
            this.GB_WriteData = new System.Windows.Forms.GroupBox();
            this.LB_IsConnected = new System.Windows.Forms.Label();
            this.GB_连接.SuspendLayout();
            this.GB_ReadData.SuspendLayout();
            this.GB_WriteData.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_Data
            // 
            this.PN_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PN_Data.AutoScroll = true;
            this.PN_Data.Location = new System.Drawing.Point(2, 3);
            this.PN_Data.Name = "PN_Data";
            this.PN_Data.Size = new System.Drawing.Size(641, 444);
            this.PN_Data.TabIndex = 0;
            // 
            // LB_Interval
            // 
            this.LB_Interval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Interval.AutoSize = true;
            this.LB_Interval.Location = new System.Drawing.Point(2, 72);
            this.LB_Interval.Name = "LB_Interval";
            this.LB_Interval.Size = new System.Drawing.Size(17, 12);
            this.LB_Interval.TabIndex = 2;
            this.LB_Interval.Text = "ms";
            // 
            // GB_连接
            // 
            this.GB_连接.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_连接.Controls.Add(this.LB_IsConnected);
            this.GB_连接.Controls.Add(this.BTN_断开);
            this.GB_连接.Controls.Add(this.BTN_连接);
            this.GB_连接.Location = new System.Drawing.Point(649, 3);
            this.GB_连接.Name = "GB_连接";
            this.GB_连接.Size = new System.Drawing.Size(145, 84);
            this.GB_连接.TabIndex = 1;
            this.GB_连接.TabStop = false;
            this.GB_连接.Text = "连接";
            // 
            // BTN_断开
            // 
            this.BTN_断开.Location = new System.Drawing.Point(6, 49);
            this.BTN_断开.Name = "BTN_断开";
            this.BTN_断开.Size = new System.Drawing.Size(75, 23);
            this.BTN_断开.TabIndex = 1;
            this.BTN_断开.Text = "断开";
            this.BTN_断开.UseVisualStyleBackColor = true;
            this.BTN_断开.Click += new System.EventHandler(this.BTN_断开_Click);
            // 
            // BTN_连接
            // 
            this.BTN_连接.Location = new System.Drawing.Point(6, 20);
            this.BTN_连接.Name = "BTN_连接";
            this.BTN_连接.Size = new System.Drawing.Size(75, 23);
            this.BTN_连接.TabIndex = 0;
            this.BTN_连接.Text = "连接";
            this.BTN_连接.UseVisualStyleBackColor = true;
            this.BTN_连接.Click += new System.EventHandler(this.BTN_连接_Click);
            // 
            // BTN_数据写入
            // 
            this.BTN_数据写入.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_数据写入.Location = new System.Drawing.Point(77, 42);
            this.BTN_数据写入.Name = "BTN_数据写入";
            this.BTN_数据写入.Size = new System.Drawing.Size(65, 23);
            this.BTN_数据写入.TabIndex = 4;
            this.BTN_数据写入.Text = "数据写入";
            this.BTN_数据写入.UseVisualStyleBackColor = true;
            this.BTN_数据写入.Click += new System.EventHandler(this.BTN_数据写入_Click);
            // 
            // CB_VariableNameList
            // 
            this.CB_VariableNameList.Dock = System.Windows.Forms.DockStyle.Top;
            this.CB_VariableNameList.FormattingEnabled = true;
            this.CB_VariableNameList.Location = new System.Drawing.Point(3, 17);
            this.CB_VariableNameList.Name = "CB_VariableNameList";
            this.CB_VariableNameList.Size = new System.Drawing.Size(139, 20);
            this.CB_VariableNameList.TabIndex = 6;
            this.CB_VariableNameList.SelectedIndexChanged += new System.EventHandler(this.CB_VariableNameList_SelectedIndexChanged);
            // 
            // BTN_Start
            // 
            this.BTN_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Start.Location = new System.Drawing.Point(3, 43);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(65, 23);
            this.BTN_Start.TabIndex = 7;
            this.BTN_Start.Text = "开始";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // BTN_Stop
            // 
            this.BTN_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Stop.Enabled = false;
            this.BTN_Stop.Location = new System.Drawing.Point(77, 43);
            this.BTN_Stop.Name = "BTN_Stop";
            this.BTN_Stop.Size = new System.Drawing.Size(65, 23);
            this.BTN_Stop.TabIndex = 8;
            this.BTN_Stop.Text = "停止";
            this.BTN_Stop.UseVisualStyleBackColor = true;
            this.BTN_Stop.Click += new System.EventHandler(this.BTN_Stop_Click);
            // 
            // TB_VariableIndex
            // 
            this.TB_VariableIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_VariableIndex.Location = new System.Drawing.Point(3, 44);
            this.TB_VariableIndex.Name = "TB_VariableIndex";
            this.TB_VariableIndex.Size = new System.Drawing.Size(65, 21);
            this.TB_VariableIndex.TabIndex = 9;
            // 
            // TB_Variable
            // 
            this.TB_Variable.Dock = System.Windows.Forms.DockStyle.Top;
            this.TB_Variable.Location = new System.Drawing.Point(3, 17);
            this.TB_Variable.Name = "TB_Variable";
            this.TB_Variable.Size = new System.Drawing.Size(139, 21);
            this.TB_Variable.TabIndex = 10;
            // 
            // GB_ReadData
            // 
            this.GB_ReadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_ReadData.Controls.Add(this.CB_VariableNameList);
            this.GB_ReadData.Controls.Add(this.LB_Interval);
            this.GB_ReadData.Controls.Add(this.BTN_Start);
            this.GB_ReadData.Controls.Add(this.BTN_Stop);
            this.GB_ReadData.Location = new System.Drawing.Point(649, 93);
            this.GB_ReadData.Name = "GB_ReadData";
            this.GB_ReadData.Size = new System.Drawing.Size(145, 95);
            this.GB_ReadData.TabIndex = 11;
            this.GB_ReadData.TabStop = false;
            this.GB_ReadData.Text = "数据读取";
            // 
            // GB_WriteData
            // 
            this.GB_WriteData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_WriteData.Controls.Add(this.TB_Variable);
            this.GB_WriteData.Controls.Add(this.TB_VariableIndex);
            this.GB_WriteData.Controls.Add(this.BTN_数据写入);
            this.GB_WriteData.Location = new System.Drawing.Point(649, 194);
            this.GB_WriteData.Name = "GB_WriteData";
            this.GB_WriteData.Size = new System.Drawing.Size(145, 77);
            this.GB_WriteData.TabIndex = 0;
            this.GB_WriteData.TabStop = false;
            this.GB_WriteData.Text = "数据写入";
            // 
            // LB_IsConnected
            // 
            this.LB_IsConnected.AutoSize = true;
            this.LB_IsConnected.BackColor = System.Drawing.Color.Yellow;
            this.LB_IsConnected.Location = new System.Drawing.Point(98, 25);
            this.LB_IsConnected.Name = "LB_IsConnected";
            this.LB_IsConnected.Size = new System.Drawing.Size(23, 12);
            this.LB_IsConnected.TabIndex = 2;
            this.LB_IsConnected.Text = "   ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GB_ReadData);
            this.Controls.Add(this.GB_WriteData);
            this.Controls.Add(this.GB_连接);
            this.Controls.Add(this.PN_Data);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GB_连接.ResumeLayout(false);
            this.GB_连接.PerformLayout();
            this.GB_ReadData.ResumeLayout(false);
            this.GB_ReadData.PerformLayout();
            this.GB_WriteData.ResumeLayout(false);
            this.GB_WriteData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PN_Data;
        private System.Windows.Forms.GroupBox GB_连接;
        private System.Windows.Forms.Button BTN_断开;
        private System.Windows.Forms.Button BTN_连接;
        private System.Windows.Forms.Label LB_Interval;
        private System.Windows.Forms.Button BTN_数据写入;
        private System.Windows.Forms.ComboBox CB_VariableNameList;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.Button BTN_Stop;
        private System.Windows.Forms.TextBox TB_VariableIndex;
        private System.Windows.Forms.TextBox TB_Variable;
        private System.Windows.Forms.GroupBox GB_ReadData;
        private System.Windows.Forms.GroupBox GB_WriteData;
        private System.Windows.Forms.Label LB_IsConnected;
    }
}

