using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_UserRecharge
    /// </summary>
    public partial class T_UserRecharge
    {
        public T_UserRecharge()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID, int RechargeID, DateTime RechargeDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_UserRecharge");
            strSql.Append(" where UID=@UID and RechargeID=@RechargeID and RechargeDate=@RechargeDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@RechargeID", SqlDbType.Int,4),
					new SqlParameter("@RechargeDate", SqlDbType.DateTime)			
                                        };
            parameters[0].Value = UID;
            parameters[1].Value = RechargeID;
            parameters[2].Value = RechargeDate;

            return DBHelper.Exists(strSql.ToString(), parameters);
        }

        public WebApi_Model.T_User UserRecharge(WebApi_Model.T_User user, WebApi_Model.T_RechargeType rechargetype)
        {
            DateTime OverDueDate = new DateTime();
            if (user.VipOverDueDate == null || user.VipOverDueDate < DateTime.Now)
            {
                OverDueDate = DateTime.Now.AddDays((int)rechargetype.AddDays);
                user.VipOverDueDate = OverDueDate;
                user.PiaoZi += rechargetype.AddPiaoZi;
            }
            else {
                OverDueDate = (DateTime)user.VipOverDueDate;
                user.VipOverDueDate = OverDueDate.AddDays((int)rechargetype.AddDays);
                user.PiaoZi += rechargetype.AddPiaoZi;
            }

            #region ==== Add Recharge ====
            WebApi_Model.T_UserRecharge model = new WebApi_Model.T_UserRecharge();
            model.UID = user.UID;
            model.RechargeID = rechargetype.RechargeID;
            model.RechargeDate = DateTime.Now;
            this.Add(model);
            #endregion

            WebApi_DAL.T_User dal = new T_User();
            dal.Update(user);

            return user;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebApi_Model.T_UserRecharge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_UserRecharge(");
            strSql.Append("UID,RechargeID,RechargeDate)");
            strSql.Append(" values (");
            strSql.Append("@UID,@RechargeID,@RechargeDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@RechargeID", SqlDbType.Int,4),
					new SqlParameter("@RechargeDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.RechargeID;
            parameters[2].Value = model.RechargeDate;

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
        public bool Update(WebApi_Model.T_UserRecharge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_UserRecharge set ");
            strSql.Append("UID=@UID,");
            strSql.Append("RechargeID=@RechargeID,");
            strSql.Append("RechargeDate=@RechargeDate");
            strSql.Append(" where UID=@UID and RechargeID=@RechargeID and RechargeDate=@RechargeDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@RechargeID", SqlDbType.Int,4),
					new SqlParameter("@RechargeDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.RechargeID;
            parameters[2].Value = model.RechargeDate;

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
        public bool Delete(int UID, int RechargeID, DateTime RechargeDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_UserRecharge ");
            strSql.Append(" where UID=@UID and RechargeID=@RechargeID and RechargeDate=@RechargeDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@RechargeID", SqlDbType.Int,4),
					new SqlParameter("@RechargeDate", SqlDbType.DateTime)			};
            parameters[0].Value = UID;
            parameters[1].Value = RechargeID;
            parameters[2].Value = RechargeDate;

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
        public WebApi_Model.T_UserRecharge GetModel(int UID, int RechargeID, DateTime RechargeDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UID,RechargeID,RechargeDate from T_UserRecharge ");
            strSql.Append(" where UID=@UID and RechargeID=@RechargeID and RechargeDate=@RechargeDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@RechargeID", SqlDbType.Int,4),
					new SqlParameter("@RechargeDate", SqlDbType.DateTime)			};
            parameters[0].Value = UID;
            parameters[1].Value = RechargeID;
            parameters[2].Value = RechargeDate;

            WebApi_Model.T_UserRecharge model = new WebApi_Model.T_UserRecharge();
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
        public WebApi_Model.T_UserRecharge DataRowToModel(DataRow row)
        {
            WebApi_Model.T_UserRecharge model = new WebApi_Model.T_UserRecharge();
            if (row != null)
            {
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["RechargeID"] != null && row["RechargeID"].ToString() != "")
                {
                    model.RechargeID = int.Parse(row["RechargeID"].ToString());
                }
                if (row["RechargeDate"] != null && row["RechargeDate"].ToString() != "")
                {
                    model.RechargeDate = DateTime.Parse(row["RechargeDate"].ToString());
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
            strSql.Append("select UID,RechargeID,RechargeDate ");
            strSql.Append(" FROM T_UserRecharge ");
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
            strSql.Append(" UID,RechargeID,RechargeDate ");
            strSql.Append(" FROM T_UserRecharge ");
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
            strSql.Append("select count(1) FROM T_UserRecharge ");
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
                strSql.Append("order by T.RechargeDate desc");
            }
            strSql.Append(")AS Row, T.*  from T_UserRecharge T ");
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
            parameters[0].Value = "T_UserRecharge";
            parameters[1].Value = "RechargeDate";
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

