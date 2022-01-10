using SEPFramework.DAO.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.DAO
{
    class MainMethod
    {
        /*static void Main()
        {
            Database databases = new Database();
            List<string> list = databases.GetDatabaseList();

            SingletonDatabase singletonDatabase = SingletonDatabase.getInstance();
            singletonDatabase.connString = $@"Data Source=.;Initial Catalog=QLDuLich;Integrated Security=True";
            //singletonDatabase.connString = $@"Data Source=.;Initial Catalog=master;Integrated Security=True";
            //singletonDatabase.connString = $@"Data Source=.;Integrated Security=True";
            List<string> tables = singletonDatabase.GetAllTablesName();

            SqlServerDAO sqlServerDAO = new SqlServerDAO(singletonDatabase.connString);
            *//*Dictionary<string, object> _fields = new Dictionary<string, object>();
            _fields.Add("BienSo", "123-123");
            _fields.Add("HieuXe", "Yamahehehe");
            _fields.Add("SoCho", 10);*//*
            //sqlServerDAO.Update(_fields, "Xe");
            //sqlServerDAO.Insert(_fields, "Xe");

            DataTable dataTable = sqlServerDAO.GetAllData("Xe");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + "  -  ");
                }
                Console.WriteLine();
            }

            List<string> data = sqlServerDAO.GetAllFieldsName("Xe");
            foreach (string item in data)
            {
                Console.WriteLine(item);
            }


            //Console.WriteLine(sqlServerDAO.GetPrimaryKey("GV_DT"));

            //sqlServerDAO.Delete("Xe", "123-123");

            *//*foreach (string item in list)
            {
                Console.WriteLine("   - " + item + ": ");
                SingletonDatabase singletonDatabase = SingletonDatabase.getInstance();
                singletonDatabase.connString = $@"Data Source=.;Initial Catalog={item};Integrated Security=True";
                *//*List<string> tables = singletonDatabase.GetAllTablesName();
                foreach (string table in tables)
                {
                    Console.WriteLine(table + ", ");
                }*//*
                SqlServerDAO sqlServerDAO = new SqlServerDAO(singletonDatabase.connString);
                Console.WriteLine(sqlServerDAO.GetPrimaryKey());
            }*/

        /* foreach (string table in tables)
         {
             Console.WriteLine(table + "");
             SqlServerDAO sqlServerDAO = new SqlServerDAO(singletonDatabase.connString);
             Console.WriteLine(sqlServerDAO.GetPrimaryKey(table));
         }*/

        /*Membership membership = new Membership(singletonDatabase.connString);
        membership.Register("Long1", "123456");*//*

        Console.ReadKey();
    }
*/
    }
}
