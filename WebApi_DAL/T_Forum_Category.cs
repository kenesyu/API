using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Forum_Category
    /// </summary>
    public partial class T_Forum_Category
    {
        public T_Forum_Category()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Forum_Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Forum_Category(");
            strSql.Append("Level,CategoryName,CategoryICO,ParentID)");
            strSql.Append(" values (");
            strSql.Append("@Level,@CategoryName,@CategoryICO,@ParentID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@CategoryName", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryICO", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4)};
            parameters[0].Value = model.Level;
            parameters[1].Value = model.CategoryName;
            parameters[2].Value = model.CategoryICO;
            parameters[3].Value = model.ParentID;

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
        public bool Update(WebApi_Model.T_Forum_Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Forum_Category set ");
            strSql.Append("Level=@Level,");
            strSql.Append("CategoryName=@CategoryName,");
            strSql.Append("CategoryICO=@CategoryICO,");
            strSql.Append("ParentID=@ParentID");
            strSql.Append(" where ForumCategoryID=@ForumCategoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@CategoryName", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryICO", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ForumCategoryID", SqlDbType.Int,4)};
            parameters[0].Value = model.Level;
            parameters[1].Value = model.CategoryName;
            parameters[2].Value = model.CategoryICO;
            parameters[3].Value = model.ParentID;
            parameters[4].Value = model.ForumCategoryID;

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
        public bool Delete(int ForumCategoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forum_Category ");
            strSql.Append(" where ForumCategoryID=@ForumCategoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumCategoryID", SqlDbType.Int,4)
			};
            parameters[0].Value = ForumCategoryID;

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
        public bool DeleteList(string ForumCategoryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forum_Category ");
            strSql.Append(" where ForumCategoryID in (" + ForumCategoryIDlist + ")  ");
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
        public WebApi_Model.T_Forum_Category GetModel(int ForumCategoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ForumCategoryID,Level,CategoryName,CategoryICO,ParentID from T_Forum_Category ");
            strSql.Append(" where ForumCategoryID=@ForumCategoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumCategoryID", SqlDbType.Int,4)
			};
            parameters[0].Value = ForumCategoryID;

            WebApi_Model.T_Forum_Category model = new WebApi_Model.T_Forum_Category();
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
        public WebApi_Model.T_Forum_Category DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Forum_Category model = new WebApi_Model.T_Forum_Category();
            if (row != null)
            {
                if (row["ForumCategoryID"] != null && row["ForumCategoryID"].ToString() != "")
                {
                    model.ForumCategoryID = int.Parse(row["ForumCategoryID"].ToString());
                }
                if (row["Level"] != null && row["Level"].ToString() != "")
                {
                    model.Level = int.Parse(row["Level"].ToString());
                }
                if (row["CategoryName"] != null)
                {
                    model.CategoryName = row["CategoryName"].ToString();
                }
                if (row["CategoryICO"] != null)
                {
                    model.CategoryICO = row["CategoryICO"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
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
            strSql.Append("select ForumCategoryID,Level,CategoryName,CategoryICO,ParentID ");
            strSql.Append(" FROM T_Forum_Category ");
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
            strSql.Append(" ForumCategoryID,Level,CategoryName,CategoryICO,ParentID ");
            strSql.Append(" FROM T_Forum_Category ");
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
            strSql.Append("select count(1) FROM T_Forum_Category ");
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
                strSql.Append("order by T.ForumCategoryID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Forum_Category T ");
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
            parameters[0].Value = "T_Forum_Category";
            parameters[1].Value = "ForumCategoryID";
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

