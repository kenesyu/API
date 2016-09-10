using System;
using System.Data;
using System.Collections.Generic;
using WebApi_Model;
using WebApi_DBUtility;

namespace WebApi_BLL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class T_User
    {
        private readonly WebApi_DAL.T_User dal = new WebApi_DAL.T_User();
        public T_User()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID)
        {
            return dal.Exists(UID);
        }

        public WebApi_Model.T_User Login(string Username,string Password)
        {
            return dal.GetModel(Username, Password);
        }


        public DataSet CheckUserExisting(string Tel)
        {
            return dal.GetList(" Tel = '" + Tel + "'");
        }

        public bool UpdateAvatar(int UID,string NewName) {
            return dal.UpdateAvatar(UID, NewName);
        }

        public bool CheckNickNameExisting(string Nickname, int UID)
        {
            string strWhere = string.Empty;

            if (UID == 0)
            {
                //New Register
                strWhere = " Nickname = '" + DBHelper.Rep(Nickname) + "'";
            }
            else
            {
                //Update
                strWhere = " Nickname = '" + DBHelper.Rep(Nickname) + "' and UID != '" + UID + "'";
            }

            #region
            DataSet ds = dal.GetList(strWhere);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_User model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_User model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool ResetPassword(WebApi_Model.T_User model)
        {
            return dal.ResetPassword(model);
        }

        public bool LogOff(int UID) {
            return dal.LogOff(UID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UID)
        {

            return dal.Delete(UID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_User GetModel(int UID)
        {

            return dal.GetModel(UID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_User GetModel(string Tel)
        {

            return dal.GetModel(Tel);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_User> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_User> modelList = new List<WebApi_Model.T_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

