using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_Ext
    /// </summary>
    public partial class T_Product_Ext
    {
        public T_Product_Ext()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Ext model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_Ext(");
            strSql.Append("ProductID,Price,PropertyA,PropertyB,PropertyC,Stock)");
            strSql.Append(" values (");
            strSql.Append("@ProductID,@Price,@PropertyA,@PropertyB,@PropertyC,@Stock)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PropertyA", SqlDbType.Int,4),
					new SqlParameter("@PropertyB", SqlDbType.Int,4),
					new SqlParameter("@PropertyC", SqlDbType.Int,4),
					new SqlParameter("@Stock", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.Price;
            parameters[2].Value = model.PropertyA;
            parameters[3].Value = model.PropertyB;
            parameters[4].Value = model.PropertyC;
            parameters[5].Value = model.Stock;

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
        public bool Update(WebApi_Model.T_Product_Ext model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_Ext set ");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("Price=@Price,");
            strSql.Append("PropertyA=@PropertyA,");
            strSql.Append("PropertyB=@PropertyB,");
            strSql.Append("PropertyC=@PropertyC,");
            strSql.Append("Stock=@Stock");
            strSql.Append(" where ProductExtID=@ProductExtID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PropertyA", SqlDbType.Int,4),
					new SqlParameter("@PropertyB", SqlDbType.Int,4),
					new SqlParameter("@PropertyC", SqlDbType.Int,4),
					new SqlParameter("@Stock", SqlDbType.Int,4),
					new SqlParameter("@ProductExtID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.Price;
            parameters[2].Value = model.PropertyA;
            parameters[3].Value = model.PropertyB;
            parameters[4].Value = model.PropertyC;
            parameters[5].Value = model.Stock;
            parameters[6].Value = model.ProductExtID;

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
        public bool Delete(int ProductExtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Ext ");
            strSql.Append(" where ProductExtID=@ProductExtID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductExtID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProductExtID;

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
        public bool DeleteList(string ProductExtIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Ext ");
            strSql.Append(" where ProductExtID in (" + ProductExtIDlist + ")  ");
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
        public WebApi_Model.T_Product_Ext GetModel(int ProductExtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductExtID,ProductID,Price,PropertyA,PropertyB,PropertyC,Stock from T_Product_Ext ");
            strSql.Append(" where ProductExtID=@ProductExtID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductExtID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProductExtID;

            WebApi_Model.T_Product_Ext model = new WebApi_Model.T_Product_Ext();
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
        public WebApi_Model.T_Product_Ext DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_Ext model = new WebApi_Model.T_Product_Ext();
            if (row != null)
            {
                if (row["ProductExtID"] != null && row["ProductExtID"].ToString() != "")
                {
                    model.ProductExtID = int.Parse(row["ProductExtID"].ToString());
                }
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(row["ProductID"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["PropertyA"] != null && row["PropertyA"].ToString() != "")
                {
                    model.PropertyA = int.Parse(row["PropertyA"].ToString());
                }
                if (row["PropertyB"] != null && row["PropertyB"].ToString() != "")
                {
                    model.PropertyB = int.Parse(row["PropertyB"].ToString());
                }
                if (row["PropertyC"] != null && row["PropertyC"].ToString() != "")
                {
                    model.PropertyC = int.Parse(row["PropertyC"].ToString());
                }
                if (row["Stock"] != null && row["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(row["Stock"].ToString());
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
            strSql.Append("select ProductExtID,ProductID,Price,PropertyA,PropertyB,PropertyC,Stock ");
            strSql.Append(" FROM T_Product_Ext ");
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
            strSql.Append(" ProductExtID,ProductID,Price,PropertyA,PropertyB,PropertyC,Stock ");
            strSql.Append(" FROM T_Product_Ext ");
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
            strSql.Append("select count(1) FROM T_Product_Ext ");
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
                strSql.Append("order by T.ProductExtID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_Ext T ");
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
            parameters[0].Value = "T_Product_Ext";
            parameters[1].Value = "ProductExtID";
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

