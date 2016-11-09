using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_System_Messages
    /// </summary>
    public partial class T_System_Messages
    {
        public T_System_Messages()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_System_Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_System_Messages(");
            strSql.Append("MessageTitle,MessageContent,ToUID,LinkURL,IsView,PostDate,IsDelete)");
            strSql.Append(" values (");
            strSql.Append("@MessageTitle,@MessageContent,@ToUID,@LinkURL,@IsView,@PostDate,@IsDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@MessageContent", SqlDbType.NVarChar,500),
					new SqlParameter("@ToUID", SqlDbType.Int,4),
					new SqlParameter("@LinkURL", SqlDbType.NVarChar,150),
					new SqlParameter("@IsView", SqlDbType.Int,4),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.MessageTitle;
            parameters[1].Value = model.MessageContent;
            parameters[2].Value = model.ToUID;
            parameters[3].Value = model.LinkURL;
            parameters[4].Value = model.IsView;
            parameters[5].Value = model.PostDate;
            parameters[6].Value = model.IsDelete;

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
        public bool Update(WebApi_Model.T_System_Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_System_Messages set ");
            strSql.Append("MessageTitle=@MessageTitle,");
            strSql.Append("MessageContent=@MessageContent,");
            strSql.Append("ToUID=@ToUID,");
            strSql.Append("LinkURL=@LinkURL,");
            strSql.Append("IsView=@IsView,");
            strSql.Append("PostDate=@PostDate,");
            strSql.Append("IsDelete=@IsDelete");
            strSql.Append(" where MessageID=@MessageID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@MessageContent", SqlDbType.NVarChar,500),
					new SqlParameter("@ToUID", SqlDbType.Int,4),
					new SqlParameter("@LinkURL", SqlDbType.NVarChar,150),
					new SqlParameter("@IsView", SqlDbType.Int,4),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@MessageID", SqlDbType.Int,4)};
            parameters[0].Value = model.MessageTitle;
            parameters[1].Value = model.MessageContent;
            parameters[2].Value = model.ToUID;
            parameters[3].Value = model.LinkURL;
            parameters[4].Value = model.IsView;
            parameters[5].Value = model.PostDate;
            parameters[6].Value = model.IsDelete;
            parameters[7].Value = model.MessageID;

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
        public bool Delete(int MessageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_System_Messages ");
            strSql.Append(" where MessageID=@MessageID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageID", SqlDbType.Int,4)
			};
            parameters[0].Value = MessageID;

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
        public bool DeleteList(string MessageIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_System_Messages ");
            strSql.Append(" where MessageID in (" + MessageIDlist + ")  ");
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
        public WebApi_Model.T_System_Messages GetModel(int MessageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MessageID,MessageTitle,MessageContent,ToUID,LinkURL,IsView,PostDate,IsDelete from T_System_Messages ");
            strSql.Append(" where MessageID=@MessageID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageID", SqlDbType.Int,4)
			};
            parameters[0].Value = MessageID;

            WebApi_Model.T_System_Messages model = new WebApi_Model.T_System_Messages();
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
        public WebApi_Model.T_System_Messages DataRowToModel(DataRow row)
        {
            WebApi_Model.T_System_Messages model = new WebApi_Model.T_System_Messages();
            if (row != null)
            {
                if (row["MessageID"] != null && row["MessageID"].ToString() != "")
                {
                    model.MessageID = int.Parse(row["MessageID"].ToString());
                }
                if (row["MessageTitle"] != null)
                {
                    model.MessageTitle = row["MessageTitle"].ToString();
                }
                if (row["MessageContent"] != null)
                {
                    model.MessageContent = row["MessageContent"].ToString();
                }
                if (row["ToUID"] != null && row["ToUID"].ToString() != "")
                {
                    model.ToUID = int.Parse(row["ToUID"].ToString());
                }
                if (row["LinkURL"] != null)
                {
                    model.LinkURL = row["LinkURL"].ToString();
                }
                if (row["IsView"] != null && row["IsView"].ToString() != "")
                {
                    model.IsView = int.Parse(row["IsView"].ToString());
                }
                if (row["PostDate"] != null && row["PostDate"].ToString() != "")
                {
                    model.PostDate = DateTime.Parse(row["PostDate"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
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
            strSql.Append("select MessageID,MessageTitle,MessageContent,ToUID,LinkURL,IsView,PostDate,IsDelete ");
            strSql.Append(" FROM T_System_Messages ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " order by PostDate desc");
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
            strSql.Append(" MessageID,MessageTitle,MessageContent,ToUID,LinkURL,IsView,PostDate,IsDelete ");
            strSql.Append(" FROM T_System_Messages ");
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
            strSql.Append("select count(1) FROM T_System_Messages ");
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
                strSql.Append("order by T.MessageID desc");
            }
            strSql.Append(")AS Row, T.*  from T_System_Messages T ");
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
            parameters[0].Value = "T_System_Messages";
            parameters[1].Value = "MessageID";
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

