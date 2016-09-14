using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Common;
using WebApi_DBUtility;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApi.Areas.Trading.Controllers
{
    public class PhotoCollectionController : ApiController
    {
        protected static WebApi_BLL.T_Photo_Collection bll = new WebApi_BLL.T_Photo_Collection();
        protected static RequestHelper requestHelper = new RequestHelper();

        [HttpGet]
        public IHttpActionResult InitPhotoList(int Page,string strWhere, string strOrder)
        {
            int TotalPage = 0;
            int PageSize = 10;
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1 = 1";
            }

            if (string.IsNullOrEmpty(strOrder))
            {
                strOrder = " PhotoCollectionID desc";
            }

            List<WebApi_Model.T_Photo_Collection> list = bll.DataTableToList(DBHelper.GetListByPage("V_Photo_Collection", Page, PageSize, strWhere, strOrder, out TotalPage).Tables[0]);
            if (list != null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(1, TotalPage.ToString(), JsonConvert.SerializeObject(list)));
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "OK", ""));
            }
        }

        [HttpGet]
        public IHttpActionResult GetProductCategoryByType(int ParentID)
        {
            WebApi_BLL.T_Product_Category bll = new WebApi_BLL.T_Product_Category();
            return Ok(ReturnJsonResult.GetJsonResult(-1, "OK", JsonConvert.SerializeObject(bll.GetModelList(" ParentID =" + ParentID))));
        }

        [HttpGet]
        public IHttpActionResult CheckPhotoIsBuy(int UID, int PhotoCollectionID)
        {
            WebApi_BLL.T_Photo_Pay tppbll = new WebApi_BLL.T_Photo_Pay();
            List<WebApi_Model.T_Photo_Pay> list = tppbll.GetModelList("UID=" + UID + " and PhotoCollectionID=" + PhotoCollectionID );
            if (list.Count > 0) {
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", true));
            }else{
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", false));
            }
        }

        [HttpGet]
        public IHttpActionResult GetDetailsByID(int PhotoCollectionID)
        {
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModel(PhotoCollectionID))));
        }

        [HttpPost]
        public IHttpActionResult ClickLikes()
        {
            try
            {
                int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
                int PhotoCollectionID = int.Parse(requestHelper.GetRequsetForm("PhotoCollectionID", ""));
                WebApi_BLL.T_Photo_Likes tpl_bll = new WebApi_BLL.T_Photo_Likes();
                if (tpl_bll.Exists(UID, PhotoCollectionID))
                {
                    tpl_bll.Delete(UID, PhotoCollectionID);
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", "-1"));
                }
                else
                {
                    WebApi_Model.T_Photo_Likes model = new WebApi_Model.T_Photo_Likes();
                    model.UID = UID;
                    model.PhotoCollectionID = PhotoCollectionID;
                    tpl_bll.Add(model);
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", "+1"));
                }
            }
            catch(Exception ex) {
                return Ok(ReturnJsonResult.GetJsonResult(1, "Error", ex.Message));
            }
        }

        [HttpPost]
        public IHttpActionResult ClickStore()
        {
            try
            {
                int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
                int PhotoCollectionID = int.Parse(requestHelper.GetRequsetForm("PhotoCollectionID", ""));
                WebApi_BLL.T_Photo_Store tps_bll = new WebApi_BLL.T_Photo_Store();
                if (tps_bll.Exists(UID, PhotoCollectionID))
                {
                    tps_bll.Delete(UID, PhotoCollectionID);
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", "-1"));
                }
                else
                {
                    WebApi_Model.T_Photo_Store model = new WebApi_Model.T_Photo_Store();
                    model.UID = UID;
                    model.PhotoCollectionID = PhotoCollectionID;
                    model.CreatDate = DateTime.Now;
                    tps_bll.Add(model);
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", "+1"));
                }
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(1, "Error", ex.Message));
            }
        }

        [HttpGet]
        public IHttpActionResult CheckStatus(int UID, int PhotoCollectionID)
        {
            WebApi_BLL.T_Photo_Likes tpl_bll = new WebApi_BLL.T_Photo_Likes();
            WebApi_BLL.T_Photo_Store tps_bll = new WebApi_BLL.T_Photo_Store();
            WebApi_BLL.T_Photo_Pay tppbll = new WebApi_BLL.T_Photo_Pay();
            bool IsLike = tpl_bll.Exists(UID, PhotoCollectionID);
            bool IsStore = tps_bll.Exists(UID, PhotoCollectionID);
            bool IsBuy = tps_bll.Exists(UID, PhotoCollectionID);
            ArrayList list = new ArrayList();
            Hashtable ht = new Hashtable();
            ht.Add("IsLike", IsLike);
            ht.Add("IsStore", IsStore);
            ht.Add("IsBuy", IsBuy);
            list.Add(ht);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(list)));
        }

        [HttpGet]
        public IHttpActionResult GetUserStoreByUID(int UID) {
            WebApi_BLL.T_Photo_Store tps_bll = new WebApi_BLL.T_Photo_Store();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(tps_bll.GetModelList("UID=" + UID))));
        }

        [HttpPost]
        public IHttpActionResult PayPhotoCollection()
        {
            try
            {
                int PhotoCollectionID = int.Parse(requestHelper.GetRequsetForm("PhotoCollectionID", ""));
                int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
                int PayWay = int.Parse(requestHelper.GetRequsetForm("PayWay", ""));

                WebApi_Model.T_Photo_Collection photomodel = bll.GetModel(PhotoCollectionID);
                WebApi_BLL.T_User tubll = new WebApi_BLL.T_User();
                WebApi_Model.T_User usermodel = tubll.GetModel(UID);
                if (photomodel == null || photomodel.IsActive != 1)
                {
                    return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild", "找不到该图集"));
                }

                if (usermodel == null)
                {
                    return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild", "找不到该用户信息"));
                }

                WebApi_BLL.T_Photo_Pay tppbll = new WebApi_BLL.T_Photo_Pay();
                List<WebApi_Model.T_Photo_Pay> list = tppbll.GetModelList(" PhotoCollectionID =" + PhotoCollectionID + " and UID = " + UID);

                if (list.Count > 0)
                {
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", list));
                }
                else {
                    if (PayWay == 1)
                    {
                        //瞟资查看
                        if (usermodel.PiaoZi >= photomodel.PiaoZi)
                        {
                            Hashtable newSqlList = new Hashtable();
                            newSqlList.Add("update T_User Set PiaoZi = (PiaoZi - " + photomodel.PiaoZi + ") where uid = @uid", new SqlParameter[] { new SqlParameter("@uid", UID) });
                            newSqlList.Add("INSERT INTO T_Photo_Pay (photoCollectionID,UID,BuyDate,PayWay,PayValue) values (@photoCollectionID,@UID,GETDATE(),@PayWay,@PayValue)", new SqlParameter[] { 
                                new SqlParameter("@photoCollectionID",PhotoCollectionID),new SqlParameter("@UID",UID),new SqlParameter("@PayWay",PayWay),new SqlParameter("@PayValue",photomodel.PiaoZi),
                            });
                            DBHelper.ExecuteSqlTranWithIndentity(newSqlList);
                            return Ok(ReturnJsonResult.GetJsonResult(-1, "OK", "瞟资不足"));
                        }
                        else
                        {
                            return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild", "瞟资不足"));
                        }
                    }

                    else if (PayWay == 2)
                    {
                        //腿毛
                        if (usermodel.TuiMao >= photomodel.TuiMao)
                        {
                            Hashtable newSqlList = new Hashtable();
                            newSqlList.Add("update T_User Set TuiMao = (TuiMao - " + photomodel.TuiMao + ") where uid = @uid", new SqlParameter[] { new SqlParameter("@uid", UID) });
                            newSqlList.Add("INSERT INTO T_Photo_Pay (photoCollectionID,UID,BuyDate,PayWay,PayValue) values (@photoCollectionID,@UID,GETDATE(),@PayWay,@PayValue)", new SqlParameter[] { 
                                new SqlParameter("@photoCollectionID",PhotoCollectionID),new SqlParameter("@UID",UID),new SqlParameter("@PayWay",PayWay),new SqlParameter("@PayValue",photomodel.TuiMao),
                            });
                            DBHelper.ExecuteSqlTranWithIndentity(newSqlList);
                            return Ok(ReturnJsonResult.GetJsonResult(-1, "OK", true));
                        }
                        else
                        {
                            return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild", "腿毛不足"));
                        }
                    }                    
                    else {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", ex.Message));
            }
        }
    }
}
    