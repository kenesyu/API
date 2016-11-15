using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
using WebApi_Common;

namespace WebApi.Areas.Trading.Controllers
{
    public class PayController : ApiController
    {
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
                parameters.Add("biz_content", "{\"timeout_express\":\"30m\",\"seller_id\":\"" + ConfigurationManager.AppSettings["seller_id"].ToString() + "\",\"product_code\":\"QUICK_MSECURITY_PAY\",\"total_amount\":\"" + order.TotalAmount + "\",\"subject\":\"商品支付" + order.OrderID + "\",\"body\":\"我是测试数据\",\"out_trade_no\":\"" + order.OrderNum + "\"}");
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
        public IHttpActionResult UpatePayStatus()
        {
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
}
