using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using WebApi_Common;
using WebApi_Model;
using Newtonsoft.Json;
using System.Web;


namespace WebApi.Areas.Trading.Controllers
{
    public class UserAddressController : ApiController
    {
        protected static WebApi_BLL.T_UserAddress bll = new WebApi_BLL.T_UserAddress();
        protected static RequestHelper requestHelper = new RequestHelper();

        [HttpPost]
        public IHttpActionResult SaveNewAddress(dynamic model)
        {
            try
            {
                T_UserAddress useraddress = (T_UserAddress)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(T_UserAddress));
                int id = bll.Add(useraddress);
                useraddress.AddressID = id;
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(useraddress)));
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, ex.Message.ToString(),JsonConvert.SerializeObject(model)));
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateAddress(dynamic model)
        {
            try
            {
                T_UserAddress useraddress = (T_UserAddress)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(T_UserAddress));
                bool falg = bll.Update(useraddress);
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(useraddress)));
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, ex.Message.ToString(), JsonConvert.SerializeObject(model)));
            }
        } 

        [HttpPost]
        public IHttpActionResult DeleteAddress()
        {
            try
            {
                int AddressID = int.Parse(requestHelper.GetRequsetForm("AddressID", ""));
                bool falg = bll.Delete(AddressID);
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", true));
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, ex.Message.ToString(), false));
            }
        }

        [HttpGet]
        public IHttpActionResult GetAddressListByUID(int UID)
        {
            try
            {
                string strWhere = " UID = '" + UID + "'";
                List<T_UserAddress> list = bll.GetModelList(strWhere);
                //int AddressID = int.Parse(requestHelper.GetRequsetForm("AddressID", ""));
                //bool falg = bll.Delete(AddressID);
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(list)));
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, ex.Message.ToString(), false));
            }
        }

        [HttpGet]
        public IHttpActionResult GetAddressByID(int AddressID) {
            //string strWhere = " UID = '" + UID + "'";
            //List<T_UserAddress> list = bll.GetModelList(strWhere);
            //int AddressID = int.Parse(requestHelper.GetRequsetForm("AddressID", ""));
            //bool falg = bll.Delete(AddressID);
            T_UserAddress Address = bll.GetModel(AddressID);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(Address)));
        }

    }
}
