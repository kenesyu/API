using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_Common;

namespace WebApi.Areas.Trading.Controllers
{
    public class RechargeTypeController : ApiController
    {
        protected static WebApi_BLL.T_RechargeType bll = new WebApi_BLL.T_RechargeType();
        protected static RequestHelper requestHelper = new RequestHelper();

        #region ==== Get 方法 ====
        [HttpGet]
        public IHttpActionResult GetAllRechageType()
        {
            List<WebApi_Model.T_RechargeType> list = bll.DataTableToList(bll.GetAllList().Tables[0]);
            if (list == null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", list));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(list)));
        }

        [HttpGet]
        public IHttpActionResult GetRechageTypeByID(int RechargeID)
        {
            WebApi_Model.T_RechargeType T_RechargeType = bll.GetModel(RechargeID);
            if (T_RechargeType == null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", JsonConvert.SerializeObject(T_RechargeType)));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(T_RechargeType)));
        } 
        #endregion
    }
}