using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RunMultipleBatFiles
{
    /// <summary>
    /// 環境変数リストをTextBoxに入出力するクラス
    /// </summary>
    public class IO_EnvVars_To_TextBox
    {
        public readonly string FN_XML = AppDomain.CurrentDomain.BaseDirectory + "RunMultipleBatFiles.xml";
        public string[] Variables = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        public string[] Values = new string[10] { "", "", "", "", "", "", "", "", "", "" };

        public IO_EnvVars_To_TextBox()
        {
            // do nothing
        }

        public void ReadFromXML()
        {
            //環境変数リスト用XMLファイルの有無チェック
            //ある場合はXMLから逆シリアライズ
            //無い場合はシリアライズ
            XmlSerializer ser = new XmlSerializer(typeof(IO_EnvVars_To_TextBox));

            if (!File.Exists(FN_XML))
            {
                StreamWriter sw = new StreamWriter(FN_XML, false, new UTF8Encoding(false));
                ser.Serialize(sw, this);
                sw.Close();
            }
            else
            {
                StreamReader sr = new StreamReader(FN_XML, new UTF8Encoding(false));
                IO_EnvVars_To_TextBox tmp = (IO_EnvVars_To_TextBox)ser.Deserialize(sr);
                this.Variables = tmp.Variables;
                this.Values = tmp.Values;
                sr.Close();
            }
        }

        public void Get(Dictionary<TextBox, TextBox> lstEnvVarBox)
        {
            try
            {
                if (lstEnvVarBox == null || lstEnvVarBox.Count != Variables.Length)
                    throw new Exception("The number is different.");

                int i = 0;

                foreach (var item in lstEnvVarBox)
                {
                    item.Key.Text = Variables[i];
                    item.Value.Text = Values[i];
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Set(Dictionary<TextBox, TextBox> lstEnvVarBox)
        {
            try
            {
                if (lstEnvVarBox == null || lstEnvVarBox.Count != Variables.Length)
                    throw new Exception("The number is different.");

                int i = 0;

                foreach (var item in lstEnvVarBox)
                {
                    Variables[i] = item.Key.Text;
                    Values[i] = item.Value.Text;
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetNum()
        { 
            return Variables.Length;
        }
    }
}
