using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_Common;

namespace WebApi.Areas.Trading.Controllers
{
    public class ForumsController : ApiController
    {
        protected static RequestHelper requestHelper = new RequestHelper();

        [HttpGet]
        public IHttpActionResult GetGiftList()
        {
            WebApi_BLL.T_Gift bll = new WebApi_BLL.T_Gift();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList("IsActive = 1"))));
        }

        [HttpPost]
        public IHttpActionResult UploadFreePhoto()
        {
            try
            {
                //int uid = Convert.ToInt32(requestHelper.GetRequsetForm("UID", ""));
                string Path = HttpContext.Current.Server.MapPath("/Content/User_Photo/");
                HttpPostedFile file = HttpContext.Current.Request.Files[0];
                string fileExtName = file.FileName.Substring(file.FileName.LastIndexOf("."));
                string newName = Guid.NewGuid().ToString() + fileExtName;
                string savePath = Path + newName;
                file.SaveAs(savePath);
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(newName)));

            }
            catch (SystemException ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", ex.Message));
            }
        }

        [HttpPost]
        public IHttpActionResult UploadCostPhoto()
        {
            try
            {
                WebApi_BLL.T_Forum_Photo bll = new WebApi_BLL.T_Forum_Photo();
                string Path = HttpContext.Current.Server.MapPath("/Content/User_Photo/");
                HttpPostedFile file = HttpContext.Current.Request.Files[0];
                string fileExtName = file.FileName.Substring(file.FileName.LastIndexOf("."));
                string newName = Guid.NewGuid().ToString() + fileExtName;
                string savePath = Path + newName;
                file.SaveAs(savePath);
                WebApi_Model.T_Forum_Photo model = new WebApi_Model.T_Forum_Photo();
                model.Photo = newName;
                model.UploadTime = DateTime.Now;
                int key = bll.Add(model);
                model.ForumPhotoID = key;
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));

            }
            catch (SystemException ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", ex.Message));
            }
        }

        /// <summary>
        /// 发贴
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostNewFourm(dynamic model)
        {
            try
            {
                WebApi_BLL.T_Forums bll = new WebApi_BLL.T_Forums();
                WebApi_Model.T_Forums forum = (WebApi_Model.T_Forums)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(WebApi_Model.T_Forums));
                if (forum.TuiMao != 0 && forum.Forum_Photo.Count == 0) {
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject("图集为空")));
                }
                forum.Status = 0;
                forum.Flag = 0;
                int key = bll.Add(forum);
                forum.ForumID = key;
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(forum)));
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(ex.Message)));
            }
        }

        [HttpGet]
        public IHttpActionResult GetUpdateFourm(int ForumID)
        {
            WebApi_BLL.T_Forums bll = new WebApi_BLL.T_Forums();
            WebApi_Model.T_Forums model = bll.GetModel(ForumID);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
        }

        [HttpPost]
        public IHttpActionResult DeletePhoto()
        {
            int ID = int.Parse(requestHelper.GetRequsetForm("ID", ""));
            WebApi_BLL.T_Forum_Photo bll = new WebApi_BLL.T_Forum_Photo();
            bool flag = bll.Delete(ID);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", flag));
        }

        [HttpPost]
        public IHttpActionResult SendGift(dynamic model)
        {
            WebApi_BLL.T_Forum_Gift bll = new WebApi_BLL.T_Forum_Gift();
            WebApi_BLL.T_User userbll = new WebApi_BLL.T_User();
            WebApi_BLL.T_Gift giftbll = new WebApi_BLL.T_Gift();
            WebApi_Model.T_Forum_Gift forumgift = (WebApi_Model.T_Forum_Gift)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(WebApi_Model.T_Forum_Gift));

            WebApi_Model.T_User sendUser = userbll.GetModel((int)forumgift.PostUID);
            WebApi_Model.T_User receiptUser = userbll.GetModel((int)forumgift.ReceiptUID);
            WebApi_Model.T_Gift gift = giftbll.GetModel((int)forumgift.GiftID);

            if (sendUser != null && receiptUser != null && gift != null)
            {
                int TotalTM = (int)gift.TuiMao * (int)forumgift.Qty;
                if (sendUser.TuiMao >= TotalTM)
                {
                    sendUser.TuiMao = sendUser.TuiMao - TotalTM;
                    receiptUser.TuiMao = receiptUser.TuiMao + TotalTM;
                    userbll.Update(sendUser);
                    userbll.Update(receiptUser);
                    forumgift.PostTime = DateTime.Now;
                    bll.Add(forumgift);
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", "腿毛不足！"));
                }
                else
                {
                    return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "腿毛不足！"));
                }
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "数据格式错误！"));
            }
        }

        [HttpGet]
        public IHttpActionResult GetCategory() {
            WebApi_BLL.T_Forum_Category bll = new WebApi_BLL.T_Forum_Category();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(""))));
        }

        [HttpPost]
        public IHttpActionResult PostWish(dynamic model)
        {
            WebApi_Model.T_Wish wish = (WebApi_Model.T_Wish)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(WebApi_Model.T_Wish));
            WebApi_BLL.T_Wish bll = new WebApi_BLL.T_Wish();
            wish.PostDate = DateTime.Now;
            wish.Status = 0;
            int key = bll.Add(wish);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(" UID = " + wish.UID))));
        }

        [HttpGet]
        public IHttpActionResult GetWishByUID(int UID) {
            WebApi_BLL.T_Wish bll = new WebApi_BLL.T_Wish();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(" UID = " + UID)))); 
        }

        [HttpPost]
        public IHttpActionResult ConvertWish() {
            WebApi_BLL.T_Wish bll = new WebApi_BLL.T_Wish();
            WebApi_BLL.T_User userbll = new WebApi_BLL.T_User();
            int UID = Convert.ToInt32(requestHelper.GetRequsetForm("UID",""));
            int WishID = Convert.ToInt32(requestHelper.GetRequsetForm("UID", ""));

            WebApi_Model.T_Wish wishmodel = bll.GetModel(WishID);
            WebApi_Model.T_User usermodel = userbll.GetModel(UID);

            if (wishmodel == null) { return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "心愿计划无法找到")); }
            if (usermodel == null) { return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "没有找到用户")); }

            if (wishmodel.Status == 1 && usermodel.TuiMao >= wishmodel.TuiMao)
            {
                wishmodel.Status = 2;
                bll.Update(wishmodel);
                usermodel.TuiMao = usermodel.TuiMao - wishmodel.TuiMao;
                userbll.Update(usermodel);

                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(" UID = " + UID)))); 
            }
            else {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "无法兑换"));
            }       
        }

    }
}
