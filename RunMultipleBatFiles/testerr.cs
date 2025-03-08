using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RunMultipleBatFiles
{
    public class testerr
    {
        public void err()
        { 
            throw new Exception("err occured");
        }

        public string message(Exception ex)
        {
            string ret = ex.ToString();
            ret = Regex.Replace(ret, @"\r\n", "<br>");
            ret = Regex.Replace(ret, @"\n", "<br>");
            return ret;
        }

        public static string message2(Exception ex)
        {
            string ret = ex.ToString();
            ret = Regex.Replace(ret, @"\r\n", "<br>");
            ret = Regex.Replace(ret, @"\n", "<br>");
            return ret;
        }

        public static string handlingErr(Exception ex, string message = "", bool enDisplay = false, bool enDebugMode = false)
        {
            string ret = "...";

            if (ex == null)
                ret = "Exception is null.";

            if (!enDebugMode && !enDisplay)
            {
                // do nothing
            }
            else if (enDebugMode)
            {
                string addMessage = string.IsNullOrEmpty(message) ? "" : "<br>Additional Message: " + message;
                ret = ex.ToString() + addMessage;
            }
            else 
            {
                if (string.IsNullOrEmpty(message))
                {
                    ret = ex.Message;
                }
                else
                {
                    ret = message;
                }
            }

            ret = Regex.Replace(ret, @"\r\n", "<br>");
            ret = Regex.Replace(ret, @"\n", "<br>");

            if (enDebugMode || enDisplay)
            {
                // ログを書く
            }
            else
            { 
                // do nothing
            }

            return ret;
        }
    }
}
