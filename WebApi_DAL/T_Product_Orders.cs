using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
using System.Collections.Generic;
//using Maticsoft.DBUtility;//Please add references
namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product_Orders
    /// </summary>
    public partial class T_Product_Orders
    {
        public T_Product_Orders()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product_Orders(");
            strSql.Append("OrderNum,OrderDateTime,UID,Status,AddressID,ProductQty,TotalAmount,PayTime,SendTime,TakeTime,AfterSaleTime,TranCode,TranType,PayMethod,Out_Trade_No)");
            strSql.Append(" values (");
            strSql.Append("@OrderNum,@OrderDateTime,@UID,@Status,@AddressID,@ProductQty,@TotalAmount,@PayTime,@SendTime,@TakeTime,@AfterSaleTime,@TranCode,@TranType,@PayMethod,@Out_Trade_No)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNum", SqlDbType.NVarChar,16),
					new SqlParameter("@OrderDateTime", SqlDbType.DateTime),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@AddressID", SqlDbType.Int,4),
					new SqlParameter("@ProductQty", SqlDbType.Int,4),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@TakeTime", SqlDbType.DateTime),
					new SqlParameter("@AfterSaleTime", SqlDbType.DateTime),
					new SqlParameter("@TranCode", SqlDbType.NVarChar,25),
					new SqlParameter("@TranType", SqlDbType.NVarChar,25),
					new SqlParameter("@PayMethod", SqlDbType.NVarChar,50),
					new SqlParameter("@Out_Trade_No", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.OrderNum;
            parameters[1].Value = model.OrderDateTime;
            parameters[2].Value = model.UID;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.AddressID;
            parameters[5].Value = model.ProductQty;
            parameters[6].Value = model.TotalAmount;
            parameters[7].Value = model.PayTime;
            parameters[8].Value = model.SendTime;
            parameters[9].Value = model.TakeTime;
            parameters[10].Value = model.AfterSaleTime;
            parameters[11].Value = model.TranCode;
            parameters[12].Value = model.TranType;
            parameters[13].Value = model.PayMethod;
            parameters[14].Value = model.Out_Trade_No;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
                else
            {
                WebApi_DAL.T_Product_OrderDetails dal = new T_Product_OrderDetails();
                List<int> list = new List<int>();
                try
                {
                    for (int i = 0; i < model.OrderDetails.Count; i++)
                    {
                        //T_product
                        model.OrderDetails[i].OrderID = Convert.ToInt32(obj);
                        int Key = dal.Add(model.OrderDetails[i]);
                        list.Add(Key);
                    }
                }
                catch (Exception ex)
                {
                    Delete(Convert.ToInt32(obj));
                    foreach (int j in list) {
                        dal.Delete(j);
                    }
                    throw ex;
                }

                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebApi_Model.T_Product_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product_Orders set ");
            strSql.Append("OrderNum=@OrderNum,");
            strSql.Append("OrderDateTime=@OrderDateTime,");
            strSql.Append("UID=@UID,");
            strSql.Append("Status=@Status,");
            strSql.Append("AddressID=@AddressID,");
            strSql.Append("ProductQty=@ProductQty,");
            strSql.Append("TotalAmount=@TotalAmount,");
            strSql.Append("PayTime=@PayTime,");
            strSql.Append("SendTime=@SendTime,");
            strSql.Append("TakeTime=@TakeTime,");
            strSql.Append("AfterSaleTime=@AfterSaleTime,");
            strSql.Append("TranCode=@TranCode,");
            strSql.Append("TranType=@TranType,");
            strSql.Append("PayMethod=@PayMethod,");
            strSql.Append("Out_Trade_No=@Out_Trade_No");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNum", SqlDbType.NVarChar,16),
					new SqlParameter("@OrderDateTime", SqlDbType.DateTime),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@AddressID", SqlDbType.Int,4),
					new SqlParameter("@ProductQty", SqlDbType.Int,4),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@TakeTime", SqlDbType.DateTime),
					new SqlParameter("@AfterSaleTime", SqlDbType.DateTime),
					new SqlParameter("@TranCode", SqlDbType.NVarChar,25),
					new SqlParameter("@TranType", SqlDbType.NVarChar,25),
					new SqlParameter("@PayMethod", SqlDbType.NVarChar,50),
					new SqlParameter("@Out_Trade_No", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderNum;
            parameters[1].Value = model.OrderDateTime;
            parameters[2].Value = model.UID;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.AddressID;
            parameters[5].Value = model.ProductQty;
            parameters[6].Value = model.TotalAmount;
            parameters[7].Value = model.PayTime;
            parameters[8].Value = model.SendTime;
            parameters[9].Value = model.TakeTime;
            parameters[10].Value = model.AfterSaleTime;
            parameters[11].Value = model.TranCode;
            parameters[12].Value = model.TranType;
            parameters[13].Value = model.PayMethod;
            parameters[14].Value = model.Out_Trade_No;
            parameters[15].Value = model.OrderID;

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
        public bool Delete(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Orders ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderID;

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
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product_Orders ");
            strSql.Append(" where OrderID in (" + OrderIDlist + ")  ");
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
        public WebApi_Model.T_Product_Orders GetModel(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,OrderNum,OrderDateTime,UID,Status,AddressID,ProductQty,TotalAmount,PayTime,SendTime,TakeTime,AfterSaleTime,TranCode,TranType,PayMethod,Out_Trade_No from T_Product_Orders ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderID;

            WebApi_Model.T_Product_Orders model = new WebApi_Model.T_Product_Orders();
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
        public WebApi_Model.T_Product_Orders DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product_Orders model = new WebApi_Model.T_Product_Orders();
            if (row != null)
            {
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["OrderNum"] != null)
                {
                    model.OrderNum = row["OrderNum"].ToString();
                }
                if (row["OrderDateTime"] != null && row["OrderDateTime"].ToString() != "")
                {
                    model.OrderDateTime = DateTime.Parse(row["OrderDateTime"].ToString());
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = int.Parse(row["UID"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["AddressID"] != null && row["AddressID"].ToString() != "")
                {
                    model.AddressID = int.Parse(row["AddressID"].ToString());
                }
                if (row["ProductQty"] != null && row["ProductQty"].ToString() != "")
                {
                    model.ProductQty = int.Parse(row["ProductQty"].ToString());
                }
                if (row["TotalAmount"] != null && row["TotalAmount"].ToString() != "")
                {
                    model.TotalAmount = decimal.Parse(row["TotalAmount"].ToString());
                }
                if (row["PayTime"] != null && row["PayTime"].ToString() != "")
                {
                    model.PayTime = DateTime.Parse(row["PayTime"].ToString());
                }
                if (row["SendTime"] != null && row["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(row["SendTime"].ToString());
                }
                if (row["TakeTime"] != null && row["TakeTime"].ToString() != "")
                {
                    model.TakeTime = DateTime.Parse(row["TakeTime"].ToString());
                }
                if (row["AfterSaleTime"] != null && row["AfterSaleTime"].ToString() != "")
                {
                    model.AfterSaleTime = DateTime.Parse(row["AfterSaleTime"].ToString());
                }
                if (row["TranCode"] != null)
                {
                    model.TranCode = row["TranCode"].ToString();
                }
                if (row["TranType"] != null)
                {
                    model.TranType = row["TranType"].ToString();
                }
                if (row["PayMethod"] != null)
                {
                    model.PayMethod = row["PayMethod"].ToString();
                }
                if (row["Out_Trade_No"] != null)
                {
                    model.Out_Trade_No = row["Out_Trade_No"].ToString();
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
            strSql.Append("select OrderID,OrderNum,OrderDateTime,UID,Status,AddressID,ProductQty,TotalAmount,PayTime,SendTime,TakeTime,AfterSaleTime,TranCode,TranType,PayMethod,Out_Trade_No ");
            strSql.Append(" FROM T_Product_Orders ");
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
            strSql.Append(" OrderID,OrderNum,OrderDateTime,UID,Status,AddressID,ProductQty,TotalAmount,PayTime,SendTime,TakeTime,AfterSaleTime,TranCode,TranType,PayMethod,Out_Trade_No ");
            strSql.Append(" FROM T_Product_Orders ");
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
            strSql.Append("select count(1) FROM T_Product_Orders ");
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
                strSql.Append("order by T.OrderID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product_Orders T ");
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
            parameters[0].Value = "T_Product_Orders";
            parameters[1].Value = "OrderID";
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

