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
    /// パラメータをセッティングするクラス
    /// </summary>
    public class SettingParams
    {
        [XmlIgnore]
        public readonly string FN_XML = AppDomain.CurrentDomain.BaseDirectory + "RunMultipleBatFiles.xml";
        public string[] Variables = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        public string[] Values = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        public string CurrentDirectory = "";
        public bool IgnoreStdErr = false;
        public bool EnableUtf8Encoding = false;

        public SettingParams()
        {
            // do nothing
        }

        /// <summary>
        /// XMLから読み込み（引数nullで初期化）
        /// </summary>
        /// <param name="fn"></param>
        public void ReadXML(string fn = null)
        {
            try
            {
                if (string.IsNullOrEmpty(fn))
                    fn = FN_XML;

                //環境変数リスト用XMLファイルの有無チェック
                //ある場合はXMLから逆シリアライズ
                //無い場合はシリアライズ
                XmlSerializer ser = new XmlSerializer(typeof(SettingParams));

                if (!File.Exists(fn))
                {
                    StreamWriter sw = new StreamWriter(fn, false, new UTF8Encoding(false));
                    ser.Serialize(sw, this);
                    sw.Close();
                }
                else
                {
                    StreamReader sr = new StreamReader(fn, new UTF8Encoding(false));
                    SettingParams tmp = (SettingParams)ser.Deserialize(sr);
                    this.Variables = tmp.Variables;
                    this.Values = tmp.Values;
                    this.CurrentDirectory = tmp.CurrentDirectory;
                    this.IgnoreStdErr = tmp.IgnoreStdErr;
                    this.EnableUtf8Encoding = tmp.EnableUtf8Encoding;
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetEnvVars(ref Dictionary<TextBox, TextBox> lstEnvVarBox)
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

        public void SetEnvVars(Dictionary<TextBox, TextBox> lstEnvVarBox)
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
