using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Photo_Store
    /// </summary>
    public partial class T_Photo_Store
    {
        public T_Photo_Store()
        { }
        #region  BasicMethod

        public bool Exists(int UID, int PhotoCollectionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Photo_Store");
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
        public int Add(WebApi_Model.T_Photo_Store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Photo_Store(");
            strSql.Append("UID,PhotoCollectionID,CreatDate)");
            strSql.Append(" values (");
            strSql.Append("@UID,@PhotoCollectionID,@CreatDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4),
					new SqlParameter("@CreatDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.PhotoCollectionID;
            parameters[2].Value = model.CreatDate;

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
        public bool Update(WebApi_Model.T_Photo_Store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Photo_Store set ");
            strSql.Append("UID=@UID,");
            strSql.Append("PhotoCollectionID=@PhotoCollectionID,");
            strSql.Append("CreatDate=@CreatDate");
            strSql.Append(" where StoreID=@StoreID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4),
					new SqlParameter("@CreatDate", SqlDbType.DateTime),
					new SqlParameter("@StoreID", SqlDbType.Int,4)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.PhotoCollectionID;
            parameters[2].Value = model.CreatDate;
            parameters[3].Value = model.StoreID;

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
        public bool Delete(int StoreID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Photo_Store ");
            strSql.Append(" where StoreID=@StoreID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4)
			};
            parameters[0].Value = StoreID;

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
            strSql.Append("delete from T_Photo_Store ");
            strSql.Append(" where UID=@UID and PhotoCollectionID=@PhotoCollectionID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
                    new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4)
			};

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string StoreIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Photo_Store ");
            strSql.Append(" where StoreID in (" + StoreIDlist + ")  ");
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
        public WebApi_Model.T_Photo_Store GetModel(int StoreID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreID,UID,PhotoCollectionID,CreatDate from T_Photo_Store ");
            strSql.Append(" where StoreID=@StoreID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4)
			};
            parameters[0].Value = StoreID;

            WebApi_Model.T_Photo_Store model = new WebApi_Model.T_Photo_Store();
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
        public WebApi_Model.T_Photo_Store DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Photo_Store model = new WebApi_Model.T_Photo_Store();
            if (row != null)
            {
                if (row["StoreID"] != null && row["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(row["StoreID"].ToString());
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["PhotoCollectionID"] != null && row["PhotoCollectionID"].ToString() != "")
                {
                    model.PhotoCollectionID = int.Parse(row["PhotoCollectionID"].ToString());
                }
                if (row["CreatDate"] != null && row["CreatDate"].ToString() != "")
                {
                    model.CreatDate = DateTime.Parse(row["CreatDate"].ToString());
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
            strSql.Append("select StoreID,UID,PhotoCollectionID,CreatDate ");
            strSql.Append(" FROM T_Photo_Store ");
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
            strSql.Append(" StoreID,UID,PhotoCollectionID,CreatDate ");
            strSql.Append(" FROM T_Photo_Store ");
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
            strSql.Append("select count(1) FROM T_Photo_Store ");
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
                strSql.Append("order by T.StoreID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Photo_Store T ");
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
            parameters[0].Value = "T_Photo_Store";
            parameters[1].Value = "StoreID";
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

