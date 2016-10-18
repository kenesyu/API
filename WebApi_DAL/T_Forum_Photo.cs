using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Forum_Photo
    /// </summary>
    public partial class T_Forum_Photo
    {
        public T_Forum_Photo()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Forum_Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Forum_Photo(");
            strSql.Append("ForumID,Photo,UploadTime,PayType)");
            strSql.Append(" values (");
            strSql.Append("@ForumID,@Photo,@UploadTime,@PayType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@Photo", SqlDbType.NVarChar,50),
					new SqlParameter("@UploadTime", SqlDbType.DateTime),
					new SqlParameter("@PayType", SqlDbType.Int,4)};
            parameters[0].Value = model.ForumID;
            parameters[1].Value = model.Photo;
            parameters[2].Value = model.UploadTime;
            parameters[3].Value = model.PayType;

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
        public bool Update(WebApi_Model.T_Forum_Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Forum_Photo set ");
            strSql.Append("ForumID=@ForumID,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("UploadTime=@UploadTime,");
            strSql.Append("PayType=@PayType");
            strSql.Append(" where ForumPhotoID=@ForumPhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@Photo", SqlDbType.NVarChar,50),
					new SqlParameter("@UploadTime", SqlDbType.DateTime),
					new SqlParameter("@PayType", SqlDbType.Int,4),
					new SqlParameter("@ForumPhotoID", SqlDbType.Int,4)};
            parameters[0].Value = model.ForumID;
            parameters[1].Value = model.Photo;
            parameters[2].Value = model.UploadTime;
            parameters[3].Value = model.PayType;
            parameters[4].Value = model.ForumPhotoID;

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
        public bool Delete(int ForumPhotoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forum_Photo ");
            strSql.Append(" where ForumPhotoID=@ForumPhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumPhotoID", SqlDbType.Int,4)
			};
            parameters[0].Value = ForumPhotoID;

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
        public bool DeleteList(string ForumPhotoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forum_Photo ");
            strSql.Append(" where ForumPhotoID in (" + ForumPhotoIDlist + ")  ");
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
        public WebApi_Model.T_Forum_Photo GetModel(int ForumPhotoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ForumPhotoID,ForumID,Photo,UploadTime,PayType from T_Forum_Photo ");
            strSql.Append(" where ForumPhotoID=@ForumPhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumPhotoID", SqlDbType.Int,4)
			};
            parameters[0].Value = ForumPhotoID;

            WebApi_Model.T_Forum_Photo model = new WebApi_Model.T_Forum_Photo();
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
        public WebApi_Model.T_Forum_Photo DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Forum_Photo model = new WebApi_Model.T_Forum_Photo();
            if (row != null)
            {
                if (row["ForumPhotoID"] != null && row["ForumPhotoID"].ToString() != "")
                {
                    model.ForumPhotoID = int.Parse(row["ForumPhotoID"].ToString());
                }
                if (row["ForumID"] != null && row["ForumID"].ToString() != "")
                {
                    model.ForumID = int.Parse(row["ForumID"].ToString());
                }
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
                }
                if (row["UploadTime"] != null && row["UploadTime"].ToString() != "")
                {
                    model.UploadTime = DateTime.Parse(row["UploadTime"].ToString());
                }
                if (row["PayType"] != null && row["PayType"].ToString() != "")
                {
                    model.PayType = int.Parse(row["PayType"].ToString());
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
            strSql.Append("select ForumPhotoID,ForumID,Photo,UploadTime,PayType ");
            strSql.Append(" FROM T_Forum_Photo ");
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
            strSql.Append(" ForumPhotoID,ForumID,Photo,UploadTime,PayType ");
            strSql.Append(" FROM T_Forum_Photo ");
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
            strSql.Append("select count(1) FROM T_Forum_Photo ");
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
                strSql.Append("order by T.ForumPhotoID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Forum_Photo T ");
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
            parameters[0].Value = "T_Forum_Photo";
            parameters[1].Value = "ForumPhotoID";
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

