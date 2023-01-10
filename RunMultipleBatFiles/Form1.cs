//複数のBatファイルを実行します
//
//以下のサイトを参考にしました。
// DOSコマンドを実行し出力データを取得する
// https://dobon.net/vb/dotnet/process/standardoutput.html
// 環境変数の値を取得するには？［C#／VB］
// https://atmarkit.itmedia.co.jp/ait/articles/1803/07/news023.html
// オブジェクトのXMLシリアル化、逆シリアル化を行う
// https://dobon.net/vb/dotnet/file/xmlserializer.html#section1

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RunMultipleBatFiles
{
    public partial class Form1 : Form
    {
        //定数
        private readonly string FN_BAT_MAIN = AppDomain.CurrentDomain.BaseDirectory + "List_Bat.txt";
        private readonly string FN_XML = AppDomain.CurrentDomain.BaseDirectory + "RunMultipleBatFiles.xml";

        //Processオブジェクト
        private System.Diagnostics.Process proc = null;

        //環境変数リストクラス関連
        private ListEnvironmentVariable lstEnvVar = new ListEnvironmentVariable();
        private Dictionary<TextBox, TextBox> lstEnvVarBox = new Dictionary<TextBox, TextBox>();

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

            //環境変数リスト用XMLファイルの有無チェック
            //ある場合はXMLから逆シリアライズ
            //無い場合はシリアライズ
            XmlSerializer ser = new XmlSerializer(typeof(ListEnvironmentVariable));

            if (!File.Exists(FN_XML))
            {                
                StreamWriter sw = new StreamWriter(FN_XML, false, new UTF8Encoding(false));
                ser.Serialize(sw, lstEnvVar);
                sw.Close();
            }
            else
            {
                StreamReader sr = new StreamReader(FN_XML, new UTF8Encoding(false));
                lstEnvVar = (ListEnvironmentVariable)ser.Deserialize(sr);
                sr.Close();
            }

            //環境変数リスト関連のコントロールに値をセットする
            lstEnvVarBox.Add(txtVar01, txtValue01);
            lstEnvVarBox.Add(txtVar02, txtValue02);
            lstEnvVarBox.Add(txtVar03, txtValue03);
            lstEnvVarBox.Add(txtVar04, txtValue04);
            lstEnvVarBox.Add(txtVar05, txtValue05);
            lstEnvVarBox.Add(txtVar06, txtValue06);
            lstEnvVarBox.Add(txtVar07, txtValue07);
            lstEnvVarBox.Add(txtVar08, txtValue08);
            lstEnvVarBox.Add(txtVar09, txtValue09);
            lstEnvVarBox.Add(txtVar10, txtValue10);
            lstEnvVar.Get(lstEnvVarBox);

            //コマンドのリストが記述されたファイルの有無チェック
            //ある場合は読み込み
            //無い場合は空のファイルを作成
            if (File.Exists(FN_BAT_MAIN))
            {
                using (StreamReader sr = new StreamReader(FN_BAT_MAIN, Encoding.GetEncoding("utf-8")))
                    txtBatMain.Text = sr.ReadToEnd();
            }
            else
            {
                txtBatMain.Text = "";

                using (FileStream fs = File.Create(FN_BAT_MAIN))
                    fs.Close();
            }

            //Listタブに変更する
            tabCntrl.SelectedTab = pageList;

            //標準出力用テキストボックスをクリア
            txtStdOut.Text = "";

            //タイトルの表示
            this.Text = "RunMultipleBatFiles " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //Processオブジェクトの生成
            newProc();
        }

        //イベント
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtStdOut.Text = "";

                //プロセスの環境変数をクリアする
                for (int i = 0; i < lstEnvVar.GetNum(); i++)
                {
                    if (!string.IsNullOrWhiteSpace(lstEnvVar.Variables[i]))
                        Environment.SetEnvironmentVariable(lstEnvVar.Variables[i], null, EnvironmentVariableTarget.Process);
                }

                //プロセスの環境変数を更新
                lstEnvVar.Set(lstEnvVarBox);

                for (int i = 0; i < lstEnvVar.GetNum(); i++)
                {
                    if (!string.IsNullOrWhiteSpace(lstEnvVar.Variables[i]))
                        Environment.SetEnvironmentVariable(lstEnvVar.Variables[i], lstEnvVar.Values[i], EnvironmentVariableTarget.Process);
                }

                //標準出力タブに変更
                tabCntrl.SelectedTab = pageStdOut;
                Application.DoEvents();

                //処理実行
                Task runMultipleBatAsync = Task.Run(() => {
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)(() => runMultipleBat()));
                    else
                        runMultipleBat();
                });

                bttnRun.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //メソッド
        private void newProc()
        {
            proc = new System.Diagnostics.Process();

            //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            proc.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");

            //出力を読み取れるようにする
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = false;

            //ウィンドウを表示しないようにする
            proc.StartInfo.CreateNoWindow = true;
        }

        private void runCommand(string cmd)
        {
            try
            {
                proc.StartInfo.Arguments = @"/c " + cmd;
                proc.Start();
                txtStdOut.Text += proc.StandardOutput.ReadToEnd();
                string err = proc.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(err))
                {
                    throw new Exception(err);
                }
            }
            catch (Exception ex)
            {
                proc.Close();
                throw ex;
            }
            
            proc.WaitForExit();
            proc.Close();
        }

        private void runMultipleBat()
        {
            try
            {
                //改行で分割
                string[] lst_bat_main = string.IsNullOrWhiteSpace(txtBatMain.Text) ? null : Regex.Split(txtBatMain.Text, "\r\n");

                // 1行づつ実行
                if (lst_bat_main != null)
                {
                    foreach (var cmd_main in lst_bat_main)
                    {
                        string systemPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
                        string userPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User);
                        Environment.SetEnvironmentVariable("path", systemPath + ";" + userPath, EnvironmentVariableTarget.Process);
                        //デバッグ用
                        //string procPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Process);

                        //処理
                        if (!string.IsNullOrWhiteSpace(cmd_main))
                        {
                            txtStdOut.Text += "\r\n>> " + cmd_main + "\r\n";
                            Application.DoEvents();

                            runCommand(cmd_main);
                            Application.DoEvents();
                        }

                        //スクロールバーを一番下に移動する
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
                txtStdOut.Text += "\r\nException:\r\n" + ex.Message + "\r\n";
            }
            finally
            {
                bttnRun.Enabled = true;
            }
        }
    }
}
