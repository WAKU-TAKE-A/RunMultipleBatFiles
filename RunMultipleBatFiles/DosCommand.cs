using System;
using System.Diagnostics;

namespace RunMultipleBatFiles
{
    public class DosCommand
    {
        public string StandardOutput = "";

        public bool RunOneLine(string command = "")
        {
            // 結果をfalseにセット
            bool bret = false;

            // Processオブジェクトを作成
            Process p = new Process();

            try
            {
                // ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                p.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");

                // 出力を読み取れるようにする
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.RedirectStandardError = true;

                //ウィンドウを表示しないようにする
                p.StartInfo.CreateNoWindow = true;

                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                p.StartInfo.Arguments = "/c " + command;
                bret = p.Start();

                //出力を読み取る
                StandardOutput = p.StandardOutput.ReadToEnd();
                string err = p.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(err))
                {
                    throw new Exception(err);
                }

                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                p.Close();
                throw ex;
            }

            p.Close();
            return bret;
        }
    }
}
