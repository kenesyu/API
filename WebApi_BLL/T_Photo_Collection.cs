using System;
using System.Data;
using System.Collections.Generic;

using WebApi_Model;
namespace WebApi_BLL
{
    /// <summary>
    /// 图集相关
    /// </summary>
    public partial class T_Photo_Collection
    {
        private readonly WebApi_DAL.T_Photo_Collection dal = new WebApi_DAL.T_Photo_Collection();
        public T_Photo_Collection()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Photo_Collection model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Photo_Collection model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PhotoCollectionID)
        {
            return dal.Delete(PhotoCollectionID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_Photo_Collection GetModel(int PhotoCollectionID)
        {
            WebApi_Model.T_Photo_Collection model = dal.GetModel(PhotoCollectionID);
            if (model != null) {
                WebApi_BLL.T_Photo_Details tpd_bll = new T_Photo_Details();
                model.PhotoDetails = tpd_bll.GetModelList("PhotoCollectionID =" + PhotoCollectionID);
            }
            return model;
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
        public List<WebApi_Model.T_Photo_Collection> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WebApi_Model.T_Photo_Collection> DataTableToList(DataTable dt)
        {
            List<WebApi_Model.T_Photo_Collection> modelList = new List<WebApi_Model.T_Photo_Collection>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WebApi_Model.T_Photo_Collection model;
                WebApi_BLL.T_PhotoTag tagbll = new T_PhotoTag();
                for (int n = 0; n < rowsCount; n++)
                {
                    
                    model = dal.DataRowToModel(dt.Rows[n]);
                    model.PhotoTag = tagbll.GetModelList(" PhotoTagID in (0" + model.PhotoTagID + ")");
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

