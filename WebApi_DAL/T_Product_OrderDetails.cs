using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_OrderDetails
    /// </summary>
    public partial class T_Product_OrderDetails
    {
        public T_Product_OrderDetails()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_OrderDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_OrderDetails(");
            strSql.Append("OrderID,ProductID,ProductExtID,Qty)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@ProductID,@ProductExtID,@Qty)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@ProductExtID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.ProductExtID;
            parameters[3].Value = model.Qty;

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
        public bool Update(WebApi_Model.T_Product_OrderDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_OrderDetails set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("ProductExtID=@ProductExtID,");
            strSql.Append("Qty=@Qty");
            strSql.Append(" where OrderDetailsID=@OrderDetailsID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@ProductExtID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@OrderDetailsID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.ProductExtID;
            parameters[3].Value = model.Qty;
            parameters[4].Value = model.OrderDetailsID;

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
        public bool Delete(int OrderDetailsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_OrderDetails ");
            strSql.Append(" where OrderDetailsID=@OrderDetailsID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailsID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderDetailsID;

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
        public bool DeleteList(string OrderDetailsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_OrderDetails ");
            strSql.Append(" where OrderDetailsID in (" + OrderDetailsIDlist + ")  ");
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
        public WebApi_Model.T_Product_OrderDetails GetModel(int OrderDetailsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderDetailsID,OrderID,ProductID,ProductExtID,Qty from T_Product_OrderDetails ");
            strSql.Append(" where OrderDetailsID=@OrderDetailsID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailsID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderDetailsID;

            WebApi_Model.T_Product_OrderDetails model = new WebApi_Model.T_Product_OrderDetails();
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
        public WebApi_Model.T_Product_OrderDetails DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_OrderDetails model = new WebApi_Model.T_Product_OrderDetails();
            if (row != null)
            {
                if (row["OrderDetailsID"] != null && row["OrderDetailsID"].ToString() != "")
                {
                    model.OrderDetailsID = int.Parse(row["OrderDetailsID"].ToString());
                }
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(row["ProductID"].ToString());
                }
                if (row["ProductExtID"] != null && row["ProductExtID"].ToString() != "")
                {
                    model.ProductExtID = int.Parse(row["ProductExtID"].ToString());
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = int.Parse(row["Qty"].ToString());
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
            strSql.Append("select OrderDetailsID,OrderID,ProductID,ProductExtID,Qty ");
            strSql.Append(" FROM T_Product_OrderDetails ");
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
            strSql.Append(" OrderDetailsID,OrderID,ProductID,ProductExtID,Qty ");
            strSql.Append(" FROM T_Product_OrderDetails ");
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
            strSql.Append("select count(1) FROM T_Product_OrderDetails ");
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
                strSql.Append("order by T.OrderDetailsID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_OrderDetails T ");
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
            parameters[0].Value = "T_Product_OrderDetails";
            parameters[1].Value = "OrderDetailsID";
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

