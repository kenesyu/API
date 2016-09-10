using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;
using System.Collections.Generic;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Product
    /// </summary>
    public partial class T_Product
    {
        public T_Product()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Product(");
            strSql.Append("ProductName,Descriptions,TagID,RefProductID,Category1,Category2,LowPrice,OnSale,IsHot,IsNew)");
            strSql.Append(" values (");
            strSql.Append("@ProductName,@Descriptions,@TagID,@RefProductID,@Category1,@Category2,@LowPrice,@OnSale,@IsHot,@IsNew)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
				new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
				new SqlParameter("@Descriptions", SqlDbType.NVarChar,400),
				new SqlParameter("@TagID", SqlDbType.NVarChar,50),
				new SqlParameter("@RefProductID", SqlDbType.NVarChar,50),
                new SqlParameter("@Category1",SqlDbType.Int,4), 
                new SqlParameter("@Category2",SqlDbType.Int,4),
                new SqlParameter("@LowPrice",SqlDbType.Decimal,9),
                new SqlParameter("@OnSale",SqlDbType.Int,4),
                new SqlParameter("@IsHot",SqlDbType.Int,4),
                new SqlParameter("@IsNew",SqlDbType.Int,4),
                new SqlParameter("@CoverPhoto",SqlDbType.NVarChar,50),
                new SqlParameter("@CreateDate",SqlDbType.DateTime),
                new SqlParameter("@SalesVolume",SqlDbType.Int,4)
            };
                                        
                                        
            parameters[0].Value = model.ProductName;
            parameters[1].Value = model.Descriptions;
            parameters[2].Value = model.TagID;
            parameters[3].Value = model.RefProductID;
            parameters[4].Value = model.Category1;
            parameters[5].Value = model.Category2;
            parameters[6].Value = model.LowPrice;
            parameters[7].Value = model.OnSale;
            parameters[8].Value = model.IsHot;
            parameters[9].Value = model.IsNew;
            parameters[10].Value = model.CoverPhoto;
            parameters[11].Value = model.CreateDate;
            parameters[12].Value = model.SalesVolume;

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
        public bool Update(WebApi_Model.T_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Product set ");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Descriptions=@Descriptions,");
            strSql.Append("TagID=@TagID,");
            strSql.Append("RefProductID=@RefProductID,");
            strSql.Append("Category1=@Category1,");
            strSql.Append("Category2=@Category2");
            strSql.Append("LowPrice=@LowPrice,");
            strSql.Append("OnSale=@OnSale,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("IsNew=@IsNew,");
            strSql.Append("CoverPhoto=@CoverPhoto");
            strSql.Append(" where ProductID=@ProductID");
            SqlParameter[] parameters = {
				new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
				new SqlParameter("@Descriptions", SqlDbType.NVarChar,400),
				new SqlParameter("@TagID", SqlDbType.NVarChar,50),
				new SqlParameter("@RefProductID", SqlDbType.NVarChar,50),
                new SqlParameter("@Category1",SqlDbType.Int,4), 
                new SqlParameter("@Category2",SqlDbType.Int,4),
                new SqlParameter("@LowPrice", SqlDbType.Decimal,9),
				new SqlParameter("@OnSale", SqlDbType.Int,4),
				new SqlParameter("@IsHot", SqlDbType.Int,4),
				new SqlParameter("@IsNew", SqlDbType.Int,4),
                new SqlParameter("@CoverPhoto", SqlDbType.NVarChar,50),
				new SqlParameter("@ProductID", SqlDbType.Int,4)};


            parameters[0].Value = model.ProductName;
            parameters[1].Value = model.Descriptions;
            parameters[2].Value = model.TagID;
            parameters[3].Value = model.RefProductID;
            parameters[4].Value = model.Category1;
            parameters[5].Value = model.Category2;
            parameters[6].Value = model.LowPrice;
            parameters[7].Value = model.OnSale;
            parameters[8].Value = model.IsHot;
            parameters[9].Value = model.IsNew;
            parameters[10].Value = model.CoverPhoto;
            parameters[11].Value = model.ProductID;
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
        public bool Delete(int ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product ");
            strSql.Append(" where ProductID=@ProductID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProductID;

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
        public bool DeleteList(string ProductIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Product ");
            strSql.Append(" where ProductID in (" + ProductIDlist + ")  ");
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
        public WebApi_Model.T_Product GetModel(int ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductID,ProductName,Descriptions,TagID,RefProductID,Category1,Category2,LowPrice,OnSale,IsHot,IsNew,CoverPhoto,CreateDate,SalesVolume from T_Product ");
            strSql.Append(" where ProductID=@ProductID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProductID;

            WebApi_Model.T_Product model = new WebApi_Model.T_Product();
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
        public WebApi_Model.T_Product DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Product model = new WebApi_Model.T_Product();
            if (row != null)
            {
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(row["ProductID"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Descriptions"] != null)
                {
                    model.Descriptions = row["Descriptions"].ToString();
                }
                if (row["TagID"] != null)
                {
                    model.TagID = row["TagID"].ToString();
                }
                if (row["RefProductID"] != null)
                {
                    model.RefProductID = row["RefProductID"].ToString();
                }
                if (row["Category1"] != null && row["Category1"].ToString() != "")
                {
                    model.Category1 = int.Parse(row["Category1"].ToString());
                }
                if (row["Category2"] != null && row["Category2"].ToString() != "")
                {
                    model.Category2 = int.Parse(row["Category2"].ToString());
                }
                if (row["LowPrice"] != null && row["LowPrice"].ToString() != "")
                {
                    model.LowPrice = decimal.Parse(row["LowPrice"].ToString());
                }
                if (row["OnSale"] != null && row["OnSale"].ToString() != "")
                {
                    model.OnSale = int.Parse(row["OnSale"].ToString());
                }
                if (row["IsHot"] != null && row["IsHot"].ToString() != "")
                {
                    model.IsHot = int.Parse(row["IsHot"].ToString());
                }
                if (row["IsNew"] != null && row["IsNew"].ToString() != "")
                {
                    model.IsNew = int.Parse(row["IsNew"].ToString());
                }

                if (row["CoverPhoto"] != null && row["CoverPhoto"].ToString() != "")
                {
                    model.CoverPhoto = row["CoverPhoto"].ToString();
                }

                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }

                if (row["SalesVolume"] != null && row["SalesVolume"].ToString() != "")
                {
                    model.SalesVolume = int.Parse(row["SalesVolume"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM T_Product ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM T_Product ");
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
            strSql.Append("select count(1) FROM T_Product ");
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
                strSql.Append("order by T.ProductID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Product T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.Query(strSql.ToString());
        }


        //public DataSet GetListByPage(int Page, int PageSize, string strWhere, string strOrder, out int TotalPage)
        //{
        //    SqlParameter[] splist = new SqlParameter[]{
        //        new SqlParameter("@TableName","T_Product"),
        //        new SqlParameter("@ReFieldsStr","*"),
        //        new SqlParameter("@OrderString",strOrder),
        //        new SqlParameter("@WhereString",strWhere),
        //        new SqlParameter("@PageSize",PageSize),
        //        new SqlParameter("@PageIndex",Page),
        //        new SqlParameter("@TotalRecord",ParameterDirection.Output)
        //    };
        //    splist[6].Direction = ParameterDirection.Output;
        //    DataSet ds = DBHelper.RunProcedure("Proc_ShowList", splist, "table");
        //    TotalPage = Convert.ToInt32(splist[6].Value.ToString());
        //    return ds;
        //}

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
            parameters[0].Value = "T_Product";
            parameters[1].Value = "ProductID";
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

