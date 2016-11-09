using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_DBUtility;

namespace VIPUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = DBHelper.Query("select * from T_User").Tables[0];
            foreach (DataRow dr in dt.Rows) {
                if (dr["VipOverDueDate"] == null || dr["VipOverDueDate"].ToString() == "")
                {
                    DBHelper.ExecuteSql("update T_User set VipLevel = 0 where uid = " + dr["UID"].ToString());
                }
                else if  (dr["VipOverDueDate"] != null)
                {
                    DateTime OverDueDate =  Convert.ToDateTime(dr["VipOverDueDate"].ToString());
                    if (OverDueDate < DateTime.Now)
                    {
                        DBHelper.ExecuteSql("update T_User set VipLevel = 0 where uid = " + dr["UID"].ToString());
                    }

                    if (OverDueDate > DateTime.Now && OverDueDate.AddDays(-365) < DateTime.Now) {
                        DBHelper.ExecuteSql("update T_User set VipLevel = 1 where uid = " + dr["UID"].ToString());
                    }

                    if (OverDueDate > DateTime.Now && OverDueDate.AddDays(-365) > DateTime.Now)
                    {
                        DBHelper.ExecuteSql("update T_User set VipLevel = 2 where uid = " + dr["UID"].ToString());
                    }
                    //
                }

                //if(dr["VipOverDueDate"] != null && Convert.ToDateTime(dr["VipOverDueDate"].ToString()) > DateTime.Now && )

            }
            //Console.Read();
        }
    }
}
