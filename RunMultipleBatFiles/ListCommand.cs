using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace RunMultipleBatFiles
{
    /// <summary>
    /// コマンドリスト
    /// </summary>
    public class ListCommand
    {
        [XmlIgnore]
        public readonly string FN_LST_COMMAND = AppDomain.CurrentDomain.BaseDirectory + "List_Bat.txt";
        public string Content = "";

        public ListCommand()
        { 
        
        }

        public void InitWithXML()
        {
            try
            {
                //コマンドのリストが記述されたファイルの有無チェック
                //ある場合は読み込み
                //無い場合は空のファイルを作成
                if (File.Exists(FN_LST_COMMAND))
                {
                    using (StreamReader sr = new StreamReader(FN_LST_COMMAND, Encoding.GetEncoding("utf-8")))
                        Content = sr.ReadToEnd();

                    Content = Content.Replace("\n", "\r\n").Replace("\r\r", "\r");
                }
                else
                {
                    Content = "";

                    using (FileStream fs = File.Create(FN_LST_COMMAND))
                        fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
