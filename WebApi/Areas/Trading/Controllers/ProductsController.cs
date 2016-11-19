using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_Common;
using WebApi_DBUtility;
using WebApi_Model;


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

            //string[] a = new string[] { "1", "2", "3" };
            //string[] b = new string[] { "4", "5", "6" };
            //string[] c = new string[] { "8", "9" };
            //List<string[]> al = new List<string[]>();
            //al.Add(a);
            //al.Add(b);
            //al.Add(c);
            //string[] mmm;
            //mmm = StringHelper.BianLi(al);


            //List<WebApi_Model.T_RechargeType> list = bll.DataTableToList(bll.GetAllList().Tables[0]);
            if (newProduct == null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "没有找到商品信息", JsonConvert.SerializeObject(newProduct)));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(newProduct)));
        }

        [HttpGet]
        public IHttpActionResult GetProductActivity()
        {
            WebApi_BLL.T_Product_Activity tpa_bll = new WebApi_BLL.T_Product_Activity();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(tpa_bll.GetModelList(""))));
        }

        [HttpGet]
        public IHttpActionResult GetProductHot()
        {
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
            //list.Find(

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

        [HttpPost]
        public IHttpActionResult CreateOrder(dynamic model)
        {
            //string testjson = "{\n  \"UID\" : 10,\n  \"OrderDetails\" : [\n    {\n      \"ProductID\" : 3,\n      \"ProductExtID\" : 2,\n      \"Qty\" : \"1\"\n    }\n  ],\n  \"AddressID\" : 7,\n  \"ProductQty\" : 1\n}";

            T_Product_Orders Order = (T_Product_Orders)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(T_Product_Orders));

            DateTime dtNow = DateTime.Now;

            if (Order.OrderDetails == null || Order.OrderDetails.Count == 0)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "没有商品"));
            }
            else
            {
                decimal TotalAmount = 0;
                WebApi_BLL.T_Product_Ext tpebll = new WebApi_BLL.T_Product_Ext();
                for (int i = 0; i < Order.OrderDetails.Count; i++)
                {
                    WebApi_Model.T_Product_Ext ext = tpebll.GetModel((int)Order.OrderDetails[i].ProductExtID);
                    TotalAmount += (decimal)(Order.OrderDetails[i].Qty * ext.Price);
                }
                Order.TotalAmount = TotalAmount;
            }

            Order.OrderNum = dtNow.Ticks.ToString();
            Order.OrderDateTime = dtNow;
            Order.Status = 0;
            WebApi_BLL.T_Product_Orders OrderBll = new WebApi_BLL.T_Product_Orders();
            int id = OrderBll.Add(Order);

            WebApi_BLL.T_Product_OrderDetails OrderDetailsBll = new WebApi_BLL.T_Product_OrderDetails();
            T_Product_Orders retOrder = new T_Product_Orders();
            retOrder = OrderBll.GetModel(id);
            retOrder.OrderDetails = OrderDetailsBll.GetModelList(" OrderID =" + id);

            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(retOrder)));
        }

        [HttpGet]
        public IHttpActionResult GetUserOrderList(int UID)
        {
            WebApi_BLL.T_Product_Orders OrderBll = new WebApi_BLL.T_Product_Orders();
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(OrderBll.GetModelList(" UID=" + UID))));
        }

        [HttpGet]
        public IHttpActionResult GetOrderByOrderID(int OrderID)
        {
            WebApi_BLL.T_Product_Orders OrderBll = new WebApi_BLL.T_Product_Orders();
            WebApi_BLL.T_Product_OrderDetails OrderDetailsBll = new WebApi_BLL.T_Product_OrderDetails();
            T_Product_Orders retOrder = new T_Product_Orders();
            retOrder = OrderBll.GetModel(OrderID);
            if (retOrder != null)
            {
                retOrder.OrderDetails = OrderDetailsBll.GetModelList(" OrderID =" + OrderID);
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(retOrder)));
        }

        /// <summary>
        /// 加入到购物车
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddShopCar(dynamic model)
        {
            WebApi_BLL.T_User_ShopCar shopCar_bll = new WebApi_BLL.T_User_ShopCar();
            T_User_ShopCar shopCar = (T_User_ShopCar)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(T_User_ShopCar));
            shopCar_bll.Add(shopCar);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", true));
        }

        /// <summary>
        /// 获取用户购物车
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUserShopCar(int UID)
        {
            WebApi_BLL.T_User_ShopCar shopCar_bll = new WebApi_BLL.T_User_ShopCar();
            List<T_User_ShopCar> shopCarList = shopCar_bll.GetModelList("UID = " + UID);

            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(shopCarList)));
        }

        [HttpPost]
        public IHttpActionResult CleanShopCar()
        {
            int UID = int.Parse(requestHelper.GetRequsetForm("UID",""));
            WebApi_BLL.T_User_ShopCar shopCar_bll = new WebApi_BLL.T_User_ShopCar();
            
            List<T_User_ShopCar> shopCarList = shopCar_bll.GetModelList("UID = " + UID);
            for (int i = 0; i < shopCarList.Count; i++)
            {
                shopCar_bll.Delete(shopCarList[i].ShopCarID);
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(shopCarList)));
        }

        [HttpPost]
        public IHttpActionResult DeleteShopCar()
        {
            //int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
            string ShopCarID = requestHelper.GetRequsetForm("ShopCarID", "");
            WebApi_BLL.T_User_ShopCar shopCar_bll = new WebApi_BLL.T_User_ShopCar();
            //shopCar_bll.Delete(ShopCarID);
            //List<T_User_ShopCar> shopCarList = shopCar_bll.GetModelList("UID = " + UID);
            DBHelper.ExecuteSql("delete FROM T_User_ShopCar where ShopCarID in (" + ShopCarID + ")");
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", true));
        }

        [HttpPost]
        public IHttpActionResult CheckOrder()
        {
            string msg = requestHelper.GetRequsetForm("msg", "");
            string timestamp = requestHelper.GetRequsetForm("timestamp", "");
            string total_amount = requestHelper.GetRequsetForm("total_amount", "");
            string trade_no = requestHelper.GetRequsetForm("trade_no", "");
            string out_trade_no = requestHelper.GetRequsetForm("out_trade_no", "");
            string resultStatus = requestHelper.GetRequsetForm("resultStatus", "");

            WebApi_BLL.T_Product_Orders OrderBll = new WebApi_BLL.T_Product_Orders();

            List<WebApi_Model.T_Product_Orders> orders = OrderBll.GetModelList("OrderNum='" + out_trade_no + "'");

            if (orders.Count == 1)
            {
                if (msg == "Success" && resultStatus == "9000")
                {
                    if (Convert.ToDecimal(total_amount) != orders[0].TotalAmount)
                    {
                        return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "支付金额与订单金额不同"));
                    }
                    else
                    {
                        orders[0].Out_Trade_No = trade_no;  //支付宝订单号
                        orders[0].Status = 1;
                        orders[0].PayTime = DateTime.Now;
                        orders[0].PayMethod = "AliPay";
                        OrderBll.Update(orders[0]);
                    }
                }
                else
                {
                    return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "返回Msg非Success或Code非9000"));
                }
            }
            else
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", "无法找到订单或订单异常"));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(orders[0])));
        }

        #endregion


    }
}