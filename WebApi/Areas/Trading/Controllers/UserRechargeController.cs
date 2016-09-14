using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_Common;

namespace WebApi.Areas.Trading.Controllers
{
    public class UserRechargeController : ApiController
    {
        protected static WebApi_BLL.T_UserRecharge bllUserRecharge = new WebApi_BLL.T_UserRecharge();
        protected static WebApi_BLL.T_RechargeType bllRechargeType = new WebApi_BLL.T_RechargeType();
        protected static WebApi_BLL.T_User bllUser = new WebApi_BLL.T_User();
        protected static RequestHelper requestHelper = new RequestHelper();

        #region ==== Post ====
        [HttpPost]
        public IHttpActionResult Recharge() {
            string UID = requestHelper.GetRequsetForm("UID", "");
            string RechargeID = requestHelper.GetRequsetForm("RechargeID", "");

            WebApi_Model.T_RechargeType RechargeType = bllRechargeType.GetModel(int.Parse(RechargeID));
            WebApi_Model.T_User User = bllUser.GetModel(int.Parse(UID));

            if (RechargeType == null || User == null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Fail", ""));
            }
            else
            {
                User = bllUserRecharge.UserRecharge(User, RechargeType);
            }

            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(User)));
        }

        #endregion
    }
}
