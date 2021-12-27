using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.DAO
{
    class Database
    {
        public List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();
            //string conString = "server=DESKTOP-UG6BPO3\\SQLEXPRESS;uid=nhatlong;pwd=nhatlong;";
            string conString = "Data Source=.; Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;
        }
    }
}
