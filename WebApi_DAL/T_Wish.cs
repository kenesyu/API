using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Wish
    /// </summary>
    public partial class T_Wish
    {
        public T_Wish()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Wish model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Wish(");
            strSql.Append("UID,Title,LinkUrl,WishName,PostDate,Remark,Price,Status,TuiMao,CompleteDate)");
            strSql.Append(" values (");
            strSql.Append("@UID,@Title,@LinkUrl,@WishName,@PostDate,@Remark,@Price,@Status,@TuiMao,@CompleteDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@WishName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@CompleteDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LinkUrl;
            parameters[3].Value = model.WishName;
            parameters[4].Value = model.PostDate;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.TuiMao;
            parameters[9].Value = model.CompleteDate;

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
        public bool Update(WebApi_Model.T_Wish model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Wish set ");
            strSql.Append("UID=@UID,");
            strSql.Append("Title=@Title,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("WishName=@WishName,");
            strSql.Append("PostDate=@PostDate,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Price=@Price,");
            strSql.Append("Status=@Status,");
            strSql.Append("TuiMao=@TuiMao,");
            strSql.Append("CompleteDate=@CompleteDate");
            strSql.Append(" where WishID=@WishID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@WishName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@CompleteDate", SqlDbType.DateTime),
					new SqlParameter("@WishID", SqlDbType.Int,4)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LinkUrl;
            parameters[3].Value = model.WishName;
            parameters[4].Value = model.PostDate;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.TuiMao;
            parameters[9].Value = model.CompleteDate;
            parameters[10].Value = model.WishID;

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
        public bool Delete(int WishID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Wish ");
            strSql.Append(" where WishID=@WishID");
            SqlParameter[] parameters = {
					new SqlParameter("@WishID", SqlDbType.Int,4)
			};
            parameters[0].Value = WishID;

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
        public bool DeleteList(string WishIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Wish ");
            strSql.Append(" where WishID in (" + WishIDlist + ")  ");
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
        public WebApi_Model.T_Wish GetModel(int WishID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WishID,UID,Title,LinkUrl,WishName,PostDate,Remark,Price,Status,TuiMao,CompleteDate from T_Wish ");
            strSql.Append(" where WishID=@WishID");
            SqlParameter[] parameters = {
					new SqlParameter("@WishID", SqlDbType.Int,4)
			};
            parameters[0].Value = WishID;

            WebApi_Model.T_Wish model = new WebApi_Model.T_Wish();
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
        public WebApi_Model.T_Wish DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Wish model = new WebApi_Model.T_Wish();
            if (row != null)
            {
                if (row["WishID"] != null && row["WishID"].ToString() != "")
                {
                    model.WishID = int.Parse(row["WishID"].ToString());
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["WishName"] != null)
                {
                    model.WishName = row["WishName"].ToString();
                }
                if (row["PostDate"] != null && row["PostDate"].ToString() != "")
                {
                    model.PostDate = DateTime.Parse(row["PostDate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["TuiMao"] != null && row["TuiMao"].ToString() != "")
                {
                    model.TuiMao = int.Parse(row["TuiMao"].ToString());
                }
                if (row["CompleteDate"] != null && row["CompleteDate"].ToString() != "")
                {
                    model.CompleteDate = DateTime.Parse(row["CompleteDate"].ToString());
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
            strSql.Append("select WishID,UID,Title,LinkUrl,WishName,PostDate,Remark,Price,Status,TuiMao,CompleteDate ");
            strSql.Append(" FROM T_Wish ");
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
            strSql.Append(" WishID,UID,Title,LinkUrl,WishName,PostDate,Remark,Price,Status,TuiMao,CompleteDate ");
            strSql.Append(" FROM T_Wish ");
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
            strSql.Append("select count(1) FROM T_Wish ");
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
                strSql.Append("order by T.WishID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Wish T ");
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
            parameters[0].Value = "T_Wish";
            parameters[1].Value = "WishID";
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

