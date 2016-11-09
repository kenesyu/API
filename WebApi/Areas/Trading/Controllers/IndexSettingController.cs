using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
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
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(""))));
        }

        [HttpPost]
        public IHttpActionResult SendMessage(dynamic model) {
            WebApi_BLL.T_System_Messages tsmbll = new WebApi_BLL.T_System_Messages();
            WebApi_Model.T_System_Messages message = (WebApi_Model.T_System_Messages)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(WebApi_Model.T_System_Messages));
            int id = tsmbll.Add(message);
            message.IsView = 0;
            message.IsDelete = 0;
            message.PostDate = DateTime.Now;
            message.MessageID = id;
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(message)));
        }

        [HttpGet]
        public IHttpActionResult GetMessageByUID(int UID)
        {
            WebApi_BLL.T_System_Messages tsmbll = new WebApi_BLL.T_System_Messages();
            List<WebApi_Model.T_System_Messages> list = tsmbll.GetModelList("IsDelete = 0 and ToUID =" + UID);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(list))); 
        }

        [HttpGet]
        public IHttpActionResult ViewMessage(int UID, int MessageID)
        {
            WebApi_BLL.T_System_Messages tsmbll = new WebApi_BLL.T_System_Messages();
            WebApi_Model.T_System_Messages message = tsmbll.GetModel(MessageID);
            if (message != null && message.ToUID == UID)
            {
                message.IsView = 1;
                tsmbll.Update(message);
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", JsonConvert.SerializeObject("无法找到消息！")));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(message)));
        }

        [HttpGet]
        public IHttpActionResult GetNoReadCount(int UID)
        {
            WebApi_BLL.T_System_Messages tsmbll = new WebApi_BLL.T_System_Messages();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(tsmbll.GetRecordCount("IsDelete = 0 and IsView = 0 and ToUID =" + UID))));
        }

        [HttpPost]
        public IHttpActionResult DeleteMessage(int MessageID)
        {
            WebApi_BLL.T_System_Messages tsmbll = new WebApi_BLL.T_System_Messages();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(tsmbll.Delete(MessageID))));
        }
    }
}