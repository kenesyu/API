using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_User_SMSCode
    /// </summary>
    public partial class T_User_SMSCode
    {
        public T_User_SMSCode()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_User_SMSCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_User_SMSCode(");
            strSql.Append("Tel,SendTime,OverDueTime,Code,Type,Message,Active)");
            strSql.Append(" values (");
            strSql.Append("@Tel,@SendTime,@OverDueTime,@Code,@Type,@Message,@Active)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Tel", SqlDbType.NVarChar,11),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@OverDueTime", SqlDbType.DateTime),
					new SqlParameter("@Code", SqlDbType.NVarChar,6),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Message", SqlDbType.NVarChar,200),
					new SqlParameter("@Active", SqlDbType.Int,4)};
            parameters[0].Value = model.Tel;
            parameters[1].Value = model.SendTime;
            parameters[2].Value = model.OverDueTime;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Message;
            parameters[6].Value = model.Active;

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
        public bool Update(WebApi_Model.T_User_SMSCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_User_SMSCode set ");
            strSql.Append("Tel=@Tel,");
            strSql.Append("SendTime=@SendTime,");
            strSql.Append("OverDueTime=@OverDueTime,");
            strSql.Append("Code=@Code,");
            strSql.Append("Type=@Type,");
            strSql.Append("Message=@Message,");
            strSql.Append("Active=@Active");
            strSql.Append(" where CodeID=@CodeID");
            SqlParameter[] parameters = {
					new SqlParameter("@Tel", SqlDbType.NVarChar,11),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@OverDueTime", SqlDbType.DateTime),
					new SqlParameter("@Code", SqlDbType.NVarChar,6),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Message", SqlDbType.NVarChar,200),
					new SqlParameter("@Active", SqlDbType.Int,4),
					new SqlParameter("@CodeID", SqlDbType.Int,4)};
            parameters[0].Value = model.Tel;
            parameters[1].Value = model.SendTime;
            parameters[2].Value = model.OverDueTime;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Message;
            parameters[6].Value = model.Active;
            parameters[7].Value = model.CodeID;

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
        public bool Delete(int CodeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_User_SMSCode ");
            strSql.Append(" where CodeID=@CodeID");
            SqlParameter[] parameters = {
					new SqlParameter("@CodeID", SqlDbType.Int,4)
			};
            parameters[0].Value = CodeID;

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
        public bool DeleteList(string CodeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_User_SMSCode ");
            strSql.Append(" where CodeID in (" + CodeIDlist + ")  ");
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
        public WebApi_Model.T_User_SMSCode GetModel(int CodeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CodeID,Tel,SendTime,OverDueTime,Code,Type,Message,Active from T_User_SMSCode ");
            strSql.Append(" where CodeID=@CodeID");
            SqlParameter[] parameters = {
					new SqlParameter("@CodeID", SqlDbType.Int,4)
			};
            parameters[0].Value = CodeID;

            WebApi_Model.T_User_SMSCode model = new WebApi_Model.T_User_SMSCode();
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
        public WebApi_Model.T_User_SMSCode DataRowToModel(DataRow row)
        {
            WebApi_Model.T_User_SMSCode model = new WebApi_Model.T_User_SMSCode();
            if (row != null)
            {
                if (row["CodeID"] != null && row["CodeID"].ToString() != "")
                {
                    model.CodeID = int.Parse(row["CodeID"].ToString());
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["SendTime"] != null && row["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(row["SendTime"].ToString());
                }
                if (row["OverDueTime"] != null && row["OverDueTime"].ToString() != "")
                {
                    model.OverDueTime = DateTime.Parse(row["OverDueTime"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Message"] != null)
                {
                    model.Message = row["Message"].ToString();
                }
                if (row["Active"] != null && row["Active"].ToString() != "")
                {
                    model.Active = int.Parse(row["Active"].ToString());
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
            strSql.Append("select CodeID,Tel,SendTime,OverDueTime,Code,Type,Message,Active ");
            strSql.Append(" FROM T_User_SMSCode ");
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
            strSql.Append(" CodeID,Tel,SendTime,OverDueTime,Code,Type,Message,Active ");
            strSql.Append(" FROM T_User_SMSCode ");
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
            strSql.Append("select count(1) FROM T_User_SMSCode ");
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
                strSql.Append("order by T.CodeID desc");
            }
            strSql.Append(")AS Row, T.*  from T_User_SMSCode T ");
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
            parameters[0].Value = "T_User_SMSCode";
            parameters[1].Value = "CodeID";
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

