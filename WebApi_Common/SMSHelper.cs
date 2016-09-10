using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common
{
    public static class SMSHelper
    {
        public static string SendSMS(string Tel, string TempID, string[] body)
        {
            CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
            //ip格式如下，不带https://
            bool isInit = api.init("app.cloopen.com", "8883");
            api.setAccount("8a48b5514eab0c78014eaea1993b0297", "850b081bb8674e9a99caa8875ee29063");
            api.setAppId("8aaf070856ea05c20156ea1e81b8004a");
            string ret = string.Empty;
            try
            {
                if (isInit)
                {
                    Dictionary<string, object> retData = api.SendTemplateSMS(Tel, TempID, body);
                    ret = getDictionaryData(retData);
                }
                else
                {
                    ret = "初始化失败";
                }
            }
            catch (Exception exc)
            {
                ret = exc.Message;
            }
            return ret;
        }

        private static string getDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
    }
}
