using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_User_BaseInfo
    /// </summary>
    public partial class T_User_BaseInfo
    {
        public T_User_BaseInfo()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_User");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)
			};
            parameters[0].Value = UID;

            return DBHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_User_BaseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_User(");
            strSql.Append("Tel,Nickname,HeadImg,Sex,Age)");
            strSql.Append(" values (");
            strSql.Append("@Tel,@Nickname,@HeadImg,@Sex,@Age)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Tel", SqlDbType.NVarChar,11),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@HeadImg", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Age", SqlDbType.Int,4)};
            parameters[0].Value = model.Tel;
            parameters[1].Value = model.Nickname;
            parameters[2].Value = model.HeadImg;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Age;

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
        public bool Update(WebApi_Model.T_User_BaseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_User set ");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Nickname=@Nickname,");
            strSql.Append("HeadImg=@HeadImg,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Age=@Age");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@Tel", SqlDbType.NVarChar,11),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@HeadImg", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = model.Tel;
            parameters[1].Value = model.Nickname;
            parameters[2].Value = model.HeadImg;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Age;
            parameters[5].Value = model.UID;

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
        public bool Delete(int UID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_User ");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)
			};
            parameters[0].Value = UID;

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
        public bool DeleteList(string UIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_User ");
            strSql.Append(" where UID in (" + UIDlist + ")  ");
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
        public WebApi_Model.T_User_BaseInfo GetModel(int UID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UID,Tel,Nickname,HeadImg,Sex,Age from T_User ");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)
			};
            parameters[0].Value = UID;

            WebApi_Model.T_User_BaseInfo model = new WebApi_Model.T_User_BaseInfo();
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
        public WebApi_Model.T_User_BaseInfo DataRowToModel(DataRow row)
        {
            WebApi_Model.T_User_BaseInfo model = new WebApi_Model.T_User_BaseInfo();
            if (row != null)
            {
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Nickname"] != null)
                {
                    model.Nickname = row["Nickname"].ToString();
                }
                if (row["HeadImg"] != null)
                {
                    model.HeadImg = row["HeadImg"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
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
            strSql.Append("select UID,Tel,Nickname,HeadImg,Sex,Age ");
            strSql.Append(" FROM T_User ");
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
            strSql.Append(" UID,Tel,Nickname,HeadImg,Sex,Age ");
            strSql.Append(" FROM T_User ");
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
            strSql.Append("select count(1) FROM T_User ");
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
                strSql.Append("order by T.UID desc");
            }
            strSql.Append(")AS Row, T.*  from T_User T ");
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
            parameters[0].Value = "T_User";
            parameters[1].Value = "UID";
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

