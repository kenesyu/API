using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_Property
    /// </summary>
    public partial class T_Product_Property
    {
        public T_Product_Property()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Property model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_Property(");
            strSql.Append("PropertyName,PropertyValue,PropertyGroup)");
            strSql.Append(" values (");
            strSql.Append("@PropertyName,@PropertyValue,@PropertyGroup)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyValue", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyGroup", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.PropertyName;
            parameters[1].Value = model.PropertyValue;
            parameters[2].Value = model.PropertyGroup;

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
        public bool Update(WebApi_Model.T_Product_Property model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_Property set ");
            strSql.Append("PropertyName=@PropertyName,");
            strSql.Append("PropertyValue=@PropertyValue,");
            strSql.Append("PropertyGroup=@PropertyGroup");
            strSql.Append(" where PropertyID=@PropertyID");
            SqlParameter[] parameters = {
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyValue", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyGroup", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyID", SqlDbType.Int,4)};
            parameters[0].Value = model.PropertyName;
            parameters[1].Value = model.PropertyValue;
            parameters[2].Value = model.PropertyGroup;
            parameters[3].Value = model.PropertyID;

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
        public bool Delete(int PropertyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Property ");
            strSql.Append(" where PropertyID=@PropertyID");
            SqlParameter[] parameters = {
					new SqlParameter("@PropertyID", SqlDbType.Int,4)
			};
            parameters[0].Value = PropertyID;

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
        public bool DeleteList(string PropertyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Property ");
            strSql.Append(" where PropertyID in (" + PropertyIDlist + ")  ");
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
        public WebApi_Model.T_Product_Property GetModel(int PropertyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PropertyID,PropertyName,PropertyValue,PropertyGroup from T_Product_Property ");
            strSql.Append(" where PropertyID=@PropertyID");
            SqlParameter[] parameters = {
					new SqlParameter("@PropertyID", SqlDbType.Int,4)
			};
            parameters[0].Value = PropertyID;

            WebApi_Model.T_Product_Property model = new WebApi_Model.T_Product_Property();
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
        public WebApi_Model.T_Product_Property DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_Property model = new WebApi_Model.T_Product_Property();
            if (row != null)
            {
                if (row["PropertyID"] != null && row["PropertyID"].ToString() != "")
                {
                    model.PropertyID = int.Parse(row["PropertyID"].ToString());
                }
                if (row["PropertyName"] != null)
                {
                    model.PropertyName = row["PropertyName"].ToString();
                }
                if (row["PropertyValue"] != null)
                {
                    model.PropertyValue = row["PropertyValue"].ToString();
                }
                if (row["PropertyGroup"] != null)
                {
                    model.PropertyGroup = row["PropertyGroup"].ToString();
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
            strSql.Append("select PropertyID,PropertyName,PropertyValue,PropertyGroup ");
            strSql.Append(" FROM T_Product_Property ");
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
            strSql.Append(" PropertyID,PropertyName,PropertyValue,PropertyGroup ");
            strSql.Append(" FROM T_Product_Property ");
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
            strSql.Append("select count(1) FROM T_Product_Property ");
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
                strSql.Append("order by T.PropertyID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_Property T ");
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
            parameters[0].Value = "T_Product_Property";
            parameters[1].Value = "PropertyID";
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

