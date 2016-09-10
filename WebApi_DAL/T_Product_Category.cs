using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_Category
    /// </summary>
    public partial class T_Product_Category
    {
        public T_Product_Category()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_Category(");
            strSql.Append("Leave,ParentID,CategoryName,CategoryICO)");
            strSql.Append(" values (");
            strSql.Append("@Leave,@ParentID,@CategoryName,@CategoryICO)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Leave", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@CategoryName", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryICO", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Leave;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.CategoryName;
            parameters[3].Value = model.CategoryICO;

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
        public bool Update(WebApi_Model.T_Product_Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_Category set ");
            strSql.Append("Leave=@Leave,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("CategoryName=@CategoryName,");
            strSql.Append("CategoryICO=@CategoryICO");
            strSql.Append(" where CategoryID=@CategoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@Leave", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@CategoryName", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryICO", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryID", SqlDbType.Int,4)};
            parameters[0].Value = model.Leave;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.CategoryName;
            parameters[3].Value = model.CategoryICO;
            parameters[4].Value = model.CategoryID;

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
        public bool Delete(int CategoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Category ");
            strSql.Append(" where CategoryID=@CategoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4)
			};
            parameters[0].Value = CategoryID;

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
        public bool DeleteList(string CategoryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Category ");
            strSql.Append(" where CategoryID in (" + CategoryIDlist + ")  ");
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
        public WebApi_Model.T_Product_Category GetModel(int CategoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CategoryID,Leave,ParentID,CategoryName,CategoryICO from T_Product_Category ");
            strSql.Append(" where CategoryID=@CategoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4)
			};
            parameters[0].Value = CategoryID;

            WebApi_Model.T_Product_Category model = new WebApi_Model.T_Product_Category();
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
        public WebApi_Model.T_Product_Category DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_Category model = new WebApi_Model.T_Product_Category();
            if (row != null)
            {
                if (row["CategoryID"] != null && row["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(row["CategoryID"].ToString());
                }
                if (row["Leave"] != null && row["Leave"].ToString() != "")
                {
                    model.Leave = int.Parse(row["Leave"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["CategoryName"] != null)
                {
                    model.CategoryName = row["CategoryName"].ToString();
                }
                if (row["CategoryICO"] != null)
                {
                    model.CategoryICO = row["CategoryICO"].ToString();
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
            strSql.Append("select CategoryID,Leave,ParentID,CategoryName,CategoryICO ");
            strSql.Append(" FROM T_Product_Category ");
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
            strSql.Append(" CategoryID,Leave,ParentID,CategoryName,CategoryICO ");
            strSql.Append(" FROM T_Product_Category ");
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
            strSql.Append("select count(1) FROM T_Product_Category ");
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
                strSql.Append("order by T.CategoryID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_Category T ");
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
            parameters[0].Value = "T_Product_Category";
            parameters[1].Value = "CategoryID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

