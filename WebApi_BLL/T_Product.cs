using System;
using System.Data;
using System.Collections.Generic;
using WebApi_Model;

namespace WebApi_BLL
{
    /// <summary>
    /// T_Product
    /// </summary>
    public partial class T_Product
    {
        private readonly WebApi_DAL.T_Product dal = new WebApi_DAL.T_Product();
        private readonly WebApi_DAL.T_Product_Tag dal_product_tag = new WebApi_DAL.T_Product_Tag();
        public T_Product()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Product model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ProductID)
        {

            return dal.Delete(ProductID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_Product GetDetailsByID(int ProductID ,bool Lazy)
        {
            WebApi_Model.T_Product product = new WebApi_Model.T_Product();
            product = dal.GetModel(ProductID);
            if (product != null)
            {
                WebApi_BLL.T_Product_Tag tpg_bll = new T_Product_Tag();
                WebApi_BLL.T_Product_Category tpc_bll = new T_Product_Category();
                product.Product_Tag = tpg_bll.GetModelList(" tagID in (0" + product.TagID + ")");
                product.CategoryName1 = tpc_bll.GetModel(Convert.ToInt32(product.Category1)).CategoryName;
                product.CategoryName2 = tpc_bll.GetModel(Convert.ToInt32(product.Category2)).CategoryName;

                if (!Lazy)
                {
                    WebApi_BLL.T_Product_Photo tpp_bll = new T_Product_Photo();
                    //图片
                    product.Product_Photo = tpp_bll.GetModelList(" ImgType = 0 and ProductID =" + product.ProductID);
                    //图文详情
                    product.Product_Photo_Details = tpp_bll.GetModelList(" ImgType = 1 and ProductID =" + product.ProductID);
                    WebApi_BLL.T_Product_Ext tpe_bll = new T_Product_Ext();
                    product.Product_Ext = tpe_bll.GetModelList(" ProductID = " + product.ProductID);
                    //product.Product_Ext = 
                }
            }

            return product;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        //public DataSet GetList(int Page, int PageSize, string strWhere, string strOrder, out int TotalPage)
        //{ 
        //    return dal.GetListByPage(Page,PageSize,strWhere,strOrder,out TotalPage);
        //}

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
        public List<WebApi_Model.T_Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_Product> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_Product> modelList = new List<WebApi_Model.T_Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_Product model;
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
        //public DataSet GetListByPage(int Page, int PageSize, string strWhere ,string strOrder, out int TotalPage)
        //{
        //    return dal.GetListByPage(Page, PageSize, strWhere, strOrder, out TotalPage);
        //}
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

