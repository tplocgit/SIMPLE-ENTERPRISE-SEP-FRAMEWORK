using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.FormControls;
using System.Windows.Forms;
using SEPFramework.Factories;
using SEPFramework.Buttons;
using System.Diagnostics;
using SEPFramework.DAO.MemberShip;
using SEPFramework.DAO;
using SEPFramework.DAO.DB;
using System.Data;
using SEPFramework.DataGridViews;
namespace SEPFramework.Forms
{
    class LoginForm : SEPForm
    {
        private FormControl username = new("Username", "");
        private FormControl password = new("Password", "", '*');
        public LoginForm() : this("Login")
        {

        }
        public LoginForm(string name) : base (name, "Login Form", SEPForm.Type.Main, "Login Form", new(width: 500, height: 300))
        {
            FactoryPanel factoryPanel = new();
            SEPButton btn_login = new ("Button Login", "Login" , OnClickLogin);
            SEPButton btn_register = new ("Button Register", "Register" , OnClickRegister);
            List<SEPButton> btn = new() { btn_login, btn_register };
            List<FormControl> fc = new() { this.username, this.password };

            this._panelButtons = factoryPanel.CreateFLPanelDockBottomButtons("Login/Register", btn);
            this._panelMain = factoryPanel.CreateTLPabelDockFillFormControls("main", fc);
            this.SetUpForm();
        }
        
        private void OnClickLogin(object sender, EventArgs args)
        {
            Debug.WriteLine("Login..."); 
            Membership p = new Membership(SingletonDatabase.getInstance().connString);
            if(p.Login(username.Value, password.Value))
            {
                MessageBox.Show("Login success");
                SingletonDatabase singletonDatabase = SingletonDatabase.getInstance();
                List<string> tables = singletonDatabase.GetAllTablesName();

                //-----------------Read data of all table in database------

                foreach (string name in tables)
                {
                    SEPForm dataGVF = new DataViewForm(name, name, name, name);
                    dataGVF.Show();
                }
                //foreach (DataRow dataRow in dataTable.Rows)
                //{
                //    //int count = 0;
                //    foreach (var item in dataRow.ItemArray)
                //    {

                //        //Debug.Write(item + $"-{count}-type:{item.GetType()}\t");
                //        //count++;
                //        if (item.GetType() == typeof(System.DBNull))
                //            Debug.Write("<NULL>\t");
                //        else
                //            Debug.Write(item + "\t");

                //    }
                //    Debug.WriteLine("");
                //}
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }

        private void OnClickRegister(object sender, EventArgs args)
        {
            Debug.WriteLine("Registering...");
            Membership p = new Membership(SingletonDatabase.getInstance().connString);
            if(p.Register(username.Value, password.Value))
            {
                MessageBox.Show("Register success");

                //SingletonDatabase singletonDatabase = SingletonDatabase.getInstance();
                //List<string> tables = singletonDatabase.GetAllTablesName();
                ////foreach (var i in tables)
                ////{
                ////    Debug.WriteLine(i);
                ////}

                ////-----------------Read data of all table in database------
                //SqlServerDAO sqlServerDAO = new SqlServerDAO(singletonDatabase.connString);

                //List<string> data = sqlServerDAO.GetAllFieldsName(tables[0]);
                //foreach (string item in data)
                //{
                //    Debug.Write(item + "\t");
                //}
                //Debug.WriteLine("");
                //DataTable dataTable = sqlServerDAO.GetAllData(tables[0]);
                //foreach (DataRow dataRow in dataTable.Rows)
                //{
                //    //int count = 0;
                //    foreach (var item in dataRow.ItemArray)
                //    {

                //        //Debug.Write(item + $"-{count}-type:{item.GetType()}\t");
                //        //count++;
                //        if (item.GetType() == typeof(System.DBNull))
                //            Debug.Write("<NULL>\t");
                //        else
                //            Debug.Write(item + "\t");

                //    }
                //    Debug.WriteLine("");
                //}
            }
            else
            {
                MessageBox.Show("Register failed");
            }
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
