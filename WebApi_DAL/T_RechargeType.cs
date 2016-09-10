using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_RechargeType
    /// </summary>
    public partial class T_RechargeType
    {
        public T_RechargeType()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_RechargeType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_RechargeType(");
            strSql.Append("RechargeName,AddDays,ICO,AddPiaoZi,RechargePrice)");
            strSql.Append(" values (");
            strSql.Append("@RechargeName,@AddDays,@ICO,@AddPiaoZi,@RechargePrice)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeName", SqlDbType.NVarChar,50),
					new SqlParameter("@AddDays", SqlDbType.Int,4),
					new SqlParameter("@ICO", SqlDbType.NVarChar,50),
					new SqlParameter("@AddPiaoZi", SqlDbType.Int,4),
					new SqlParameter("@RechargePrice", SqlDbType.Decimal,9)};
            parameters[0].Value = model.RechargeName;
            parameters[1].Value = model.AddDays;
            parameters[2].Value = model.ICO;
            parameters[3].Value = model.AddPiaoZi;
            parameters[4].Value = model.RechargePrice;

            object obj = WebApi_DBUtility.DBHelper.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(WebApi_Model.T_RechargeType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_RechargeType set ");
            strSql.Append("RechargeName=@RechargeName,");
            strSql.Append("AddDays=@AddDays,");
            strSql.Append("ICO=@ICO,");
            strSql.Append("AddPiaoZi=@AddPiaoZi,");
            strSql.Append("RechargePrice=@RechargePrice");
            strSql.Append(" where RechargeID=@RechargeID");
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeName", SqlDbType.NVarChar,50),
					new SqlParameter("@AddDays", SqlDbType.Int,4),
					new SqlParameter("@ICO", SqlDbType.NVarChar,50),
					new SqlParameter("@AddPiaoZi", SqlDbType.Int,4),
					new SqlParameter("@RechargePrice", SqlDbType.Decimal,9),
					new SqlParameter("@RechargeID", SqlDbType.Int,4)};
            parameters[0].Value = model.RechargeName;
            parameters[1].Value = model.AddDays;
            parameters[2].Value = model.ICO;
            parameters[3].Value = model.AddPiaoZi;
            parameters[4].Value = model.RechargePrice;
            parameters[5].Value = model.RechargeID;

            int rows = WebApi_DBUtility.DBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int RechargeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_RechargeType ");
            strSql.Append(" where RechargeID=@RechargeID");
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeID", SqlDbType.Int,4)
			};
            parameters[0].Value = RechargeID;

            int rows = WebApi_DBUtility.DBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string RechargeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_RechargeType ");
            strSql.Append(" where RechargeID in (" + RechargeIDlist + ")  ");
            int rows = WebApi_DBUtility.DBHelper.ExecuteSql(strSql.ToString());
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
        public WebApi_Model.T_RechargeType GetModel(int RechargeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RechargeID,RechargeName,AddDays,ICO,AddPiaoZi,RechargePrice from T_RechargeType ");
            strSql.Append(" where RechargeID=@RechargeID");
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeID", SqlDbType.Int,4)
			};
            parameters[0].Value = RechargeID;

            WebApi_Model.T_RechargeType model = new WebApi_Model.T_RechargeType();
            DataSet ds = WebApi_DBUtility.DBHelper.Query(strSql.ToString(), parameters);
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
        public WebApi_Model.T_RechargeType DataRowToModel(DataRow row)
        {
            WebApi_Model.T_RechargeType model = new WebApi_Model.T_RechargeType();
            if (row != null)
            {
                if (row["RechargeID"] != null && row["RechargeID"].ToString() != "")
                {
                    model.RechargeID = int.Parse(row["RechargeID"].ToString());
                }
                if (row["RechargeName"] != null)
                {
                    model.RechargeName = row["RechargeName"].ToString();
                }
                if (row["AddDays"] != null && row["AddDays"].ToString() != "")
                {
                    model.AddDays = int.Parse(row["AddDays"].ToString());
                }
                if (row["ICO"] != null)
                {
                    model.ICO = row["ICO"].ToString();
                }
                if (row["AddPiaoZi"] != null && row["AddPiaoZi"].ToString() != "")
                {
                    model.AddPiaoZi = int.Parse(row["AddPiaoZi"].ToString());
                }
                if (row["RechargePrice"] != null && row["RechargePrice"].ToString() != "")
                {
                    model.RechargePrice = decimal.Parse(row["RechargePrice"].ToString());
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
            strSql.Append("select RechargeID,RechargeName,AddDays,ICO,AddPiaoZi,RechargePrice ");
            strSql.Append(" FROM T_RechargeType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return WebApi_DBUtility.DBHelper.Query(strSql.ToString());
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
            strSql.Append(" RechargeID,RechargeName,AddDays,ICO,AddPiaoZi,RechargePrice ");
            strSql.Append(" FROM T_RechargeType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return WebApi_DBUtility.DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_RechargeType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = WebApi_DBUtility.DBHelper.GetSingle(strSql.ToString());
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
                strSql.Append("order by T.RechargeID desc");
            }
            strSql.Append(")AS Row, T.*  from T_RechargeType T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return WebApi_DBUtility.DBHelper.Query(strSql.ToString());
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
            parameters[0].Value = "T_RechargeType";
            parameters[1].Value = "RechargeID";
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

