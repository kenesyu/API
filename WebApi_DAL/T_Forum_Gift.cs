using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Forum_Gift
    /// </summary>
    public partial class T_Forum_Gift
    {
        public T_Forum_Gift()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ForumID, int GiftID, int Qty, int PostUID, int ReceiptUID, DateTime PostTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Forum_Gift");
            strSql.Append(" where ForumID=@ForumID and GiftID=@GiftID and Qty=@Qty and PostUID=@PostUID and ReceiptUID=@ReceiptUID and PostTime=@PostTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@GiftID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@PostUID", SqlDbType.Int,4),
					new SqlParameter("@ReceiptUID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime)			};
            parameters[0].Value = ForumID;
            parameters[1].Value = GiftID;
            parameters[2].Value = Qty;
            parameters[3].Value = PostUID;
            parameters[4].Value = ReceiptUID;
            parameters[5].Value = PostTime;

            return DBHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebApi_Model.T_Forum_Gift model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Forum_Gift(");
            strSql.Append("ForumID,GiftID,Qty,PostUID,ReceiptUID,PostTime)");
            strSql.Append(" values (");
            strSql.Append("@ForumID,@GiftID,@Qty,@PostUID,@ReceiptUID,@PostTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@GiftID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@PostUID", SqlDbType.Int,4),
					new SqlParameter("@ReceiptUID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ForumID;
            parameters[1].Value = model.GiftID;
            parameters[2].Value = model.Qty;
            parameters[3].Value = model.PostUID;
            parameters[4].Value = model.ReceiptUID;
            parameters[5].Value = model.PostTime;

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
        public bool Update(WebApi_Model.T_Forum_Gift model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Forum_Gift set ");
            strSql.Append("ForumID=@ForumID,");
            strSql.Append("GiftID=@GiftID,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("PostUID=@PostUID,");
            strSql.Append("ReceiptUID=@ReceiptUID,");
            strSql.Append("PostTime=@PostTime");
            strSql.Append(" where ForumID=@ForumID and GiftID=@GiftID and Qty=@Qty and PostUID=@PostUID and ReceiptUID=@ReceiptUID and PostTime=@PostTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@GiftID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@PostUID", SqlDbType.Int,4),
					new SqlParameter("@ReceiptUID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ForumID;
            parameters[1].Value = model.GiftID;
            parameters[2].Value = model.Qty;
            parameters[3].Value = model.PostUID;
            parameters[4].Value = model.ReceiptUID;
            parameters[5].Value = model.PostTime;

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
        public bool Delete(int ForumID, int GiftID, int Qty, int PostUID, int ReceiptUID, DateTime PostTime)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Forum_Gift ");
            strSql.Append(" where ForumID=@ForumID and GiftID=@GiftID and Qty=@Qty and PostUID=@PostUID and ReceiptUID=@ReceiptUID and PostTime=@PostTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@GiftID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@PostUID", SqlDbType.Int,4),
					new SqlParameter("@ReceiptUID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime)			};
            parameters[0].Value = ForumID;
            parameters[1].Value = GiftID;
            parameters[2].Value = Qty;
            parameters[3].Value = PostUID;
            parameters[4].Value = ReceiptUID;
            parameters[5].Value = PostTime;

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
        public WebApi_Model.T_Forum_Gift GetModel(int ForumID, int GiftID, int Qty, int PostUID, int ReceiptUID, DateTime PostTime)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ForumID,GiftID,Qty,PostUID,ReceiptUID,PostTime from T_Forum_Gift ");
            strSql.Append(" where ForumID=@ForumID and GiftID=@GiftID and Qty=@Qty and PostUID=@PostUID and ReceiptUID=@ReceiptUID and PostTime=@PostTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@ForumID", SqlDbType.Int,4),
					new SqlParameter("@GiftID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@PostUID", SqlDbType.Int,4),
					new SqlParameter("@ReceiptUID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime)			};
            parameters[0].Value = ForumID;
            parameters[1].Value = GiftID;
            parameters[2].Value = Qty;
            parameters[3].Value = PostUID;
            parameters[4].Value = ReceiptUID;
            parameters[5].Value = PostTime;

            WebApi_Model.T_Forum_Gift model = new WebApi_Model.T_Forum_Gift();
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
        public WebApi_Model.T_Forum_Gift DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Forum_Gift model = new WebApi_Model.T_Forum_Gift();
            if (row != null)
            {
                if (row["ForumID"] != null && row["ForumID"].ToString() != "")
                {
                    model.ForumID = int.Parse(row["ForumID"].ToString());
                }
                if (row["GiftID"] != null && row["GiftID"].ToString() != "")
                {
                    model.GiftID = int.Parse(row["GiftID"].ToString());
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = int.Parse(row["Qty"].ToString());
                }
                if (row["PostUID"] != null && row["PostUID"].ToString() != "")
                {
                    model.PostUID = int.Parse(row["PostUID"].ToString());
                }
                if (row["ReceiptUID"] != null && row["ReceiptUID"].ToString() != "")
                {
                    model.ReceiptUID = int.Parse(row["ReceiptUID"].ToString());
                }
                if (row["PostTime"] != null && row["PostTime"].ToString() != "")
                {
                    model.PostTime = DateTime.Parse(row["PostTime"].ToString());
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
            strSql.Append("select ForumID,GiftID,Qty,PostUID,ReceiptUID,PostTime ");
            strSql.Append(" FROM T_Forum_Gift ");
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
            strSql.Append(" ForumID,GiftID,Qty,PostUID,ReceiptUID,PostTime ");
            strSql.Append(" FROM T_Forum_Gift ");
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
            strSql.Append("select count(1) FROM T_Forum_Gift ");
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
                strSql.Append("order by T.PostTime desc");
            }
            strSql.Append(")AS Row, T.*  from T_Forum_Gift T ");
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
            parameters[0].Value = "T_Forum_Gift";
            parameters[1].Value = "PostTime";
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

