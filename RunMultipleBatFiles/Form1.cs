// DOSコマンドを実行し出力データを取得する
// https://dobon.net/vb/dotnet/process/standardoutput.html
// 環境変数の値を取得するには？［C#／VB］
// https://atmarkit.itmedia.co.jp/ait/articles/1803/07/news023.html

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RunMultipleBatFiles
{
    public partial class Form1 : Form
    {
        //定数
        private readonly string FN_BAT_MAIN = System.AppDomain.CurrentDomain.BaseDirectory + "List_Bat_Main.txt";

        //Processオブジェクトを作成
        private System.Diagnostics.Process proc = null;

        //環境変数リスト
        Dictionary<System.Windows.Forms.TextBox, System.Windows.Forms.TextBox> lstEnvVar = new Dictionary<System.Windows.Forms.TextBox, System.Windows.Forms.TextBox>();


        public Form1()
        {
            InitializeComponent();

            lstEnvVar.Add(txtVar01, txtValue01);
            lstEnvVar.Add(txtVar02, txtValue02);
            lstEnvVar.Add(txtVar03, txtValue03);
            lstEnvVar.Add(txtVar04, txtValue04);
            lstEnvVar.Add(txtVar05, txtValue05);
            lstEnvVar.Add(txtVar06, txtValue06);
            lstEnvVar.Add(txtVar07, txtValue07);
            lstEnvVar.Add(txtVar08, txtValue08);
            lstEnvVar.Add(txtVar09, txtValue09);
            lstEnvVar.Add(txtVar10, txtValue10);

            tabCntrl.SelectedTab = pageList;
            init();
            newProc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtStdOut.Text = "";
            tabCntrl.SelectedTab = pageStdOut;
            Application.DoEvents();

            Task runMultipleBatAsync = Task.Run(() => {
                if (this.InvokeRequired)
                    this.Invoke((MethodInvoker)(() => RunMultipleBat()));
                else
                    RunMultipleBat();
            });

            bttnRun.Enabled = false;
        }

        private void CheckFileAndSetTextBox(string filename, System.Windows.Forms.TextBox obj)
        {
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("utf-8")))
                    obj.Text = sr.ReadToEnd();
            }
            else
            {
                obj.Text = "";

                using (FileStream fs = File.Create(filename))
                    fs.Close();
            }
        }

        private void newProc()
        {
            proc = new System.Diagnostics.Process();

            //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            proc.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");

            //出力を読み取れるようにする
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = false;

            //ウィンドウを表示しないようにする
            proc.StartInfo.CreateNoWindow = true;
        }

        private void init()
        {
            //ファイルのチェックとテキストボックスの初期化
            CheckFileAndSetTextBox(FN_BAT_MAIN, txtBatMain);
            txtStdOut.Text = "";
        }

        private void runCommand(string cmd)
        {
            proc.StartInfo.Arguments = @"/c " + cmd;
            proc.Start();
            txtStdOut.Text += proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            proc.Close();
        }

        private void RunMultipleBat()
        {
            try
            {
                //改行で分割
                string[] lst_bat_main = string.IsNullOrWhiteSpace(txtBatMain.Text) ? null : Regex.Split(txtBatMain.Text, "\r\n");

                // Mainを1行づつ実行
                if (lst_bat_main != null)
                {
                    foreach (var cmd_main in lst_bat_main)
                    {
                        string systemPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
                        string userPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User);
                        Environment.SetEnvironmentVariable("path", systemPath + ";" + userPath, EnvironmentVariableTarget.Process);
                        //デバッグ用
                        //string procPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Process);

                        //★★★環境変数の設定
                        foreach (var envVar in lstEnvVar)
                        {
                            if (!string.IsNullOrEmpty(envVar.Key.Text))
                            {
                                Environment.SetEnvironmentVariable(envVar.Key.Text, envVar.Value.Text, EnvironmentVariableTarget.Process);
                            }
                        }

                        //処理
                        if (!string.IsNullOrWhiteSpace(cmd_main))
                        {
                            txtStdOut.Text += "\r\n>> " + cmd_main + "\r\n";
                            runCommand(cmd_main);
                        }

                        txtStdOut.SelectionStart = txtStdOut.Text.Length;
                        txtStdOut.Focus();
                        txtStdOut.ScrollToCaret();

                        Application.DoEvents();
                    }
                }
                else
                {
                    txtStdOut.Text = "Mainは空です";
                }
            }
            catch (Exception ex)
            {
                txtStdOut.Text += "\r\nException:r\n" + ex.ToString() + "\r\n";
            }
            finally
            {
                bttnRun.Enabled = true;
            }
        }
    }
}
