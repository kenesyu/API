using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Photo_Details
    /// </summary>
    public partial class T_Photo_Details
    {
        public T_Photo_Details()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Photo_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Photo_Details(");
            strSql.Append("PhotoCollectionID,ScalePhoto,OriginalPhoto,IsActive)");
            strSql.Append(" values (");
            strSql.Append("@PhotoCollectionID,@ScalePhoto,@OriginalPhoto,@IsActive)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4),
					new SqlParameter("@ScalePhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@OriginalPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@IsActive", SqlDbType.Int,4)};
            parameters[0].Value = model.PhotoCollectionID;
            parameters[1].Value = model.ScalePhoto;
            parameters[2].Value = model.OriginalPhoto;
            parameters[3].Value = model.IsActive;

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
        public bool Update(WebApi_Model.T_Photo_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Photo_Details set ");
            strSql.Append("PhotoCollectionID=@PhotoCollectionID,");
            strSql.Append("ScalePhoto=@ScalePhoto,");
            strSql.Append("OriginalPhoto=@OriginalPhoto,");
            strSql.Append("IsActive=@IsActive");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4),
					new SqlParameter("@ScalePhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@OriginalPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@IsActive", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PhotoCollectionID;
            parameters[1].Value = model.ScalePhoto;
            parameters[2].Value = model.OriginalPhoto;
            parameters[3].Value = model.IsActive;
            parameters[4].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Photo_Details ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Photo_Details ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public WebApi_Model.T_Photo_Details GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PhotoCollectionID,ScalePhoto,OriginalPhoto,IsActive from T_Photo_Details ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            WebApi_Model.T_Photo_Details model = new WebApi_Model.T_Photo_Details();
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
        public WebApi_Model.T_Photo_Details DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Photo_Details model = new WebApi_Model.T_Photo_Details();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PhotoCollectionID"] != null && row["PhotoCollectionID"].ToString() != "")
                {
                    model.PhotoCollectionID = int.Parse(row["PhotoCollectionID"].ToString());
                }
                if (row["ScalePhoto"] != null)
                {
                    model.ScalePhoto = row["ScalePhoto"].ToString();
                }
                if (row["OriginalPhoto"] != null)
                {
                    model.OriginalPhoto = row["OriginalPhoto"].ToString();
                }
                if (row["IsActive"] != null && row["IsActive"].ToString() != "")
                {
                    model.IsActive = int.Parse(row["IsActive"].ToString());
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
            strSql.Append("select ID,PhotoCollectionID,ScalePhoto,OriginalPhoto,IsActive ");
            strSql.Append(" FROM T_Photo_Details ");
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
            strSql.Append(" ID,PhotoCollectionID,ScalePhoto,OriginalPhoto,IsActive ");
            strSql.Append(" FROM T_Photo_Details ");
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
            strSql.Append("select count(1) FROM T_Photo_Details ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Photo_Details T ");
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
            parameters[0].Value = "T_Photo_Details";
            parameters[1].Value = "ID";
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

