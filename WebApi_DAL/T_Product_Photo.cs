using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_Photo
    /// </summary>
    public partial class T_Product_Photo
    {
        public T_Product_Photo()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_Photo(");
            strSql.Append("ProductID,ImgPath,ImgRemark,ImgType,Sorting)");
            strSql.Append(" values (");
            strSql.Append("@ProductID,@ImgPath,@ImgRemark,@ImgType,@Sorting)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,32),
					new SqlParameter("@ImgRemark", SqlDbType.NVarChar,40),
					new SqlParameter("@ImgType", SqlDbType.Int,4),
					new SqlParameter("@Sorting", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.ImgPath;
            parameters[2].Value = model.ImgRemark;
            parameters[3].Value = model.ImgType;
            parameters[4].Value = model.Sorting;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Product_Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_Photo set ");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("ImgPath=@ImgPath,");
            strSql.Append("ImgRemark=@ImgRemark,");
            strSql.Append("ImgType=@ImgType,");
            strSql.Append("Sorting=@Sorting");
            strSql.Append(" where ProductPhotoID=@ProductPhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,32),
					new SqlParameter("@ImgRemark", SqlDbType.NVarChar,40),
					new SqlParameter("@ImgType", SqlDbType.Int,4),
					new SqlParameter("@Sorting", SqlDbType.Int,4),
					new SqlParameter("@ProductPhotoID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.ImgPath;
            parameters[2].Value = model.ImgRemark;
            parameters[3].Value = model.ImgType;
            parameters[4].Value = model.Sorting;
            parameters[5].Value = model.ProductPhotoID;

            int rows = DBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ProductPhotoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Photo ");
            strSql.Append(" where ProductPhotoID=@ProductPhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductPhotoID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProductPhotoID;

            int rows = DBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ProductPhotoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Photo ");
            strSql.Append(" where ProductPhotoID in (" + ProductPhotoIDlist + ")  ");
            int rows = DBHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_Product_Photo GetModel(int ProductPhotoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductPhotoID,ProductID,ImgPath,ImgRemark,ImgType,Sorting from T_Product_Photo ");
            strSql.Append(" where ProductPhotoID=@ProductPhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductPhotoID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProductPhotoID;

            WebApi_Model.T_Product_Photo model = new WebApi_Model.T_Product_Photo();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_Product_Photo DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_Photo model = new WebApi_Model.T_Product_Photo();
            if (row != null)
            {
                if (row["ProductPhotoID"] != null && row["ProductPhotoID"].ToString() != "")
                {
                    model.ProductPhotoID = int.Parse(row["ProductPhotoID"].ToString());
                }
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(row["ProductID"].ToString());
                }
                if (row["ImgPath"] != null)
                {
                    model.ImgPath = row["ImgPath"].ToString();
                }
                if (row["ImgRemark"] != null)
                {
                    model.ImgRemark = row["ImgRemark"].ToString();
                }
                if (row["ImgType"] != null && row["ImgType"].ToString() != "")
                {
                    model.ImgType = int.Parse(row["ImgType"].ToString());
                }
                if (row["Sorting"] != null && row["Sorting"].ToString() != "")
                {
                    model.Sorting = int.Parse(row["Sorting"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductPhotoID,ProductID,ImgPath,ImgRemark,ImgType,Sorting ");
            strSql.Append(" FROM T_Product_Photo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ProductPhotoID,ProductID,ImgPath,ImgRemark,ImgType,Sorting ");
            strSql.Append(" FROM T_Product_Photo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_Product_Photo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DBHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ProductPhotoID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_Photo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "T_Product_Photo";
            parameters[1].Value = "ProductPhotoID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

