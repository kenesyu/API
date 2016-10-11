using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Gift
    /// </summary>
    public partial class T_Gift
    {
        public T_Gift()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Gift model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Gift(");
            strSql.Append("GiftName,GiftICO,TuiMao,IsActive)");
            strSql.Append(" values (");
            strSql.Append("@GiftName,@GiftICO,@TuiMao,@IsActive)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftName", SqlDbType.NVarChar,30),
					new SqlParameter("@GiftICO", SqlDbType.NVarChar,30),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@IsActive", SqlDbType.Int,4)};
            parameters[0].Value = model.GiftName;
            parameters[1].Value = model.GiftICO;
            parameters[2].Value = model.TuiMao;
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
        public bool Update(WebApi_Model.T_Gift model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Gift set ");
            strSql.Append("GiftName=@GiftName,");
            strSql.Append("GiftICO=@GiftICO,");
            strSql.Append("TuiMao=@TuiMao,");
            strSql.Append("IsActive=@IsActive");
            strSql.Append(" where GiftID=@GiftID");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftName", SqlDbType.NVarChar,30),
					new SqlParameter("@GiftICO", SqlDbType.NVarChar,30),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@IsActive", SqlDbType.Int,4),
					new SqlParameter("@GiftID", SqlDbType.Int,4)};
            parameters[0].Value = model.GiftName;
            parameters[1].Value = model.GiftICO;
            parameters[2].Value = model.TuiMao;
            parameters[3].Value = model.IsActive;
            parameters[4].Value = model.GiftID;

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
        public bool Delete(int GiftID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Gift ");
            strSql.Append(" where GiftID=@GiftID");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftID", SqlDbType.Int,4)
			};
            parameters[0].Value = GiftID;

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
        public bool DeleteList(string GiftIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Gift ");
            strSql.Append(" where GiftID in (" + GiftIDlist + ")  ");
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
        public WebApi_Model.T_Gift GetModel(int GiftID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GiftID,GiftName,GiftICO,TuiMao,IsActive from T_Gift ");
            strSql.Append(" where GiftID=@GiftID");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftID", SqlDbType.Int,4)
			};
            parameters[0].Value = GiftID;

            WebApi_Model.T_Gift model = new WebApi_Model.T_Gift();
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
        public WebApi_Model.T_Gift DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Gift model = new WebApi_Model.T_Gift();
            if (row != null)
            {
                if (row["GiftID"] != null && row["GiftID"].ToString() != "")
                {
                    model.GiftID = int.Parse(row["GiftID"].ToString());
                }
                if (row["GiftName"] != null)
                {
                    model.GiftName = row["GiftName"].ToString();
                }
                if (row["GiftICO"] != null)
                {
                    model.GiftICO = row["GiftICO"].ToString();
                }
                if (row["TuiMao"] != null && row["TuiMao"].ToString() != "")
                {
                    model.TuiMao = int.Parse(row["TuiMao"].ToString());
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
            strSql.Append("select GiftID,GiftName,GiftICO,TuiMao,IsActive ");
            strSql.Append(" FROM T_Gift ");
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
            strSql.Append(" GiftID,GiftName,GiftICO,TuiMao,IsActive ");
            strSql.Append(" FROM T_Gift ");
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
            strSql.Append("select count(1) FROM T_Gift ");
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
                strSql.Append("order by T.GiftID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Gift T ");
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
            parameters[0].Value = "T_Gift";
            parameters[1].Value = "GiftID";
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

