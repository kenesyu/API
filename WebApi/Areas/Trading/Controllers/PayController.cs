using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Aop.Api.Util;
using Newtonsoft.Json;
using WebApi_Common;

namespace WebApi.Areas.Trading.Controllers
{
    public class PayController : ApiController
    {
        protected static RequestHelper requestHelper = new RequestHelper();

        [HttpGet]
        public IHttpActionResult AliPaySign(int OrderID) {

            WebApi_BLL.T_Product_Orders bll = new WebApi_BLL.T_Product_Orders();
            WebApi_Model.T_Product_Orders order = bll.GetModel(OrderID);

            if (order== null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "找不到订单"));
            }
            else if (order.Status != 0)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "找不到需要支付的订单"));
            }
            else
            {
                Dictionary<string,string> parameters = new Dictionary<string,string>();
                parameters.Add("app_id", ConfigurationManager.AppSettings["app_id"].ToString());
                parameters.Add("biz_content", "{\"timeout_express\":\"30m\",\"seller_id\":\"" + ConfigurationManager.AppSettings["seller_id"].ToString() + "\",\"product_code\":\"QUICK_MSECURITY_PAY\",\"total_amount\":\"" + order.TotalAmount + "\",\"subject\":\"商品支付" + order.OrderID + "\",\"body\":\"支付\",\"out_trade_no\":\"" + order.OrderNum + "\"}");
                parameters.Add("charset","utf-8");
                parameters.Add("format","json");
                parameters.Add("method","alipay.trade.app.pay");
                parameters.Add("notify_url",ConfigurationManager.AppSettings["notify_url"].ToString());
                parameters.Add("sign_type","RSA");
                parameters.Add("timestamp",DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                parameters.Add("version","1.0");

                string strSignContent = AlipaySignature.GetSignContent(parameters);
                string strSign = AlipaySignature.RSASign(parameters, System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Key/rsa_private_key.pem"), "", "RSA");

                //parameters.Add("sign", strSign);

                string strRet = Decode(parameters) + "&sign=" + HttpUtility.UrlEncode(strSign);
                //string str = strSignContent + "&sign=" + strSign;
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", strRet));
            }
        }

        [HttpPost]
        public IHttpActionResult ApplePay()
        {

            // 1 腿毛 0会员
            string PayKind = requestHelper.GetRequsetForm("PayKind", "");
            int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
            decimal Amount = decimal.Parse(requestHelper.GetRequsetForm("Amount", ""));
            int Qty = int.Parse(requestHelper.GetRequsetForm("Qty", ""));
            string Certificate = requestHelper.GetRequsetForm("Certificate", "");


            //string str = "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";
            string strMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Certificate, "MD5");


            WebApi_BLL.T_Apple_Pay bll = new WebApi_BLL.T_Apple_Pay();

            if (bll.GetModelList("CertMD5='" + strMD5 + "'").Count > 0)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "该验证已存在"));
            }
            else
            {
                byte[] bytes = Encoding.Default.GetBytes(Certificate);
                string str64 = Convert.ToBase64String(bytes);

                string jsonData = "{ \"receipt-data\":\"" + str64 + "\" }";

                string url = "https://sandbox.itunes.apple.com/verifyReceipt";
                HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(url);
                wReq.Method = "Post";
                wReq.ContentType = "application/json";
                //
                byte[] data = Encoding.Default.GetBytes(jsonData);
                wReq.ContentLength = data.Length;
                Stream reqStream = wReq.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                using (StreamReader sr = new StreamReader(wReq.GetResponse().GetResponseStream()))
                {
                    string result = sr.ReadToEnd();
                    Result r = (Result)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Result));
                    if (r.Status == "0")
                    {
                        WebApi_Model.T_Apple_Pay model = new WebApi_Model.T_Apple_Pay();
                        model.Amount = Amount;
                        model.Certificate = Certificate;
                        model.CertMD5 = strMD5;
                        model.CreateTime = DateTime.Now;
                        model.PayKind = PayKind;
                        model.Qty = Qty;
                        model.UID = UID;
                        bll.Add(model);


                        WebApi_BLL.T_User userBll = new WebApi_BLL.T_User();
                        WebApi_Model.T_User user = userBll.GetModel(UID);

                        if (UID == null) { 
                            return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", JsonConvert.SerializeObject("用户信息不存在")));
                        }
                        if (PayKind == "0")
                        {
                            if (user.VipOverDueDate > DateTime.Now)
                            {
                                user.VipOverDueDate = Convert.ToDateTime(user.VipOverDueDate).AddDays(Qty);
                            }
                            else {
                                user.VipOverDueDate = DateTime.Now.AddDays(Qty);
                            }
                        }
                        else if (PayKind == "1")
                        {
                            user.TuiMao = (user.TuiMao + Qty);
                        }
                        userBll.Update(user);
                        return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(user)));

                    }
                    else
                    {
                        return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", JsonConvert.SerializeObject(r)));
                    }
                    //if(result.IndexOf(""))
                }
            }




            
            return null;
        }

        public string Decode(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append("=").Append(HttpUtility.UrlEncode(value)).Append("&");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);
            
            return content;
        }
    }

    [Serializable]
    public partial class Result
    {
        public Result()
        { }
        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
