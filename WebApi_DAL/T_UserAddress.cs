using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_UserAddress
    /// </summary>
    public partial class T_UserAddress
    {
        public T_UserAddress()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_UserAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_UserAddress(");
            strSql.Append("Province,City,Area,ReceiveName,PostCode,Tel,Description,IsDefault,UID)");
            strSql.Append(" values (");
            strSql.Append("@Province,@City,@Area,@ReceiveName,@PostCode,@Tel,@Description,@IsDefault,@UID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Province", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceiveName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,6),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Description", SqlDbType.NVarChar,100),
					new SqlParameter("@IsDefault", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = model.Province;
            parameters[1].Value = model.City;
            parameters[2].Value = model.Area;
            parameters[3].Value = model.ReceiveName;
            parameters[4].Value = model.PostCode;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.IsDefault;
            parameters[8].Value = model.UID;

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
        public bool Update(WebApi_Model.T_UserAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_UserAddress set ");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("Area=@Area,");
            strSql.Append("ReceiveName=@ReceiveName,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Description=@Description,");
            strSql.Append("IsDefault=@IsDefault,");
            strSql.Append("UID=@UID");
            strSql.Append(" where AddressID=@AddressID");
            SqlParameter[] parameters = {
					new SqlParameter("@Province", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceiveName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,6),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Description", SqlDbType.NVarChar,100),
					new SqlParameter("@IsDefault", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@AddressID", SqlDbType.Int,4)};
            parameters[0].Value = model.Province;
            parameters[1].Value = model.City;
            parameters[2].Value = model.Area;
            parameters[3].Value = model.ReceiveName;
            parameters[4].Value = model.PostCode;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.IsDefault;
            parameters[8].Value = model.UID;
            parameters[9].Value = model.AddressID;

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
        public bool Delete(int AddressID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_UserAddress ");
            strSql.Append(" where AddressID=@AddressID");
            SqlParameter[] parameters = {
					new SqlParameter("@AddressID", SqlDbType.Int,4)
			};
            parameters[0].Value = AddressID;

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
        public bool DeleteList(string AddressIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_UserAddress ");
            strSql.Append(" where AddressID in (" + AddressIDlist + ")  ");
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
        public WebApi_Model.T_UserAddress GetModel(int AddressID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AddressID,Province,City,Area,ReceiveName,PostCode,Tel,Description,IsDefault,UID from T_UserAddress ");
            strSql.Append(" where AddressID=@AddressID");
            SqlParameter[] parameters = {
					new SqlParameter("@AddressID", SqlDbType.Int,4)
			};
            parameters[0].Value = AddressID;

            WebApi_Model.T_UserAddress model = new WebApi_Model.T_UserAddress();
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
        public WebApi_Model.T_UserAddress DataRowToModel(DataRow row)
        {
            WebApi_Model.T_UserAddress model = new WebApi_Model.T_UserAddress();
            if (row != null)
            {
                if (row["AddressID"] != null && row["AddressID"].ToString() != "")
                {
                    model.AddressID = int.Parse(row["AddressID"].ToString());
                }
                if (row["Province"] != null)
                {
                    model.Province = row["Province"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["ReceiveName"] != null)
                {
                    model.ReceiveName = row["ReceiveName"].ToString();
                }
                if (row["PostCode"] != null)
                {
                    model.PostCode = row["PostCode"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["IsDefault"] != null && row["IsDefault"].ToString() != "")
                {
                    model.IsDefault = int.Parse(row["IsDefault"].ToString());
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
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
            strSql.Append("select AddressID,Province,City,Area,ReceiveName,PostCode,Tel,Description,IsDefault,UID ");
            strSql.Append(" FROM T_UserAddress ");
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
            strSql.Append(" AddressID,Province,City,Area,ReceiveName,PostCode,Tel,Description,IsDefault,UID ");
            strSql.Append(" FROM T_UserAddress ");
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
            strSql.Append("select count(1) FROM T_UserAddress ");
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
                strSql.Append("order by T.AddressID desc");
            }
            strSql.Append(")AS Row, T.*  from T_UserAddress T ");
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
            parameters[0].Value = "T_UserAddress";
            parameters[1].Value = "AddressID";
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

