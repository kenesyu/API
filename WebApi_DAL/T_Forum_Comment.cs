using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Forum_Comment
    /// </summary>
    public partial class T_Forum_Comment
    {
        public T_Forum_Comment()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Forum_Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Forum_Comment(");
            strSql.Append("UID,CommentDate,Comment,Likes,GiftCount,ForumID,CID,Status)");
            strSql.Append(" values (");
            strSql.Append("@UID,@CommentDate,@Comment,@Likes,@GiftCount,@ForumID,@CID,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@CommentDate", SqlDbType.DateTime),
					new SqlParameter("@Comment", SqlDbType.NVarChar,4000),
					new SqlParameter("@Likes", SqlDbType.Int,4),
					new SqlParameter("@GiftCount", SqlDbType.Int,4),
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.CommentDate;
            parameters[2].Value = model.Comment;
            parameters[3].Value = model.Likes;
            parameters[4].Value = model.GiftCount;
            parameters[5].Value = model.ForumID;
            parameters[6].Value = model.CID;
            parameters[7].Value = model.Status;

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
        public bool Update(WebApi_Model.T_Forum_Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Forum_Comment set ");
            strSql.Append("UID=@UID,");
            strSql.Append("CommentDate=@CommentDate,");
            strSql.Append("Comment=@Comment,");
            strSql.Append("Likes=@Likes,");
            strSql.Append("GiftCount=@GiftCount,");
            strSql.Append("ForumID=@ForumID,");
            strSql.Append("CID=@CID,");
            strSql.Append("Status=@Status");
            strSql.Append(" where CommentID=@CommentID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@CommentDate", SqlDbType.DateTime),
					new SqlParameter("@Comment", SqlDbType.NVarChar,4000),
					new SqlParameter("@Likes", SqlDbType.Int,4),
					new SqlParameter("@GiftCount", SqlDbType.Int,4),
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CommentID", SqlDbType.Int,4)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.CommentDate;
            parameters[2].Value = model.Comment;
            parameters[3].Value = model.Likes;
            parameters[4].Value = model.GiftCount;
            parameters[5].Value = model.ForumID;
            parameters[6].Value = model.CID;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.CommentID;

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
        public bool Delete(int CommentID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forum_Comment ");
            strSql.Append(" where CommentID=@CommentID");
            SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.Int,4)
			};
            parameters[0].Value = CommentID;

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
        public bool DeleteList(string CommentIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forum_Comment ");
            strSql.Append(" where CommentID in (" + CommentIDlist + ")  ");
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
        public WebApi_Model.T_Forum_Comment GetModel(int CommentID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CommentID,UID,CommentDate,Comment,Likes,GiftCount,ForumID,CID,Status from T_Forum_Comment ");
            strSql.Append(" where CommentID=@CommentID");
            SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.Int,4)
			};
            parameters[0].Value = CommentID;

            WebApi_Model.T_Forum_Comment model = new WebApi_Model.T_Forum_Comment();
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
        public WebApi_Model.T_Forum_Comment DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Forum_Comment model = new WebApi_Model.T_Forum_Comment();
            if (row != null)
            {
                if (row["CommentID"] != null && row["CommentID"].ToString() != "")
                {
                    model.CommentID = int.Parse(row["CommentID"].ToString());
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["CommentDate"] != null && row["CommentDate"].ToString() != "")
                {
                    model.CommentDate = DateTime.Parse(row["CommentDate"].ToString());
                }
                if (row["Comment"] != null)
                {
                    model.Comment = row["Comment"].ToString();
                }
                if (row["Likes"] != null && row["Likes"].ToString() != "")
                {
                    model.Likes = int.Parse(row["Likes"].ToString());
                }
                if (row["GiftCount"] != null && row["GiftCount"].ToString() != "")
                {
                    model.GiftCount = int.Parse(row["GiftCount"].ToString());
                }
                if (row["ForumID"] != null && row["ForumID"].ToString() != "")
                {
                    model.ForumID = int.Parse(row["ForumID"].ToString());
                }
                if (row["CID"] != null && row["CID"].ToString() != "")
                {
                    model.CID = int.Parse(row["CID"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
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
            strSql.Append("select CommentID,UID,CommentDate,Comment,Likes,GiftCount,ForumID,CID,Status ");
            strSql.Append(" FROM T_Forum_Comment ");
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
            strSql.Append(" CommentID,UID,CommentDate,Comment,Likes,GiftCount,ForumID,CID,Status ");
            strSql.Append(" FROM T_Forum_Comment ");
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
            strSql.Append("select count(1) FROM T_Forum_Comment ");
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
                strSql.Append("order by T.CommentID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Forum_Comment T ");
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
            parameters[0].Value = "T_Forum_Comment";
            parameters[1].Value = "CommentID";
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

