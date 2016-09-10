using System;
using System.Data;
using System.Collections.Generic;
using WebApi_Model;
namespace WebApi_BLL
{
    /// <summary>
    /// T_UserRecharge
    /// </summary>
    public partial class T_UserRecharge
    {
        private readonly WebApi_DAL.T_UserRecharge dal = new WebApi_DAL.T_UserRecharge();
        public T_UserRecharge()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID, int RechargeID, DateTime RechargeDate)
        {
            return dal.Exists(UID, RechargeID, RechargeDate);
        }

        public WebApi_Model.T_User UserRecharge(WebApi_Model.T_User user, WebApi_Model.T_RechargeType rechargetype)
        {
            return dal.UserRecharge(user, rechargetype);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebApi_Model.T_UserRecharge model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_UserRecharge model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UID, int RechargeID, DateTime RechargeDate)
        {

            return dal.Delete(UID, RechargeID, RechargeDate);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_UserRecharge GetModel(int UID, int RechargeID, DateTime RechargeDate)
        {

            return dal.GetModel(UID, RechargeID, RechargeDate);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>

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
        public List<WebApi_Model.T_UserRecharge> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_UserRecharge> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_UserRecharge> modelList = new List<WebApi_Model.T_UserRecharge>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_UserRecharge model;
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

