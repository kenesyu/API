﻿using System;
using System.Data;
using System.Collections.Generic;

using WebApi_Model;
namespace WebApi_BLL
{
    /// <summary>
    /// 用户点赞表
    /// </summary>
    public partial class T_Photo_Likes
    {
        private readonly WebApi_DAL.T_Photo_Likes dal = new WebApi_DAL.T_Photo_Likes();
        public T_Photo_Likes()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID, int PhotoCollectionID)
        {
            return dal.Exists(UID, PhotoCollectionID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebApi_Model.T_Photo_Likes model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Photo_Likes model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UID, int PhotoCollectionID)
        {

            return dal.Delete(UID, PhotoCollectionID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_Photo_Likes GetModel(int UID, int PhotoCollectionID, DateTime CreateTime)
        {

            return dal.GetModel(UID, PhotoCollectionID, CreateTime);
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
        public List<WebApi_Model.T_Photo_Likes> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_Photo_Likes> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_Photo_Likes> modelList = new List<WebApi_Model.T_Photo_Likes>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_Photo_Likes model;
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

