using System;
using System.Data;
using System.Collections.Generic;

using WebApi_Model;
namespace WebApi_BLL
{
    /// <summary>
    /// T_RechargeType
    /// </summary>
    public partial class T_RechargeType
    {
        private readonly WebApi_DAL.T_RechargeType dal = new WebApi_DAL.T_RechargeType();
        public T_RechargeType()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_RechargeType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_RechargeType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RechargeID)
        {
            return dal.Delete(RechargeID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RechargeIDlist)
        {
            return false;
            //return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(RechargeIDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_RechargeType GetModel(int RechargeID)
        {

            return dal.GetModel(RechargeID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public WebApi_Model.T_RechargeType GetModelByCache(int RechargeID)
        {

            return null;
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
        public List<WebApi_Model.T_RechargeType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_RechargeType> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_RechargeType> modelList = new List<WebApi_Model.T_RechargeType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_RechargeType model;
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

