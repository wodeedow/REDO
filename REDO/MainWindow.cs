using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace REDO
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {      
              string sWithBlankaSpace = EffectiveSubstring(); //将有效日志字符串最上方的空白行去掉
              rtbAvailableSubstring.Text = sWithBlankaSpace;
              outputAffairs();   //输出提交 未提交的事务
              logRecovery();     //日志恢复 
        }

        private void logRecovery() //恢复时完成的处理工作
        {
            string efstr =  rtbAvailableSubstring.Text;
            string commitAffairs = rtbCommittedAffairs.Text;
            string[] logstr = efstr.Split('\n');
            for (int i = 0; i < logstr.Length; i++) //logstr[i]为有效字符串中的每行日志
            {
                string parttern = @"<T[^>]+[0-9]>";//匹配以<开始，以>结束，>左边为数字的字符串
                Regex reg = new Regex(parttern);
                Match mat = reg.Match(logstr[i]);
                if (mat.Success)
                {
                    string right = @">";
                    Regex regRight = new Regex(right);
                    Match matRight = regRight.Match(logstr[i]);
                    if (matRight.Success)
                    {
                        int r = logstr[i].IndexOf(right, 0);
                        string rowLog = logstr[i].Substring(1, logstr[i].Length - 2); //rowLog存储<>中，三个字符串由两个“，”隔开的字符串，即已提交事务更新记录！
                        string[] commitRecordValue = rowLog.Split(',');
                        if (!rtbUncommittedAffairs.Text.Contains(commitRecordValue[0]))
                            rtbReWriteValue.Text = rtbReWriteValue.Text + (commitRecordValue[1] + "=" + commitRecordValue[2] + "\n");
                        else
                            rtbRecordInLog.Text = rtbRecordInLog.Text + ("<ABORT " + commitRecordValue[0] + ">" + "\n");
                   }
                }
            }
  
        }
        private void showAllAffairs(string Substring)//仅用于没有END CKPT的情况，为重复代码
        {
            ArrayList reverseAllAffairs = new ArrayList();
            ArrayList allaffairs = new ArrayList();
            string[] logstr = Substring.Split('\n');
            for (int i = 0; i < logstr.Length; i++) //logstr[i]为有效字符串中的每行日志
            {
                string parttern = @"<T[^>]+[0-9]>";//匹配以<开始，以>结束，>左边为数字的字符串
                Regex reg = new Regex(parttern);
                Match mat = reg.Match(logstr[i]);
                if (mat.Success)
                {
                    string affairs = logstr[i].Substring(1, 2);
                    allaffairs.Add(affairs);
                }
            }
            foreach (string ca in allaffairs)//将所有事务存入文本框中
            {
                if (!rtbAllAffairs.Text.Contains(ca))
                    rtbAllAffairs.Text += ca + "\n";
            }
            foreach (string ca in allaffairs)
            {
                if (!(ca == "KC"))
                {
                    reverseAllAffairs.Add(Reverse(ca));//reverseAllAffairs中存储所有事务的逆序
                }
            }
            for (int i = 0; i < reverseAllAffairs.Count; i++)
            {
                for (int j = i + 1; j < reverseAllAffairs.Count; j++)
                {
                    if (reverseAllAffairs[i].Equals(reverseAllAffairs[j]))
                    {
                        reverseAllAffairs.Remove(reverseAllAffairs[j]);
                    }
                }
            }
        }

        private string EffectiveSubstring()  //从所给的日志中找出需要处理（有效的）子字符串
        {

            string strLogFile = rtbLogFile.Text;
            string reverseLog = Reverse(strLogFile);
            string commitAboveStartCKPT = "TIMMOC";
            string rightSpaceMark = ">";

            string endCheckPoint = ">TPKC DNE<";
            string regComEnd = @endCheckPoint;
            Regex regEnd = new Regex(regComEnd);
            Match matEnd = regEnd.Match(reverseLog);  //在反转后的字符串中匹配<END CKPT>

            string startCheckPoint = "TPKC TRATS<";
            string regComSC = @startCheckPoint;
            Regex regSC = new Regex(regComSC);
            Match matSC = regSC.Match(reverseLog);   //在反转后的字符串中匹配<START CKPT>

            if (matEnd.Success && matSC.Success && (matEnd.Index < matSC.Index))  //既有START CKPT 又有END CKPT，往前搜索时，先搜索到END CKPT.
            {
                int n1, n2, n3;//待处理
                ArrayList allaffairs = new ArrayList();
                ArrayList reverseAllAffairs = new ArrayList();
                n1 = reverseLog.IndexOf(startCheckPoint, 0);    //+ startCheckPoint.Length检查点开始位置 
                string reverseSubstringLogBeforeStartCKPT = reverseLog.Substring((n1 + startCheckPoint.Length), (reverseLog.Length - n1 - startCheckPoint.Length));
                //取START CKPT之前（上面）的逆序字符串,在这个字符串中找出最下方的COMMIT字符串的Index,接着找从这个COMMIT下面一句开始，一直往下所有的子字符串
                n2 = reverseSubstringLogBeforeStartCKPT.IndexOf(commitAboveStartCKPT);
                string ApprochBeProcessedSubstringEndInEndCKPT1 = strLogFile.Substring(reverseSubstringLogBeforeStartCKPT.Length - n2, strLogFile.Length - reverseSubstringLogBeforeStartCKPT.Length + n2);
                //Index将空格包括在内，返回从0开始的第一个字符的位置
                n3 = ApprochBeProcessedSubstringEndInEndCKPT1.IndexOf(rightSpaceMark);  //ApprochBeProcessedSubstringEndInEndCKPT字符串中含有最下方的START CKPT上面第一个COMMIT与">"中间的多余的几个字符
                string BeProcessedSubstringEndInEndCKPT1 = ApprochBeProcessedSubstringEndInEndCKPT1.Substring(n3 + 1, ApprochBeProcessedSubstringEndInEndCKPT1.Length - n3 - 1);
                showAllAffairs(BeProcessedSubstringEndInEndCKPT1);
                string[] logstr = BeProcessedSubstringEndInEndCKPT1.Split('\n');
                for (int i = 0; i < logstr.Length; i++) //logstr[i]为有效字符串中的每行日志
                {
                    string parttern = @"<T[^>]+[0-9]>";//匹配以<开始，以>结束，>左边为数字的字符串
                    Regex reg = new Regex(parttern);
                    Match mat = reg.Match(logstr[i]);
                    if (mat.Success)
                    {
                        string affairs = logstr[i].Substring(1, 2);
                        allaffairs.Add(affairs);
                    }
                }
                foreach (string ca in allaffairs)//将所有事务存入文本框中
                {
                    if (!rtbAllAffairs.Text.Contains(ca))
                        rtbAllAffairs.Text += ca + "\n";
                }
                foreach (string ca in allaffairs)
                {
                    if (!(ca == "KC"))
                    {
                        reverseAllAffairs.Add(Reverse(ca));//reverseAllAffairs中存储所有事务的逆序
                    }
                }
                for (int i = 0; i < reverseAllAffairs.Count; i++)
                {
                    for (int j = i + 1; j < reverseAllAffairs.Count; j++)
                    {
                        if (reverseAllAffairs[i].Equals(reverseAllAffairs[j]))
                        {
                            reverseAllAffairs.Remove(reverseAllAffairs[j]);//
                        }
                    }
                }

                string af = rtbAllAffairs.Text;
                string logCommit = rtbLogFile.Text;
                string reLog = Reverse(logCommit);
                int[] t = new int[10];
                int l = 0;
                string regComStart = @"TRATS";
                Regex regStart = new Regex(regComStart);
                Match matStart = regStart.Match(reLog); //实例化待匹配的字符串
                string test = reLog;
                int startCKPT = 0;

                string regComStart1 = @"START CKPT";
                Regex regStart1 = new Regex(regComStart1);
                Match matStart1 = regStart1.Match(BeProcessedSubstringEndInEndCKPT1); //实例化待匹配的字符串
                while (matStart1.Success)
                {
                    startCKPT = startCKPT + 1;
                    matStart1 = matStart1.NextMatch();
                }
                foreach (string aa in reverseAllAffairs)
                {
                    l++;//也将START CKPT中的START换成了mmmmm
                }
                for (int m = 0; m < (l + startCKPT); m++)
                {
                    if (matStart.Success)
                    {
                        int index = test.IndexOf("TRATS");
                        if (index > -1)
                        {
                            test = test.Remove(index, 5).Insert(index, "mmmmm");//将STAART换成mmmmm
                        }
                    }
                }
                string partialLog = Reverse(test);
                string regmm = @"mmmmm";
                Regex regStartmm = new Regex(regmm);
                Match matStartmm = regStartmm.Match(partialLog); //实例化待匹配的字符串
                int pp = 0;

                if (matStartmm.Success)//执行5次
                {
                    pp = partialLog.IndexOf(regmm, 0);//从上至下求第一个mmmmm的位置
                }
              string  BeProcessedSubstringEndInEndCKPT = partialLog.Substring(pp - 1, partialLog.Length - pp + 1);//
                Match matStartm = regStartmm.Match(BeProcessedSubstringEndInEndCKPT);
                for (int m = 0; m < (l + startCKPT); m++)
                {
                    if (matStartm.Success)
                    {
                        int index = BeProcessedSubstringEndInEndCKPT.IndexOf("mmmmm");//将mmmmm换回成START
                        if (index > -1)
                        {
                            BeProcessedSubstringEndInEndCKPT = BeProcessedSubstringEndInEndCKPT.Remove(index, 5).Insert(index, "START");
                        }
                    }                
                }
             
                return BeProcessedSubstringEndInEndCKPT;
            }
            else if (matEnd.Success && matSC.Success && (matEnd.Index > matSC.Index))
            //既有START CKPT 又有END CKPT，往前搜索时，先搜索到START CKPT。这种情况有效字符串从倒数第二个START CKPT开始，假设检查点之间无其他检查点
            {
                int n4, n5, n6;
                n4 = reverseLog.IndexOf(startCheckPoint, 0);  //找出最下方的START CKPT的Index
                string reverseSubStringLogBeforeStartCKPT = reverseLog.Substring(n4 + startCheckPoint.Length, reverseLog.Length - n4 - startCheckPoint.Length);
                //MessageBox.Show(reverseSubStringLogBeforeStartCKPT);//排除最下方的START CKPT即下方的字符串的逆转字符串

                n5 = reverseSubStringLogBeforeStartCKPT.IndexOf(startCheckPoint, 0); //上面求出的子字符串中START CKPT的Index
                string ApprochBeProcessedSubstringEndInEndCKPT = reverseSubStringLogBeforeStartCKPT.Substring(n5 + 11, reverseSubStringLogBeforeStartCKPT.Length - n5 - 11);
                //MessageBox.Show(ApprochBeProcessedSubstringEndInEndCKPT);

                n6 = ApprochBeProcessedSubstringEndInEndCKPT.Length; //倒数第二个START CKPT上方的字符串的长度
                string BeProcessedSubstringEndInEndCKPT = strLogFile.Substring(n6, strLogFile.Length - n6);//总的LOG中排除倒数第二个START CKPT上面一部分
                showAllAffairs(BeProcessedSubstringEndInEndCKPT);
                return BeProcessedSubstringEndInEndCKPT;
            }
            else if (!matEnd.Success && matSC.Success)
            {
                return strLogFile;
            }
            else   //(!matSC.Success)
            {
                MessageBox.Show("输入日志格式不正确，请重新输入！");
                rtbLogFile.Text = null;
                return null;
            }
        }
        public static string Reverse(string str)  //字符串反转
        {
            if (string.IsNullOrEmpty(str))
            {
              MessageBox.Show("请输入日志信息！");
            }

            StringBuilder sb = new StringBuilder(str.Length);
            for (int index = str.Length - 1; index >= 0; index--)
            {
                sb.Append(str[index]);
            }
            return sb.ToString();
        }

        private void outputAffairs()  //输出已提交和未提交的事务
        {
            string strLogFile = rtbLogFile.Text;
            if (strLogFile != null)
            {
                ArrayList aa = affairsAll();
                ArrayList ac = deleteCommitAffairs();
                ArrayList au = affairsUnCommit();
                foreach (string ca in ac)
                {
                    rtbCommittedAffairs.Text = rtbCommittedAffairs.Text + ca + "\n";
                }
                foreach (string uca in au)
                {
                    rtbUncommittedAffairs.Text = rtbUncommittedAffairs.Text + uca + "\n";
                }
            }
        }

        private ArrayList affairsAll()  //所有事务
        {
            string beProcessedString = rtbAvailableSubstring.Text;
            string regComStart = @"START";
            string ck = "CK";
            Regex regStart = new Regex(regComStart);
            Match matStart = regStart.Match(beProcessedString); //实例化待匹配的字符串
            ArrayList allaffairs = new ArrayList();
            while (matStart.Success)  //当字符串中有匹配的字符时
            {

                string afstart = beProcessedString.Substring(matStart.Index + 6, 2);
                allaffairs.Add(afstart); //未提交的所有事务也存入affairs                           
                matStart = matStart.NextMatch();
            }
            for (int i = 0; i < allaffairs.Count; i++)
            {
                if (ck.Equals(allaffairs[i]))
                    allaffairs.Remove(allaffairs[i]);
            }
            return allaffairs;
        }
        private ArrayList affairsCommit()  //提交的事务
        {
            string beProcessedString = rtbAvailableSubstring.Text;
            ArrayList commitaffairs = new ArrayList();
            string regComCommit = @"COMMIT";
            Regex regCommit = new Regex(regComCommit);
            Match matCommit = regCommit.Match(beProcessedString); //实例化待匹配的字符串
            while (matCommit.Success)  //当字符串中有匹配的字符时
            {
                string afcommit = beProcessedString.Substring(matCommit.Index + 7, 2);
                commitaffairs.Add(afcommit); //未提交的所有事务也存入affairs                           
                matCommit = matCommit.NextMatch();
            }
                return commitaffairs;
        }

        private ArrayList affairsUnCommit()  //未提交的事务  
        {
            ArrayList uncommitaffairs = new ArrayList();
            ArrayList allaffairs = affairsAll();
            foreach (string ss in deleteCommitAffairs())//如果allaffairs中包括提交的事务，则将其删除
            {
                if (allaffairs.Contains(ss))
                {
                    allaffairs.Remove(ss);
                }               
            }
            uncommitaffairs = allaffairs;
            return uncommitaffairs;
        }
        private ArrayList deleteCommitAffairs()
        {
            ArrayList allaf = affairsAll();
            ArrayList affcom = affairsCommit();
            for (int i = 0; i < allaf.Count; i++)
            {
                for (int j = 0; j < affcom.Count; j++)
                {
                    if (!allaf.Contains(affcom[j]))
                        affcom.Remove(affcom[j]);//不能在foreach里遍历的时侯把它的元素进行删除或增加的操作的
                }
            }
            return affcom;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            rtbLogFile.Clear();
            rtbAvailableSubstring.Clear();
            rtbCommittedAffairs.Clear();
            rtbUncommittedAffairs.Clear();
            rtbReWriteValue.Clear();
            rtbRecordInLog.Clear();
            rtbAllAffairs.Clear();
        }

       
        #region
        private static string Search_String(string s, string s1, string s2)
        {
            int n1, n2;
            n1 = s.IndexOf(s1, 0) + s1.Length;
            n2 = s.IndexOf(s2, n1);
            return s.Substring(n1, n2 - n1);
        }
        #endregion

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

//该程序并不对输入的日志格式进行验证，只考虑正确的日志格式！
