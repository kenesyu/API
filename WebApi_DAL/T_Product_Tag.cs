using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
using System.Collections.Generic;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_Tag
    /// </summary>
    public partial class T_Product_Tag
    {
        public T_Product_Tag()
        { }

        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Tag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_Tag(");
            strSql.Append("TagName)");
            strSql.Append(" values (");
            strSql.Append("@TagName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TagName", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.TagName;

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
        public bool Update(WebApi_Model.T_Product_Tag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_Tag set ");
            strSql.Append("TagName=@TagName");
            strSql.Append(" where TagID=@TagID");
            SqlParameter[] parameters = {
					new SqlParameter("@TagName", SqlDbType.NVarChar,30),
					new SqlParameter("@TagID", SqlDbType.Int,4)};
            parameters[0].Value = model.TagName;
            parameters[1].Value = model.TagID;

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
        public bool Delete(int TagID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Tag ");
            strSql.Append(" where TagID=@TagID");
            SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)
			};
            parameters[0].Value = TagID;

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
        public bool DeleteList(string TagIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Tag ");
            strSql.Append(" where TagID in (" + TagIDlist + ")  ");
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
        public WebApi_Model.T_Product_Tag GetModel(int TagID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TagID,TagName from T_Product_Tag ");
            strSql.Append(" where TagID=@TagID");
            SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)
			};
            parameters[0].Value = TagID;

            WebApi_Model.T_Product_Tag model = new WebApi_Model.T_Product_Tag();
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
        public WebApi_Model.T_Product_Tag DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_Tag model = new WebApi_Model.T_Product_Tag();
            if (row != null)
            {
                if (row["TagID"] != null && row["TagID"].ToString() != "")
                {
                    model.TagID = int.Parse(row["TagID"].ToString());
                }
                if (row["TagName"] != null)
                {
                    model.TagName = row["TagName"].ToString();
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
            strSql.Append("select TagID,TagName ");
            strSql.Append(" FROM T_Product_Tag ");
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
            strSql.Append(" TagID,TagName ");
            strSql.Append(" FROM T_Product_Tag ");
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
            strSql.Append("select count(1) FROM T_Product_Tag ");
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
                strSql.Append("order by T.TagID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_Tag T ");
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
            parameters[0].Value = "T_Product_Tag";
            parameters[1].Value = "TagID";
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

