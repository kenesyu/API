﻿using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
using WebApi_Model;
namespace WebApi_BLL
{
    /// <summary>
    /// 订单
    /// </summary>
    public partial class T_Product_Orders
    {
        private readonly WebApi_DAL.T_Product_Orders dal = new WebApi_DAL.T_Product_Orders();
        public T_Product_Orders()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Orders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Product_Orders model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int OrderID)
        {

            return dal.Delete(OrderID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_Product_Orders GetModel(int OrderID)
        {

            return dal.GetModel(OrderID);
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
        public List<WebApi_Model.T_Product_Orders> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_Product_Orders> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_Product_Orders> modelList = new List<WebApi_Model.T_Product_Orders>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_Product_Orders model;
                T_Product_OrderDetails orderDetailsBll = new T_Product_OrderDetails();
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);

                    model.OrderDetails = orderDetailsBll.GetModelList(" OrderID =" + model.OrderID);
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

