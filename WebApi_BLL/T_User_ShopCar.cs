using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
using WebApi_Model;
namespace WebApi_BLL
{
    /// <summary>
    /// 购物车
    /// </summary>
    public partial class T_User_ShopCar
    {
        private readonly WebApi_DAL.T_User_ShopCar dal = new WebApi_DAL.T_User_ShopCar();
        public T_User_ShopCar()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_User_ShopCar model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_User_ShopCar model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ShopCarID)
        {

            return dal.Delete(ShopCarID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_User_ShopCar GetModel(int ShopCarID)
        {

            return dal.GetModel(ShopCarID);
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
        public List<WebApi_Model.T_User_ShopCar> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_User_ShopCar> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_User_ShopCar> modelList = new List<WebApi_Model.T_User_ShopCar>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_User_ShopCar model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        T_Product pbll = new T_Product();
                        model.Product = pbll.GetDetailsByID((int)model.ProductID, true);
                        T_Product_Ext tpebll = new T_Product_Ext();
                        model.Product_Ext = tpebll.GetModel((int)model.ProductExtID);

                        //if (model.Product_Ext != null)
                        //{
                        //    if (model.Product_Ext.Property != null && model.Product_Ext.Property != "") {
                        //        T_Product_Property tppbll = new T_Product_Property();
                        //        List<WebApi_Model.T_Product_Property> list = new List<WebApi_Model.T_Product_Property>();
                        //        string[] key = model.Product_Ext.Property.Split(',');
                        //        for (int i = 0; i < key.Length; i++) {
                        //            list.Add(tppbll.GetModel(int.Parse(key[i])));
                        //        }
                        //        model.Product_Property = list;
                        //    }

                        //}
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

