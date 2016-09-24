using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_Common;
using WebApi_DBUtility;

namespace WebApi.Areas.Trading.Controllers
{
    public class UserSignController : ApiController
    {
        protected static WebApi_BLL.T_UserSign bll = new WebApi_BLL.T_UserSign();
        protected static RequestHelper requestHelper = new RequestHelper();

        #region ==== HttpGet ====
        [HttpPost]
        public IHttpActionResult Sign()
        {
            int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
            WebApi_Model.T_UserSign model = bll.GetModel(UID, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            if (model == null)
            {
                WebApi_Model.T_UserSign newmodel = new WebApi_Model.T_UserSign();
                newmodel.UID = UID;
                newmodel.SignDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                newmodel.Type = 0;
                bll.Add(newmodel);
                //return Ok(ReturnJsonResult.GetJsonResult(1, "签到成功", true));
                return GetUserSign(UID, DateTime.Now.ToString("yyyy-MM"));
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "今日已签到", false));
            }
        }

        [HttpPost]
        public IHttpActionResult ReSign()
        {
            int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
            DateTime reDate;
            if (!DateTime.TryParse(requestHelper.GetRequsetForm("reDate", ""), out reDate))
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "日期格式不正确", false));
            }

            if (reDate >= DateTime.Now)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "补签日期不能大于等于当前日期", false));
            }

            if (reDate.Month != DateTime.Now.Month)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "补签日期只能为当月", false));
            }

            WebApi_Model.T_UserSign model = bll.GetModel(UID, reDate);
            if (model == null)
            {
                WebApi_Model.T_UserSign newmodel = new WebApi_Model.T_UserSign();
                newmodel.UID = UID;
                newmodel.SignDate = Convert.ToDateTime(reDate.ToString("yyyy-MM-dd"));
                newmodel.Type = 1;
                newmodel.ReSignDate = DateTime.Now;
                bll.Add(newmodel);
                //return Ok(ReturnJsonResult.GetJsonResult(1, "签到成功", true));
                return GetUserSign(UID, DateTime.Now.ToString("yyyy-MM"));
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "今日已签到", false));
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserSign(int UID, string YYYYMM)
        {
            string currentYYYYMM = DateTime.Now.ToString("yyyy-MM");
            //int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
            DataTable dt = DBHelper.Query("select * from T_UserSign where uid = " + UID + " order by SignDate desc").Tables[0];

            int contDays = 0;
            DateTime signDate = DateTime.Now;

            #region 连续日期
            if (dt.Rows.Count > 0)
            {
                TimeSpan ts = DateTime.Now.Date - Convert.ToDateTime(dt.Rows[0]["SignDate"]);
                int days = ts.Days;
                if (days <= 1) {
                    signDate = Convert.ToDateTime(dt.Rows[0]["SignDate"]);
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        ts = signDate - Convert.ToDateTime(dt.Rows[i]["SignDate"]);
                        if (ts.Days <= 1)
                        {
                            signDate = Convert.ToDateTime(dt.Rows[i]["SignDate"]);
                            contDays += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            #endregion

            WebApi_Model.UserSignResult model = new WebApi_Model.UserSignResult();
            model.Days = contDays;
            model.UID = UID;
            model.YYYYMM = YYYYMM;
            model.SignList = bll.GetModelList(" UID = " + UID + " and CONVERT(varchar(7),SignDate,25) = '" + YYYYMM + "'");


            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
            //return null;
        }

        #endregion

    }
}
