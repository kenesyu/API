using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WebApi_DBUtility;

namespace WebApi_DAL
{
    /// <summary>
    /// 数据访问类:T_Photo_Collection
    /// </summary>
    public partial class T_Photo_Collection
    {
        public T_Photo_Collection()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebApi_Model.T_Photo_Collection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Photo_Collection(");
            strSql.Append("CoverPhoto,Likes,Views,CreateDate,PhotoTagID,TotalImg,IsActive,RefProductID,PhotoType,IsFree,PiaoZi,TuiMao,Description,Category1,Category2)");
            strSql.Append(" values (");
            strSql.Append("@CoverPhoto,@Likes,@Views,@CreateDate,@PhotoTagID,@TotalImg,@IsActive,@RefProductID,@PhotoType,@IsFree,@PiaoZi,@TuiMao,@Description,@Category1,@Category2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CoverPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@Likes", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@PhotoTagID", SqlDbType.Int,4),
					new SqlParameter("@TotalImg", SqlDbType.Int,4),
					new SqlParameter("@IsActive", SqlDbType.Int,4),
					new SqlParameter("@RefProductID", SqlDbType.NVarChar,50),
					new SqlParameter("@PhotoType", SqlDbType.Int,4),
					new SqlParameter("@IsFree", SqlDbType.Int,4),
					new SqlParameter("@PiaoZi", SqlDbType.Int,4),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,100),
                    new SqlParameter("@Category1", SqlDbType.Int,4),
                    new SqlParameter("@Category2", SqlDbType.Int,4),
                                        };
            parameters[0].Value = model.CoverPhoto;
            parameters[1].Value = model.Likes;
            parameters[2].Value = model.Views;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.PhotoTagID;
            parameters[5].Value = model.TotalImg;
            parameters[6].Value = model.IsActive;
            parameters[7].Value = model.RefProductID;
            parameters[8].Value = model.PhotoType;
            parameters[9].Value = model.IsFree;
            parameters[10].Value = model.PiaoZi;
            parameters[11].Value = model.TuiMao;
            parameters[12].Value = model.Description;
            parameters[13].Value = model.Category1;
            parameters[14].Value = model.Category2;

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
        public bool Update(WebApi_Model.T_Photo_Collection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Photo_Collection set ");
            strSql.Append("CoverPhoto=@CoverPhoto,");
            strSql.Append("Likes=@Likes,");
            strSql.Append("Views=@Views,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("PhotoTagID=@PhotoTagID,");
            strSql.Append("TotalImg=@TotalImg,");
            strSql.Append("IsActive=@IsActive,");
            strSql.Append("RefProductID=@RefProductID,");
            strSql.Append("PhotoType=@PhotoType,");
            strSql.Append("IsFree=@IsFree,");
            strSql.Append("PiaoZi=@PiaoZi,");
            strSql.Append("TuiMao=@TuiMao,");
            strSql.Append("Description=@Description");
            strSql.Append("Category1=@Category1");
            strSql.Append("Category2=@Category2");
            strSql.Append(" where PhotoCollectionID=@PhotoCollectionID");
            SqlParameter[] parameters = {
					new SqlParameter("@CoverPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@Likes", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@PhotoTagID", SqlDbType.Int,4),
					new SqlParameter("@TotalImg", SqlDbType.Int,4),
					new SqlParameter("@IsActive", SqlDbType.Int,4),
					new SqlParameter("@RefProductID", SqlDbType.NVarChar,50),
					new SqlParameter("@PhotoType", SqlDbType.Int,4),
					new SqlParameter("@IsFree", SqlDbType.Int,4),
					new SqlParameter("@PiaoZi", SqlDbType.Int,4),
					new SqlParameter("@TuiMao", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,100),
                    new SqlParameter("@Category1", SqlDbType.Int,4),
                    new SqlParameter("@Category2", SqlDbType.Int,4),
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4)};
            parameters[0].Value = model.CoverPhoto;
            parameters[1].Value = model.Likes;
            parameters[2].Value = model.Views;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.PhotoTagID;
            parameters[5].Value = model.TotalImg;
            parameters[6].Value = model.IsActive;
            parameters[7].Value = model.RefProductID;
            parameters[8].Value = model.PhotoType;
            parameters[9].Value = model.IsFree;
            parameters[10].Value = model.PiaoZi;
            parameters[11].Value = model.TuiMao;
            parameters[12].Value = model.Description;
            parameters[13].Value = model.Category1;
            parameters[14].Value = model.Category2;
            parameters[15].Value = model.PhotoCollectionID;

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
        public bool Delete(int PhotoCollectionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Photo_Collection ");
            strSql.Append(" where PhotoCollectionID=@PhotoCollectionID");
            SqlParameter[] parameters = {
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4)
			};
            parameters[0].Value = PhotoCollectionID;

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
        public bool DeleteList(string PhotoCollectionIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Photo_Collection ");
            strSql.Append(" where PhotoCollectionID in (" + PhotoCollectionIDlist + ")  ");
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
        public WebApi_Model.T_Photo_Collection GetModel(int PhotoCollectionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from V_Photo_Collection ");
            strSql.Append(" where PhotoCollectionID=@PhotoCollectionID");
            SqlParameter[] parameters = {
					new SqlParameter("@PhotoCollectionID", SqlDbType.Int,4)
			};
            parameters[0].Value = PhotoCollectionID;

            WebApi_Model.T_Photo_Collection model = new WebApi_Model.T_Photo_Collection();
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
        public WebApi_Model.T_Photo_Collection DataRowToModel(DataRow row)
        {
            WebApi_Model.T_Photo_Collection model = new WebApi_Model.T_Photo_Collection();
            if (row != null)
            {
                if (row["PhotoCollectionID"] != null && row["PhotoCollectionID"].ToString() != "")
                {
                    model.PhotoCollectionID = int.Parse(row["PhotoCollectionID"].ToString());
                }
                if (row["CoverPhoto"] != null)
                {
                    model.CoverPhoto = row["CoverPhoto"].ToString();
                }
                if (row["Likes"] != null && row["Likes"].ToString() != "")
                {
                    model.Likes = int.Parse(row["Likes"].ToString());
                }
                if (row["Views"] != null && row["Views"].ToString() != "")
                {
                    model.Views = int.Parse(row["Views"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["PhotoTagID"] != null && row["PhotoTagID"].ToString() != "")
                {
                    model.PhotoTagID = row["PhotoTagID"].ToString();
                }
                if (row["TotalImg"] != null && row["TotalImg"].ToString() != "")
                {
                    model.TotalImg = int.Parse(row["TotalImg"].ToString());
                }
                if (row["IsActive"] != null && row["IsActive"].ToString() != "")
                {
                    model.IsActive = int.Parse(row["IsActive"].ToString());
                }
                if (row["RefProductID"] != null)
                {
                    model.RefProductID = row["RefProductID"].ToString();
                }
                if (row["PhotoType"] != null && row["PhotoType"].ToString() != "")
                {
                    model.PhotoType = int.Parse(row["PhotoType"].ToString());
                }
                if (row["IsFree"] != null && row["IsFree"].ToString() != "")
                {
                    model.IsFree = int.Parse(row["IsFree"].ToString());
                }
                if (row["PiaoZi"] != null && row["PiaoZi"].ToString() != "")
                {
                    model.PiaoZi = int.Parse(row["PiaoZi"].ToString());
                }
                if (row["TuiMao"] != null && row["TuiMao"].ToString() != "")
                {
                    model.TuiMao = int.Parse(row["TuiMao"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Category1"] != null && row["Category1"].ToString() != "")
                {
                    model.Category1 = int.Parse(row["Category1"].ToString());
                }
                if (row["Category2"] != null && row["Category2"].ToString() != "")
                {
                    model.Category2 = int.Parse(row["Category2"].ToString());
                }
                if (row["CategoryName1"] != null && row["CategoryName1"].ToString() != "")
                {
                    model.CategoryName1 = row["CategoryName1"].ToString();
                }
                if (row["CategoryName2"] != null && row["CategoryName2"].ToString() != "")
                {
                    model.CategoryName2 = row["CategoryName2"].ToString();
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
            strSql.Append("select *");
            strSql.Append(" FROM V_Photo_Collection ");
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
            strSql.Append(" *");
            strSql.Append(" FROM T_Photo_Collection ");
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
            strSql.Append("select count(1) FROM T_Photo_Collection ");
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
                strSql.Append("order by T.PhotoCollectionID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Photo_Collection T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.Query(strSql.ToString());
        }


        public DataSet GetListByPage(int Page, int PageSize, string strWhere, string strOrder, out int TotalPage)
        {
            SqlParameter[] splist = new SqlParameter[]{
                new SqlParameter("@TableName","V_Photo_Collection"),
                new SqlParameter("@ReFieldsStr","*"),
                new SqlParameter("@OrderString",strOrder),
                new SqlParameter("@WhereString",strWhere),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageIndex",Page),
                new SqlParameter("@TotalRecord",ParameterDirection.Output)
            };
            splist[6].Direction = ParameterDirection.Output;
            DataSet ds = DBHelper.RunProcedure("Proc_ShowList", splist, "table");
            TotalPage = Convert.ToInt32(splist[6].Value.ToString());
            return ds;
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
            parameters[0].Value = "T_Photo_Collection";
            parameters[1].Value = "PhotoCollectionID";
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

