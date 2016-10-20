using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Forums
    /// </summary>
    public partial class T_Forums
    {
        public T_Forums()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Forums model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Forums(");
            strSql.Append("UID,Title,FromIP,FromDevice,CategoryID,Content,PostTime,Status,CoverPhoto,TuiMao,Flag,ProductID,Star,Views,Likes,CommentCount)");
            strSql.Append(" values (");
            strSql.Append("@UID,@Title,@FromIP,@FromDevice,@CategoryID,@Content,@PostTime,@Status,@CoverPhoto,@TuiMao,@Flag,@ProductID,@Star,@Views,@Likes,@CommentCount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FromIP", SqlDbType.NVarChar,50),
					new SqlParameter("@FromDevice", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,4000),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CoverPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Star", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Likes", SqlDbType.Int,4),
					new SqlParameter("@CommentCount", SqlDbType.Int,4)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.FromIP;
            parameters[3].Value = model.FromDevice;
            parameters[4].Value = model.CategoryID;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.PostTime;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.CoverPhoto;
            parameters[9].Value = model.TuiMao;
            parameters[10].Value = model.Flag;
            parameters[11].Value = model.ProductID;
            parameters[12].Value = model.Star;
            parameters[13].Value = model.Views;
            parameters[14].Value = model.Likes;
            parameters[15].Value = model.CommentCount;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                int key = Convert.ToInt32(obj);
                if (model.Forum_Photo.Count > 0) {
                    T_Forum_Photo tfp = new T_Forum_Photo();
                    foreach (WebApi_Model.T_Forum_Photo m in model.Forum_Photo)
                    {
                        m.ForumID = key;
                        tfp.Update(m);
                    }
   
                }
                return key;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Forums model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Forums set ");
            strSql.Append("UID=@UID,");
            strSql.Append("Title=@Title,");
            strSql.Append("FromIP=@FromIP,");
            strSql.Append("FromDevice=@FromDevice,");
            strSql.Append("CategoryID=@CategoryID,");
            strSql.Append("Content=@Content,");
            strSql.Append("PostTime=@PostTime,");
            strSql.Append("Status=@Status,");
            strSql.Append("CoverPhoto=@CoverPhoto,");
            strSql.Append("TuiMao=@TuiMao,");
            strSql.Append("Flag=@Flag,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("Star=@Star,");
            strSql.Append("Views=@Views,");
            strSql.Append("Likes=@Likes,");
            strSql.Append("CommentCount=@CommentCount");
            strSql.Append(" where ForumID=@ForumID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FromIP", SqlDbType.NVarChar,50),
					new SqlParameter("@FromDevice", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,4000),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CoverPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Star", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Likes", SqlDbType.Int,4),
					new SqlParameter("@CommentCount", SqlDbType.Int,4),
					new SqlParameter("@ForumID", SqlDbType.Int,4)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.FromIP;
            parameters[3].Value = model.FromDevice;
            parameters[4].Value = model.CategoryID;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.PostTime;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.CoverPhoto;
            parameters[9].Value = model.TuiMao;
            parameters[10].Value = model.Flag;
            parameters[11].Value = model.ProductID;
            parameters[12].Value = model.Star;
            parameters[13].Value = model.Views;
            parameters[14].Value = model.Likes;
            parameters[15].Value = model.CommentCount;
            parameters[16].Value = model.ForumID;

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
        public bool Delete(int ForumID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forums ");
            strSql.Append(" where ForumID=@ForumID");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4)
			};
            parameters[0].Value = ForumID;

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
        public bool DeleteList(string ForumIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forums ");
            strSql.Append(" where ForumID in (" + ForumIDlist + ")  ");
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
        public WebApi_Model.T_Forums GetModel(int ForumID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ForumID,UID,Title,FromIP,FromDevice,CategoryID,Content,PostTime,Status,CoverPhoto,TuiMao,Flag,ProductID,Star,Views,Likes,CommentCount from T_Forums ");
            strSql.Append(" where ForumID=@ForumID");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4)
			};
            parameters[0].Value = ForumID;

            WebApi_Model.T_Forums model = new WebApi_Model.T_Forums();
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
        public WebApi_Model.T_Forums DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Forums model = new WebApi_Model.T_Forums();
            if (row != null)
            {
                if (row["ForumID"] != null && row["ForumID"].ToString() != "")
                {
                    model.ForumID = int.Parse(row["ForumID"].ToString());
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["FromIP"] != null)
                {
                    model.FromIP = row["FromIP"].ToString();
                }
                if (row["FromDevice"] != null)
                {
                    model.FromDevice = row["FromDevice"].ToString();
                }
                if (row["CategoryID"] != null && row["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(row["CategoryID"].ToString());
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["PostTime"] != null && row["PostTime"].ToString() != "")
                {
                    model.PostTime = DateTime.Parse(row["PostTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CoverPhoto"] != null)
                {
                    model.CoverPhoto = row["CoverPhoto"].ToString();
                }
                if (row["TuiMao"] != null && row["TuiMao"].ToString() != "")
                {
                    model.TuiMao = int.Parse(row["TuiMao"].ToString());
                }
                if (row["Flag"] != null && row["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(row["Flag"].ToString());
                }
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(row["ProductID"].ToString());
                }
                if (row["Star"] != null && row["Star"].ToString() != "")
                {
                    model.Star = int.Parse(row["Star"].ToString());
                }
                if (row["Views"] != null && row["Views"].ToString() != "")
                {
                    model.Views = int.Parse(row["Views"].ToString());
                }
                if (row["Likes"] != null && row["Likes"].ToString() != "")
                {
                    model.Likes = int.Parse(row["Likes"].ToString());
                }
                if (row["CommentCount"] != null && row["CommentCount"].ToString() != "")
                {
                    model.CommentCount = int.Parse(row["CommentCount"].ToString());
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
            strSql.Append("select ForumID,UID,Title,FromIP,FromDevice,CategoryID,Content,PostTime,Status,CoverPhoto,TuiMao,Flag,ProductID,Star,Views,Likes,CommentCount ");
            strSql.Append(" FROM T_Forums ");
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
            strSql.Append(" ForumID,UID,Title,FromIP,FromDevice,CategoryID,Content,PostTime,Status,CoverPhoto,TuiMao,Flag,ProductID,Star,Views,Likes,CommentCount ");
            strSql.Append(" FROM T_Forums ");
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
            strSql.Append("select count(1) FROM T_Forums ");
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
                strSql.Append("order by T.ForumID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Forums T ");
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
            parameters[0].Value = "T_Forums";
            parameters[1].Value = "ForumID";
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

