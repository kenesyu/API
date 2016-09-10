using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_User
    /// </summary>
    public partial class T_User
    {
        public T_User()
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
        public int Add(WebApi_Model.T_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_User(");
            strSql.Append("Tel,Nickname,Password,HeadImg,Sex,Age,PiaoZi,TuiMao,RegisterDate,LastLoginDate,VipLevel,VipOverDueDate,IsOnLine)");
            strSql.Append(" values (");
            strSql.Append("@Tel,@Nickname,@Password,@HeadImg,@Sex,@Age,@PiaoZi,@TuiMao,@RegisterDate,@LastLoginDate,@VipLevel,@VipOverDueDate,@IsOnLine)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Tel", SqlDbType.NVarChar,11),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
					new SqlParameter("@HeadImg", SqlDbType.NVarChar,32),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@PiaoZi", SqlDbType.Int,4),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@VipLevel", SqlDbType.Int,4),
					new SqlParameter("@VipOverDueDate", SqlDbType.DateTime),
					new SqlParameter("@IsOnLine", SqlDbType.Int,4)};
            parameters[0].Value = model.Tel;
            parameters[1].Value = model.Nickname;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.HeadImg;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Age;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = DateTime.Now;
            parameters[10].Value = 0;
            parameters[11].Value = model.VipOverDueDate;
            parameters[12].Value = 1;

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
        public bool Update(WebApi_Model.T_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_User set ");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Nickname=@Nickname,");
            strSql.Append("Password=@Password,");
            strSql.Append("HeadImg=@HeadImg,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Age=@Age,");
            strSql.Append("PiaoZi=@PiaoZi,");
            strSql.Append("TuiMao=@TuiMao,");
            strSql.Append("RegisterDate=@RegisterDate,");
            strSql.Append("LastLoginDate=@LastLoginDate,");
            strSql.Append("VipLevel=@VipLevel,");
            strSql.Append("VipOverDueDate=@VipOverDueDate,");
            strSql.Append("IsOnLine=@IsOnLine");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@Tel", SqlDbType.NVarChar,11),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
					new SqlParameter("@HeadImg", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@PiaoZi", SqlDbType.Int,4),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@VipLevel", SqlDbType.Int,4),
					new SqlParameter("@VipOverDueDate", SqlDbType.DateTime),
					new SqlParameter("@IsOnLine", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = model.Tel;
            parameters[1].Value = model.Nickname;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.HeadImg;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Age;
            parameters[6].Value = model.PiaoZi;
            parameters[7].Value = model.TuiMao;
            parameters[8].Value = model.RegisterDate;
            parameters[9].Value = model.LastLoginDate;
            parameters[10].Value = model.VipLevel;
            parameters[11].Value = model.VipOverDueDate;
            parameters[12].Value = model.IsOnLine;
            parameters[13].Value = model.UID;

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


        public bool ResetPassword(WebApi_Model.T_User model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_User set ");
            strSql.Append("Password=@Password");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
					new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = model.Password;
            parameters[1].Value = model.UID;

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

        public bool LogOff(int UID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_User set ");
            strSql.Append("IsOnLine= 0");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)};
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
        public WebApi_Model.T_User GetModel(int UID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UID,Tel,Nickname,Password,HeadImg,Sex,Age,PiaoZi,TuiMao,RegisterDate,LastLoginDate,VipLevel,VipOverDueDate,IsOnLine from T_User ");
            strSql.Append(" where UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)
			};
            parameters[0].Value = UID;

            WebApi_Model.T_User model = new WebApi_Model.T_User();
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

        public WebApi_Model.T_User GetModel(string Tel)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_User ");
            strSql.Append(" where Tel=@Tel");
            SqlParameter[] parameters = {
					new SqlParameter("@Tel", Tel)
			};

            WebApi_Model.T_User model = new WebApi_Model.T_User();
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

        public WebApi_Model.T_User GetModel(string Username, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_User ");
            strSql.Append(" where (cast(UID as nvarchar)=@Username or cast(Tel as nvarchar)=@Username) and Password=@Password");
            SqlParameter[] parameters = {
					new SqlParameter("@Username",Username),
                    new SqlParameter("@Password",Password)
			};
            //parameters[0].Value = UID;

            WebApi_Model.T_User model = new WebApi_Model.T_User();
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
        public WebApi_Model.T_User DataRowToModel(DataRow row)
        {
            WebApi_Model.T_User model = new WebApi_Model.T_User();
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
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
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
                if (row["PiaoZi"] != null && row["PiaoZi"].ToString() != "")
                {
                    model.PiaoZi = int.Parse(row["PiaoZi"].ToString());
                }
                if (row["TuiMao"] != null && row["TuiMao"].ToString() != "")
                {
                    model.TuiMao = int.Parse(row["TuiMao"].ToString());
                }
                if (row["RegisterDate"] != null && row["RegisterDate"].ToString() != "")
                {
                    model.RegisterDate = DateTime.Parse(row["RegisterDate"].ToString());
                }
                if (row["LastLoginDate"] != null && row["LastLoginDate"].ToString() != "")
                {
                    model.LastLoginDate = DateTime.Parse(row["LastLoginDate"].ToString());
                }
                if (row["VipLevel"] != null && row["VipLevel"].ToString() != "")
                {
                    model.VipLevel = int.Parse(row["VipLevel"].ToString());
                }
                if (row["VipOverDueDate"] != null && row["VipOverDueDate"].ToString() != "")
                {
                    model.VipOverDueDate = DateTime.Parse(row["VipOverDueDate"].ToString());
                }
                if (row["IsOnLine"] != null && row["IsOnLine"].ToString() != "")
                {
                    model.IsOnLine = int.Parse(row["IsOnLine"].ToString());
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
            strSql.Append("select UID,Tel,Nickname,Password,HeadImg,Sex,Age,PiaoZi,TuiMao,RegisterDate,LastLoginDate,VipLevel,VipOverDueDate,IsOnLine ");
            strSql.Append(" FROM T_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.Query(strSql.ToString());
        }

        public bool UpdateAvatar(int UID, string NewName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update T_User set HeadImg = @NewName where UID=@UID");

            int rows = DBHelper.ExecuteSql(strSql.ToString(), new SqlParameter[] { 
                new SqlParameter("@NewName",NewName), new SqlParameter("@UID",UID)
            });
            if (rows == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            strSql.Append(" UID,Tel,Nickname,Password,HeadImg,Sex,Age,PiaoZi,TuiMao,RegisterDate,LastLoginDate,VipLevel,VipOverDueDate,IsOnLine ");
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
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

