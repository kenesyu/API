using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_Activity
    /// </summary>
    public partial class T_Product_Activity
    {
        public T_Product_Activity()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Activity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_Activity(");
            strSql.Append("ActiveType,KeyID,CoverPhoto)");
            strSql.Append(" values (");
            strSql.Append("@ActiveType,@KeyID,@CoverPhoto)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ActiveType", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4),
					new SqlParameter("@CoverPhoto", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ActiveType;
            parameters[1].Value = model.KeyID;
            parameters[2].Value = model.CoverPhoto;

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
        public bool Update(WebApi_Model.T_Product_Activity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_Activity set ");
            strSql.Append("ActiveType=@ActiveType,");
            strSql.Append("KeyID=@KeyID,");
            strSql.Append("CoverPhoto=@CoverPhoto");
            strSql.Append(" where ActivityID=@ActivityID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActiveType", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4),
					new SqlParameter("@CoverPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityID", SqlDbType.Int,4)};
            parameters[0].Value = model.ActiveType;
            parameters[1].Value = model.KeyID;
            parameters[2].Value = model.CoverPhoto;
            parameters[3].Value = model.ActivityID;

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
        public bool Delete(int ActivityID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Activity ");
            strSql.Append(" where ActivityID=@ActivityID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4)
			};
            parameters[0].Value = ActivityID;

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
        public bool DeleteList(string ActivityIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Activity ");
            strSql.Append(" where ActivityID in (" + ActivityIDlist + ")  ");
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
        public WebApi_Model.T_Product_Activity GetModel(int ActivityID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ActivityID,ActiveType,KeyID,CoverPhoto from T_Product_Activity ");
            strSql.Append(" where ActivityID=@ActivityID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4)
			};
            parameters[0].Value = ActivityID;

            WebApi_Model.T_Product_Activity model = new WebApi_Model.T_Product_Activity();
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
        public WebApi_Model.T_Product_Activity DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_Activity model = new WebApi_Model.T_Product_Activity();
            if (row != null)
            {
                if (row["ActivityID"] != null && row["ActivityID"].ToString() != "")
                {
                    model.ActivityID = int.Parse(row["ActivityID"].ToString());
                }
                if (row["ActiveType"] != null && row["ActiveType"].ToString() != "")
                {
                    model.ActiveType = int.Parse(row["ActiveType"].ToString());
                }
                if (row["KeyID"] != null && row["KeyID"].ToString() != "")
                {
                    model.KeyID = int.Parse(row["KeyID"].ToString());
                }
                if (row["CoverPhoto"] != null)
                {
                    model.CoverPhoto = row["CoverPhoto"].ToString();
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
            strSql.Append("select ActivityID,ActiveType,KeyID,CoverPhoto ");
            strSql.Append(" FROM T_Product_Activity ");
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
            strSql.Append(" ActivityID,ActiveType,KeyID,CoverPhoto ");
            strSql.Append(" FROM T_Product_Activity ");
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
            strSql.Append("select count(1) FROM T_Product_Activity ");
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
                strSql.Append("order by T.ActivityID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_Activity T ");
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
            parameters[0].Value = "T_Product_Activity";
            parameters[1].Value = "ActivityID";
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

