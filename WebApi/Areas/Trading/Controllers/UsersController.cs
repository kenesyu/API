using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Data;
using Newtonsoft.Json;

using WebApi_Common;
using WebApi_Model;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web.Hosting;

namespace WebApi.Areas.Trading.Controllers
{
    public class UsersController : ApiController
    {
        protected static WebApi_BLL.T_User bll = new WebApi_BLL.T_User();
        protected static WebApi_BLL.T_User_SMSCode bllsmscode = new WebApi_BLL.T_User_SMSCode();
        protected static RequestHelper requestHelper = new RequestHelper();

        #region ==== [Get方法] ====
        [HttpGet]
        public IHttpActionResult CheckUserExisting(string Tel)
        {
            DataSet ds = bll.CheckUserExisting(Tel);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "该用户已注册", false));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", true));
        }

        [HttpGet]
        public IHttpActionResult CheckNickNameExisting(string Nickname , int UID)
        {
            bool flag = bll.CheckNickNameExisting(Nickname, UID);
            if (!flag)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "该昵称已被注册", false));
            }
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", true));
        }

        [HttpGet]
        public IHttpActionResult GetUser(int UID) {
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(bll.GetModel(UID))));
        }

        #endregion

        #region ==== [Post方法] ====

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UserLogin()
        {
            string strUsername = requestHelper.GetRequsetForm("Username", "");
            string strPassword = requestHelper.GetRequsetForm("Password", "");
            WebApi_Model.T_User user = bll.Login(strUsername, strPassword);
            if (user == null)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "找不到用户", JsonConvert.SerializeObject(user)));
            }

            if (user.IsOnLine != 1)
            {
                user.IsOnLine = 1;
                user.LastLoginDate = DateTime.Now;
                bll.Update(user);
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(user)));
            }
            else {
                return Ok(ReturnJsonResult.GetJsonResult(1, "该用户正在被使用", JsonConvert.SerializeObject(user)));
            }

            
        }

        [HttpPost]
        public IHttpActionResult Logoff() {
            int UID = int.Parse(requestHelper.GetRequsetForm("UID", ""));
            bll.LogOff(UID);
            return Ok(ReturnJsonResult.GetJsonResult(1, "OK", ""));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UserRegister(dynamic model)
        {
            T_User user = (T_User)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(T_User));
            if (string.IsNullOrEmpty(user.Tel))
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "电话号码不能为空！", ""));
            }

            //if (!System.Text.RegularExpressions.Regex.IsMatch(user.Tel, @"^[1]+[3,5]+\d{9}"))
            //{
            //    return Ok(ReturnJsonResult.GetJsonResult(-1, "请输入正确的手机号！", ""));
            //}

            if (string.IsNullOrEmpty(user.Password))
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "密码不能为空！", ""));
            }

            int uid = bll.Add(user);
            user.UID = uid;

            if (user.UID.ToString() != "")
                return Ok(ReturnJsonResult.GetJsonResult(1, "注册成功！", JsonConvert.SerializeObject(user)));
            else
                return Ok(ReturnJsonResult.GetJsonResult(-1, "注册失败！", JsonConvert.SerializeObject(user)));
        }

        [HttpPost]
        public IHttpActionResult UploadImg()
        {
            try
            {
                int uid = Convert.ToInt32(requestHelper.GetRequsetForm("UID", ""));
                string Path = HttpContext.Current.Server.MapPath("/Content/User_Avatar/");
                HttpPostedFile file = HttpContext.Current.Request.Files[0];
                string fileExtName = file.FileName.Substring(file.FileName.LastIndexOf("."));
                string newName = Guid.NewGuid().ToString() + fileExtName;
                string savePath = Path + newName;
                file.SaveAs(savePath);
                if (bll.UpdateAvatar(uid, newName))
                {
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(newName)));
                }
                else
                {
                    return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild！", ""));
                }
            }
            catch (SystemException ex) {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild！", ex.Message));
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateUser(dynamic model)
        {
            try
            {
                T_User user = (T_User)Newtonsoft.Json.JsonConvert.DeserializeObject(model, typeof(T_User));
                if (bll.Update(model))
                {
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", true));
                }
                else
                {
                    return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", false));
                }
            }
            catch (Exception ex)
            {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Error", ex.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tel">电话号码</param>
        /// <param name="Type">1：注册码 2找回密码</param>
        [HttpPost]
        public IHttpActionResult SendSMSCode()
        {
            try
            {
                string strTel = requestHelper.GetRequsetForm("Tel", "");
                int    intType = int.Parse(requestHelper.GetRequsetForm("Type", ""));

                #region 类型2 找回密码先判断用户是否存在
                if (intType == 2)
                {
                    if (bll.GetModel(strTel) == null)
                    {
                        return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild！", "该手机号码未注册"));
                    }
                }
                #endregion


                string strMessage = string.Empty;
                string strCode = StringHelper.GenerateRandomNumber(6);
                if (intType == 1)
                    strMessage = "114059";
                else
                    strMessage = "114059";
                WebApi_Model.T_User_SMSCode model = new T_User_SMSCode();
                model.Active = 0;
                model.Code = strCode;
                model.Message = string.Format(strMessage, strCode);
                model.SendTime = DateTime.Now;
                model.OverDueTime = DateTime.Now.AddMinutes(30);
                model.Type = intType;
                model.Tel = strTel;
                model.CodeID = bllsmscode.Add(model);
                //暂不发送短信
                //SMSHelper.SendSMS(model.Tel, strMessage, new string[] { model.Code, "30" });
                return Ok(ReturnJsonResult.GetJsonResult(1, "OK", JsonConvert.SerializeObject(model)));
            }
            catch(Exception ex) {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild！", ex.Message));
            }
        }

        [HttpPost]
        public IHttpActionResult ResetPassword() {

            try
            {
                string strTel = requestHelper.GetRequsetForm("Tel", "");
                string strCode = requestHelper.GetRequsetForm("Code", "");
                string newPasswod = requestHelper.GetRequsetForm("Password", "");
                int CodeID = int.Parse(requestHelper.GetRequsetForm("CodeID", ""));

                T_User_SMSCode codeModel = bllsmscode.GetModel(CodeID);
                //DataSet ds = bllsmscode.GetList(" Tel = '" + strTel + "' and Code = '" + strCode + "' and Active = 0 and Type = 2 and OverDueTime >= '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' ");
                //bllsmscode.
                if (codeModel!=null && codeModel.Code == strCode && codeModel.OverDueTime > DateTime.Now)
                {
                    T_User user = bll.GetModel(strTel);
                    user.Password = newPasswod;
                    bll.ResetPassword(user);
                    codeModel.Active = 1;
                    bllsmscode.Update(codeModel);
                    return Ok(ReturnJsonResult.GetJsonResult(1, "OK", "密码修改成功"));
                }
                else {
                    return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild！", "Code Error"));
                }
            }
            catch (Exception ex) {
                return Ok(ReturnJsonResult.GetJsonResult(-1, "Faild！", ex.Message));
            }
        }
        #endregion
    }
}
