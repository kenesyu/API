using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Photo_Likes
    /// </summary>
    public partial class T_Photo_Likes
    {
        public T_Photo_Likes()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID, int PhotoCollectionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Photo_Likes");
            strSql.Append(" where UID=@UID and PhotoCollectionID=@PhotoCollectionID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4)	};
            parameters[0].Value = UID;
            parameters[1].Value = PhotoCollectionID;


            return DBHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebApi_Model.T_Photo_Likes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Photo_Likes(");
            strSql.Append("UID,PhotoCollectionID,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@UID,@PhotoCollectionID,@CreateTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.PhotoCollectionID;
            parameters[2].Value = DateTime.Now;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Photo_Likes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Photo_Likes set ");
            strSql.Append("UID=@UID,");
            strSql.Append("PhotoCollectionID=@PhotoCollectionID,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where UID=@UID and PhotoCollectionID=@PhotoCollectionID and CreateTime=@CreateTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.PhotoCollectionID;
            parameters[2].Value = model.CreateTime;

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
        public bool Delete(int UID, int PhotoCollectionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Photo_Likes ");
            strSql.Append(" where UID=@UID and PhotoCollectionID=@PhotoCollectionID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4)		};
            parameters[0].Value = UID;
            parameters[1].Value = PhotoCollectionID;

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
        /// 得到一个对象实体
        /// </summary>
        public WebApi_Model.T_Photo_Likes GetModel(int UID, int PhotoCollectionID, DateTime CreateTime)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UID,PhotoCollectionID,CreateTime from T_Photo_Likes ");
            strSql.Append(" where UID=@UID and PhotoCollectionID=@PhotoCollectionID and CreateTime=@CreateTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)			};
            parameters[0].Value = UID;
            parameters[1].Value = PhotoCollectionID;
            parameters[2].Value = CreateTime;

            WebApi_Model.T_Photo_Likes model = new WebApi_Model.T_Photo_Likes();
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
        public WebApi_Model.T_Photo_Likes DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Photo_Likes model = new WebApi_Model.T_Photo_Likes();
            if (row != null)
            {
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["PhotoCollectionID"] != null && row["PhotoCollectionID"].ToString() != "")
                {
                    model.PhotoCollectionID = int.Parse(row["PhotoCollectionID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
            strSql.Append("select UID,PhotoCollectionID,CreateTime ");
            strSql.Append(" FROM T_Photo_Likes ");
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
            strSql.Append(" UID,PhotoCollectionID,CreateTime ");
            strSql.Append(" FROM T_Photo_Likes ");
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
            strSql.Append("select count(1) FROM T_Photo_Likes ");
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
                strSql.Append("order by T.CreateTime desc");
            }
            strSql.Append(")AS Row, T.*  from T_Photo_Likes T ");
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
            parameters[0].Value = "T_Photo_Likes";
            parameters[1].Value = "CreateTime";
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

