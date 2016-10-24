using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_Common;
using WebApi_DBUtility;

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
                forum.PostTime = DateTime.Now;
                forum.Views = 0;
                forum.Likes = 0;
                forum.CommentCount = 0;
                 
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

                    #region update giftcount
                    //DBHelper.GetSingle("update T_Forum_Comment set ");
                    #endregion


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

        [HttpGet]
        public IHttpActionResult GetCategoryByParentID(int ParentID) {
            WebApi_BLL.T_Forum_Category bll = new WebApi_BLL.T_Forum_Category();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(" ParentID = " + ParentID))));
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

        [HttpGet]
        public IHttpActionResult GetOtherWish(int UID)
        {
            WebApi_BLL.T_Wish bll = new WebApi_BLL.T_Wish();
            DataSet ds = bll.GetList(5, " Status = 1 and a.UID not in (" + UID + ")", " WishID desc");
            List<WebApi_Model.T_Wish> model = bll.DataTableToList(ds.Tables[0]);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
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

        [HttpGet]
        public IHttpActionResult GetForumsActivity() {
            WebApi_BLL.T_Forum_Activity bll = new WebApi_BLL.T_Forum_Activity();
            List<WebApi_Model.T_Forum_Activity> model = bll.GetModelList("");
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
        }

        [HttpGet]
        public IHttpActionResult GetTuiJian() {
            WebApi_BLL.T_Forums bll = new WebApi_BLL.T_Forums();
            DataSet ds = bll.GetList(5,"Status =2 and Flag = 2","ForumID desc");
            List<WebApi_Model.T_Forums> model = bll.DataTableToList(ds.Tables[0]);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
        }

        [HttpGet]
        public IHttpActionResult GetTopTen()
        {
            WebApi_BLL.T_Forums bll = new WebApi_BLL.T_Forums();
            DataSet ds = bll.GetList(10, "Status =2 and Flag = 1", "ForumID desc");
            List<WebApi_Model.T_Forums> model = bll.DataTableToList(ds.Tables[0]);
            WebApi_BLL.T_Forum_Photo tfpbll = new WebApi_BLL.T_Forum_Photo();
            WebApi_BLL.T_User_BaseInfo tubll = new WebApi_BLL.T_User_BaseInfo();

            foreach (WebApi_Model.T_Forums m in model) {
                m.Forum_Photo = tfpbll.GetModelList("ForumID = " + m.ForumID);
                m.User = tubll.GetModel((int)m.UID);
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
        }

        [HttpPost]
        public IHttpActionResult GetFourmList() {
            int Page = int.Parse(requestHelper.GetRequsetForm("Page", ""));
            string strWhere = requestHelper.GetRequsetForm("strWhere", "");
            string strOrder = requestHelper.GetRequsetForm("strOrder", "");

            int TotalPage = 0;
            int PageSize = 10;
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1 = 1";
            }

            if (string.IsNullOrEmpty(strOrder))
            {
                strOrder = " ForumID desc";
            }

            WebApi_BLL.T_Forums bll = new WebApi_BLL.T_Forums();
            List<WebApi_Model.T_Forums> list = bll.DataTableToList(DBHelper.GetListByPage("T_Forums", Page, PageSize, strWhere, strOrder, out TotalPage).Tables[0]);
            
            WebApi_BLL.T_Forum_Photo tfpbll = new WebApi_BLL.T_Forum_Photo();
            WebApi_BLL.T_User_BaseInfo tubll = new WebApi_BLL.T_User_BaseInfo();
            foreach(WebApi_Model.T_Forums m in list){
                m.Forum_Photo = tfpbll.GetModelList(" ForumID = " + m.ForumID);
                m.User = tubll.GetModel((int)m.UID);
            }
            if (list != null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(1, TotalPage.ToString(), JsonConvert.SerializeObject(list)));
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "OK", ""));
            }
        }

        [HttpPost]
        public IHttpActionResult PostComment(dynamic model) {
            WebApi_Model.T_Forum_Comment comment = (WebApi_Model.T_Forum_Comment)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(WebApi_Model.T_Forum_Comment));
            WebApi_BLL.T_Forum_Comment bll = new WebApi_BLL.T_Forum_Comment();
            WebApi_BLL.T_Forums tfsbll = new WebApi_BLL.T_Forums();
            comment.CommentDate = DateTime.Now;
            comment.Status = 0;
            bll.Add(comment);

            //更新评论数
            WebApi_Model.T_Forums forum = new WebApi_Model.T_Forums();
            forum = tfsbll.GetModel((int)comment.ForumID);
            forum.CommentCount += 1;
            tfsbll.Update(forum);

            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(comment)));
        }

        [HttpGet]
        public IHttpActionResult ViewForum(int ForumID, int UID)
        {
            WebApi_BLL.T_Forums bll = new WebApi_BLL.T_Forums();
            WebApi_BLL.T_User tubll = new WebApi_BLL.T_User();
            WebApi_BLL.T_Forum_Photo tfpbll = new WebApi_BLL.T_Forum_Photo();
            WebApi_BLL.T_Forum_Comment tfcbll = new WebApi_BLL.T_Forum_Comment();
            WebApi_BLL.T_Forum_Buy tfbbll = new WebApi_BLL.T_Forum_Buy();

            WebApi_Model.T_Forums forumModle = bll.GetModel(ForumID);
            WebApi_Model.T_User userModel = tubll.GetModel(UID);
            forumModle.Views += 1; //查看数+1
            bll.Update(forumModle);
            forumModle.Forum_Photo = tfpbll.GetModelList("ForumID =" + ForumID);
            forumModle.Forum_Comment = tfcbll.GetModelList("ForumID = " + ForumID);
            forumModle.Forum_Buy = tfbbll.GetModelList("ForumID=" + ForumID + " and UID = " + UID);

            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(forumModle)));
        }

        [HttpPost]
        public IHttpActionResult BuyForum() {
            int ForumID = Convert.ToInt32(requestHelper.GetRequsetForm("ForumID", ""));
            int UID = Convert.ToInt32(requestHelper.GetRequsetForm("UID", ""));

            WebApi_BLL.T_Forum_Buy bll = new WebApi_BLL.T_Forum_Buy();
            WebApi_BLL.T_Forums tfbll = new WebApi_BLL.T_Forums();
            WebApi_BLL.T_User tubll = new WebApi_BLL.T_User();

            WebApi_Model.T_User u = tubll.GetModel(UID);
            WebApi_Model.T_Forums f = tfbll.GetModel(ForumID);

           

            if (u == null || f == null) {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", JsonConvert.SerializeObject("用户或贴子不存在")));
            }

            List<WebApi_Model.T_Forum_Buy> list = bll.GetModelList("UID=" + UID + " and ForumID =" + ForumID);

            if (list.Count > 0) {
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(list[0])));
            }

            if (u.TuiMao < f.TuiMao || f.TuiMao <= 0)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", JsonConvert.SerializeObject("无法购买")));
            }
            else {
                u.TuiMao = u.TuiMao - f.TuiMao;
                tubll.Update(u); //扣除腿毛

                #region ==== 作者 + 腿毛 ====
                WebApi_Model.T_User zzmodel = tubll.GetModel((int)f.UID);
                zzmodel.TuiMao += f.TuiMao;
                tubll.Update(zzmodel);
                #endregion

                WebApi_Model.T_Forum_Buy model = new WebApi_Model.T_Forum_Buy();
                model.BuyDate = DateTime.Now;
                model.UID = UID;
                model.ForumID = ForumID;
                int key = bll.Add(model);
                model.BuyID = key;
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
            }
        }

        [HttpPost]
        public IHttpActionResult LikeForum() {
            int ForumID = Convert.ToInt32(requestHelper.GetRequsetForm("ForumID", ""));
            WebApi_BLL.T_Forums bll = new WebApi_BLL.T_Forums();
            WebApi_Model.T_Forums model = bll.GetModel(ForumID);
            model.Likes += 1;
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.Update(model))));
        }

        [HttpPost]
        public IHttpActionResult LikeComment() {
            int CommentID = Convert.ToInt32(requestHelper.GetRequsetForm("CommentID", ""));
            WebApi_BLL.T_Forum_Comment bll = new WebApi_BLL.T_Forum_Comment();
            WebApi_Model.T_Forum_Comment model = bll.GetModel(CommentID);
            model.Likes += 1;
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.Update(model))));
        }
    }
}
