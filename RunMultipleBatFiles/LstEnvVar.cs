using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunMultipleBatFiles
{
    /// <summary>
    /// 環境変数リストクラス
    /// </summary>
    public class ListEnvironmentVariable
    {
        public string[] Variables = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        public string[] Values = new string[10] { "", "", "", "", "", "", "", "", "", "" };

        public ListEnvironmentVariable()
        {
            // do nothing
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
