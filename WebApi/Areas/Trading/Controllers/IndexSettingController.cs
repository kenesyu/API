using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi_Common;

namespace WebApi.Areas.Trading.Controllers
{
    public class IndexSettingController : ApiController
    {
        protected static WebApi_BLL.T_IndexBackGround bll = new WebApi_BLL.T_IndexBackGround();
        protected static RequestHelper requestHelper = new RequestHelper();

        [HttpGet]
        public IHttpActionResult GetBackGround()
        {
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", bll.GetModelList("")));
        }

    }
}