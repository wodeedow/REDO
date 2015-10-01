namespace REDO
{
    partial class MainWindow
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbLogFile = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbCommittedAffairs = new System.Windows.Forms.RichTextBox();
            this.rtbUncommittedAffairs = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbAvailableSubstring = new System.Windows.Forms.RichTextBox();
            this.rtbReWriteValue = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbRecordInLog = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbAllAffairs = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLogFile
            // 
            this.rtbLogFile.Location = new System.Drawing.Point(12, 46);
            this.rtbLogFile.Name = "rtbLogFile";
            this.rtbLogFile.Size = new System.Drawing.Size(135, 331);
            this.rtbLogFile.TabIndex = 0;
            this.rtbLogFile.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入REDO日志文件：";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(12, 398);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 2;
            this.btnCommit.Text = "提交";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "已提交的事务：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "未提交的事务：";
            // 
            // rtbCommittedAffairs
            // 
            this.rtbCommittedAffairs.Location = new System.Drawing.Point(431, 114);
            this.rtbCommittedAffairs.Name = "rtbCommittedAffairs";
            this.rtbCommittedAffairs.Size = new System.Drawing.Size(122, 63);
            this.rtbCommittedAffairs.TabIndex = 6;
            this.rtbCommittedAffairs.Text = "";
            // 
            // rtbUncommittedAffairs
            // 
            this.rtbUncommittedAffairs.Location = new System.Drawing.Point(430, 183);
            this.rtbUncommittedAffairs.Name = "rtbUncommittedAffairs";
            this.rtbUncommittedAffairs.Size = new System.Drawing.Size(122, 56);
            this.rtbUncommittedAffairs.TabIndex = 7;
            this.rtbUncommittedAffairs.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "有效日志记录：";
            // 
            // rtbAvailableSubstring
            // 
            this.rtbAvailableSubstring.Location = new System.Drawing.Point(177, 49);
            this.rtbAvailableSubstring.Name = "rtbAvailableSubstring";
            this.rtbAvailableSubstring.Size = new System.Drawing.Size(142, 328);
            this.rtbAvailableSubstring.TabIndex = 9;
            this.rtbAvailableSubstring.Text = "";
            // 
            // rtbReWriteValue
            // 
            this.rtbReWriteValue.Location = new System.Drawing.Point(1, 30);
            this.rtbReWriteValue.Name = "rtbReWriteValue";
            this.rtbReWriteValue.Size = new System.Drawing.Size(122, 71);
            this.rtbReWriteValue.TabIndex = 10;
            this.rtbReWriteValue.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "处理的结果：";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(174, 398);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.rtbRecordInLog);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.rtbReWriteValue);
            this.panel1.Location = new System.Drawing.Point(430, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 197);
            this.panel1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "重写已提交事务：";
            // 
            // rtbRecordInLog
            // 
            this.rtbRecordInLog.Location = new System.Drawing.Point(0, 135);
            this.rtbRecordInLog.Name = "rtbRecordInLog";
            this.rtbRecordInLog.Size = new System.Drawing.Size(122, 60);
            this.rtbRecordInLog.TabIndex = 12;
            this.rtbRecordInLog.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "在日志中显示：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "所有事务：";
            // 
            // rtbAllAffairs
            // 
            this.rtbAllAffairs.Location = new System.Drawing.Point(433, 23);
            this.rtbAllAffairs.Name = "rtbAllAffairs";
            this.rtbAllAffairs.Size = new System.Drawing.Size(122, 75);
            this.rtbAllAffairs.TabIndex = 16;
            this.rtbAllAffairs.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 460);
            this.Controls.Add(this.rtbAllAffairs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbAvailableSubstring);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbUncommittedAffairs);
            this.Controls.Add(this.rtbCommittedAffairs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbLogFile);
            this.Name = "MainWindow";
            this.Text = "基于REDO日志的非静止检查点恢复算法";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLogFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbCommittedAffairs;
        private System.Windows.Forms.RichTextBox rtbUncommittedAffairs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbAvailableSubstring;
        private System.Windows.Forms.RichTextBox rtbReWriteValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbRecordInLog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbAllAffairs;
    }
}

