//複数のBatファイルや1行コマンドを実行します
//
//以下のサイトを参考にしました。
// DOSコマンドを実行し出力データを取得する
// https://dobon.net/vb/dotnet/process/standardoutput.html
// 環境変数の値を取得するには？［C#／VB］
// https://atmarkit.itmedia.co.jp/ait/articles/1803/07/news023.html
// オブジェクトのXMLシリアル化、逆シリアル化を行う
// https://dobon.net/vb/dotnet/file/xmlserializer.html#section1

using RunMultipleBatFiles.Properties;
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
        //パラメータ
        private SettingParams settings = new SettingParams();

        //コマンドリスト
        private ListCommand lstCmd = new ListCommand();

        //DOSコマンド実行クラス
        private DosCommand dos = new DosCommand();

        //環境変数用テキストボックスをまとめるためのDictionary
        private Dictionary<TextBox, TextBox> lstEnvVarBox = new Dictionary<TextBox, TextBox>();

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

            try
            {
                //タイトルの表示
                this.Text = "RunMultipleBatFiles " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                //コマンドリストと標準出力用テキストボックスをクリア
                txtLstCmd.Text = "";
                txtStdOut.Text = "";

                //環境変数用テキストボックスをまとめる           
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

                //パラメータ・コマンドリストの初期化用ファイルの読み込み
                settings.ReadXML();
                lstCmd.ReadTXT();

                //環境変数用テキストボックスに値をセットする
                settings.GetEnvVars(ref lstEnvVarBox);

                //Listタブを初期化しアクティブにする
                txtLstCmd.Text = lstCmd.Content;
                tabCntrl.SelectedTab = pageList;

                //カレントディレクトリを表示
                if (!string.IsNullOrWhiteSpace(settings.CurrentDirectory))
                    Environment.CurrentDirectory = settings.CurrentDirectory;

                txtCD.Text = Environment.CurrentDirectory;

                //標準エラーを無視するか否か
                chkIgnoreStdErr.Checked = settings.IgnoreStdErr;
            }
            catch (Exception ex)
            {
                //Listタブをアクティブにしてから、エラー内容を表示
                tabCntrl.SelectedTab = pageStdOut;
                txtStdOut.Text += "\r\nException:\r\n" + ex.Message + "\r\n";
            }

        }

        //イベント
        private void bttnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = Environment.CurrentDirectory;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Environment.CurrentDirectory = fbd.SelectedPath;
                    txtCD.Text = Environment.CurrentDirectory;
                }
            }
            catch (Exception ex)
            {
                //Listタブをアクティブにしてから、エラー内容を表示
                tabCntrl.SelectedTab = pageStdOut;
                txtStdOut.Text += "\r\nException:\r\n" + ex.Message + "\r\n";
            }
        }

        private void bttnRun_Click(object sender, EventArgs e)
        {
            try
            {
                lstCmd.Content = txtLstCmd.Text;                
                settings.CurrentDirectory = txtCD.Text;
                settings.IgnoreStdErr = chkIgnoreStdErr.Checked;
                txtStdOut.Text = "";

                //プロセスの環境変数は一度クリアしてから更新する
                for (int i = 0; i < settings.GetNum(); i++)
                {
                    if (!string.IsNullOrWhiteSpace(settings.Variables[i]))
                        Environment.SetEnvironmentVariable(settings.Variables[i], null, EnvironmentVariableTarget.Process);
                }

                settings.SetEnvVars(lstEnvVarBox);

                for (int i = 0; i < settings.GetNum(); i++)
                {
                    if (!string.IsNullOrWhiteSpace(settings.Variables[i]))
                        Environment.SetEnvironmentVariable(settings.Variables[i], settings.Values[i], EnvironmentVariableTarget.Process);
                }

                //標準出力タブをアクティブにする
                tabCntrl.SelectedTab = pageStdOut;

                //処理実行
                Task runMultipleBatAsync = Task.Run(() => {
                    this.Invoke((MethodInvoker)(() => runMultipleBat()));
                });

                //処理が終わるまで[Run]ボタンを押せないようにする
                bttnRun.Enabled = false;
            }
            catch (Exception ex)
            {
                //Listタブをアクティブにしてから、エラー内容を表示
                tabCntrl.SelectedTab = pageStdOut;
                txtStdOut.Text += "\r\nException:\r\n" + ex.Message + "\r\n";
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                foreach (var item in files)
                {
                    string ext = Path.GetExtension(item);

                    if (ext.ToLower() == ".txt")
                    {
                        lstCmd.ReadTXT(item);
                        txtLstCmd.Text = lstCmd.Content;
                        tabCntrl.SelectedTab = pageList;
                    }
                    else if (ext.ToLower() == ".xml")
                    {
                        settings.ReadXML(item);
                        settings.GetEnvVars(ref lstEnvVarBox);

                        if (!string.IsNullOrWhiteSpace(settings.CurrentDirectory))
                            Environment.CurrentDirectory = settings.CurrentDirectory;

                        txtCD.Text = Environment.CurrentDirectory;
                        chkIgnoreStdErr.Checked = settings.IgnoreStdErr;
                        tabCntrl.SelectedTab = pageSettings;
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            catch (Exception ex)
            {
                //Listタブをアクティブにしてから、エラー内容を表示
                tabCntrl.SelectedTab = pageStdOut;
                txtStdOut.Text += "\r\nException:\r\n" + ex.Message + "\r\n";
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        // 以下、処理
        private void scrollToBottom()
        {
            //スクロールバーを一番下に移動する
            txtStdOut.SelectionStart = txtStdOut.Text.Length;
            txtStdOut.Focus();
            txtStdOut.ScrollToCaret();
        }

        private void runMultipleBat()
        {
            try
            {
                //改行で分割
                string[] lst_cmd = string.IsNullOrWhiteSpace(txtLstCmd.Text) ? null : Regex.Split(txtLstCmd.Text, "\r\n");

                // 1行づつ実行
                if (lst_cmd != null)
                {
                    foreach (var cmd in lst_cmd)
                    {
                        string systemPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);
                        string userPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User);
                        Environment.SetEnvironmentVariable("path", systemPath + ";" + userPath, EnvironmentVariableTarget.Process);
                        //デバッグ用
                        //string procPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Process);

                        //処理
                        if (!string.IsNullOrWhiteSpace(cmd))
                        {
                            txtStdOut.Text += "\r\n>> " + cmd + "\r\n";
                            scrollToBottom();
                            Application.DoEvents();

                            dos.RunOneLine(cmd, settings.IgnoreStdErr);
                            //改行コードを\r\nに変換
                            string tmp = Regex.Replace(dos.StandardOutput, "\\n", "\r\n");
                            tmp = Regex.Replace(tmp, "\\r\\r", "\r");
                            //文字色を無視
                            tmp = Regex.Replace(tmp, "(\\u001b.*?m)", "");
                            txtStdOut.Text += tmp;
                            Application.DoEvents();
                        }

                        scrollToBottom();
                        Application.DoEvents();
                    }
                }
                else
                {
                    txtStdOut.Text = "List is empty.";
                }
            }
            catch (Exception ex)
            {
                //Listタブをアクティブにしてから、エラー内容を表示
                tabCntrl.SelectedTab = pageStdOut;
                txtStdOut.Text += "\r\nException:\r\n" + ex.Message + "\r\n";
            }
            finally
            {
                //処理が終了したので[Run]ボタンを押せるようにする
                txtStdOut.Text += "\r\nDone.\r\n";
                bttnRun.Enabled = true;
            }
        }
    }
}
