using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Common;

namespace WebApi.Areas.Trading.Controllers
{
    public class UserSignController : ApiController
    {
        protected static WebApi_BLL.T_UserSign bll = new WebApi_BLL.T_UserSign();
        protected static RequestHelper requestHelper = new RequestHelper();

        #region ==== HttpGet ====
        [HttpGet]
        public IHttpActionResult Sign(int UID)
        {
            WebApi_Model.T_UserSign model = bll.GetModel(UID, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            if (model == null)
            {
                WebApi_Model.T_UserSign newmodel = new WebApi_Model.T_UserSign();
                newmodel.UID = UID;
                newmodel.SignDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                return Ok(ReturnJsonResult.GetJsonResult(1, "签到成功", true));
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "今日已签到", false));
            }
        }
        #endregion

    }
}
