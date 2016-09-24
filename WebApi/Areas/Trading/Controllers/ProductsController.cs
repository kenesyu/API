using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_Common;
using WebApi_DBUtility;


namespace WebApi.Areas.Trading.Controllers
{
    public class ProductsController : ApiController
    {
        protected static WebApi_BLL.T_Product bll = new WebApi_BLL.T_Product();
        protected static RequestHelper requestHelper = new RequestHelper();

        #region
        [HttpGet]
        public IHttpActionResult GetProductByID(int ProductID,bool IsLazy)
        {
            WebApi_Model.T_Product newProduct = bll.GetDetailsByID(ProductID, IsLazy);

            //List<WebApi_Model.T_RechargeType> list = bll.DataTableToList(bll.GetAllList().Tables[0]);
            if (newProduct == null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "没有找到商品信息", JsonConvert.SerializeObject(newProduct)));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(newProduct)));
        }

        [HttpGet]
        public IHttpActionResult GetProductActivity() {
            WebApi_BLL.T_Product_Activity tpa_bll = new WebApi_BLL.T_Product_Activity();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(tpa_bll.GetModelList(""))));
        }

        [HttpGet]
        public IHttpActionResult GetProductHot() {
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList("OnSale =1 and IsHot=1"))));
        }

        [HttpGet]
        public IHttpActionResult GetProductNew()
        {
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList("OnSale =1 and IsNew=1"))));
        }

        [HttpPost]
        public IHttpActionResult GetProductList()
        {
            int Page = int.Parse(requestHelper.GetRequsetForm("Page", ""));
            string strWhere = requestHelper.GetRequsetForm("strWhere", "");
            string strOrder = requestHelper.GetRequsetForm("strOrder", "");
            int TotalPage = 0;
            int PageSize = 10;
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1 = 1";
            }

            if (string.IsNullOrEmpty(strOrder)) {
                strOrder = " ProductID desc";
            }

            List<WebApi_Model.T_Product> list = bll.DataTableToList(DBHelper.GetListByPage("T_Product", Page, PageSize, strWhere, strOrder, out TotalPage).Tables[0]);
            //List<WebApi_Model.T_Product> list = bll.DataTableToList(bll.GetListByPage(Page, PageSize, strWhere, strOrder, out TotalPage).Tables[0]);
            if (list != null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(1, TotalPage.ToString(), JsonConvert.SerializeObject(list)));
            }
            else {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "OK", ""));
            }
        }

        [HttpGet]
        public IHttpActionResult GetProductCategory()
        {
            WebApi_BLL.T_Product_Category bll = new WebApi_BLL.T_Product_Category();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(""))));
        }

        [HttpGet]
        public IHttpActionResult GetProductCategoryByParentID(int ParentID)
        {
            WebApi_BLL.T_Product_Category bll = new WebApi_BLL.T_Product_Category();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModelList(" ParentID = " + ParentID))));
        }

        #endregion


    }
}