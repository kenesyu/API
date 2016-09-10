using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_UserSign
    /// </summary>
    public partial class T_UserSign
    {
        public T_UserSign()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID, DateTime SignDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_UserSign");
            strSql.Append(" where UID=@UID and SignDate=@SignDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@SignDate", SqlDbType.DateTime)			};
            parameters[0].Value = UID;
            parameters[1].Value = SignDate;

            return DBHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebApi_Model.T_UserSign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_UserSign(");
            strSql.Append("UID,SignDate)");
            strSql.Append(" values (");
            strSql.Append("@UID,@SignDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@SignDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.SignDate;

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
        public bool Update(WebApi_Model.T_UserSign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_UserSign set ");
            strSql.Append("UID=@UID,");
            strSql.Append("SignDate=@SignDate");
            strSql.Append(" where UID=@UID and SignDate=@SignDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@SignDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.SignDate;

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
        public bool Delete(int UID, DateTime SignDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_UserSign ");
            strSql.Append(" where UID=@UID and SignDate=@SignDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@SignDate", SqlDbType.DateTime)			};
            parameters[0].Value = UID;
            parameters[1].Value = SignDate;

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
        public WebApi_Model.T_UserSign GetModel(int UID, DateTime SignDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UID,SignDate from T_UserSign ");
            strSql.Append(" where UID=@UID and SignDate=@SignDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@SignDate", SqlDbType.DateTime)			};
            parameters[0].Value = UID;
            parameters[1].Value = SignDate;

            WebApi_Model.T_UserSign model = new WebApi_Model.T_UserSign();
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
        public WebApi_Model.T_UserSign DataRowToModel(DataRow row)
        {
            WebApi_Model.T_UserSign model = new WebApi_Model.T_UserSign();
            if (row != null)
            {
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["SignDate"] != null && row["SignDate"].ToString() != "")
                {
                    model.SignDate = DateTime.Parse(row["SignDate"].ToString());
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
            strSql.Append("select UID,SignDate ");
            strSql.Append(" FROM T_UserSign ");
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
            strSql.Append(" UID,SignDate ");
            strSql.Append(" FROM T_UserSign ");
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
            strSql.Append("select count(1) FROM T_UserSign ");
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
                strSql.Append("order by T.SignDate desc");
            }
            strSql.Append(")AS Row, T.*  from T_UserSign T ");
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
            parameters[0].Value = "T_UserSign";
            parameters[1].Value = "SignDate";
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

