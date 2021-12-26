using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.DB;
using TestDatabase.MemberShip;

namespace TestDatabase
{
    class MainMethod
    {
        static void Main()
        {
            Database databases = new Database();
            List<string> list = databases.GetDatabaseList();

            SingletonDatabase singletonDatabase = SingletonDatabase.getInstance();
            singletonDatabase.connString = $@"Data Source=.;Initial Catalog=QLDuLich;Integrated Security=True";
            //singletonDatabase.connString = $@"Data Source=.;Initial Catalog=master;Integrated Security=True";
            //singletonDatabase.connString = $@"Data Source=.;Integrated Security=True";
            List<string> tables = singletonDatabase.GetAllTablesName();

            SqlServerDAO sqlServerDAO = new SqlServerDAO(singletonDatabase.connString);
            Dictionary<string, object> fields = new Dictionary<string, object>();
            /*fields.Add("BienSo", "123-123");
            fields.Add("HieuXe", "Yamahehehe");
            fields.Add("SoCho", 10);*/
            //sqlServerDAO.Update(fields, "Xe");
            //sqlServerDAO.Insert(fields, "Xe");

            //Console.WriteLine(sqlServerDAO.GetPrimaryKey("GV_DT"));

            //sqlServerDAO.Delete("Xe", "123-123");

            /*foreach (string item in list)
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
            membership.Register("Long1", "123456");*/

            Console.ReadKey();
        }
    }
}