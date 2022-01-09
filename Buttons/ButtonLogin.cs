using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.DAO.MemberShip;
using SEPFramework.DAO;
namespace SEPFramework.Buttons
{
    class ButtonLogin : SEPButton
    {
        string username = "", password = "";
        public ButtonLogin(string name, Size size, Point location) : base(name, "Login", size, location)
        {

        }

        public ButtonLogin(string name) : base(name, "Login")
        {

        }
        public string Username { set { this.username = value; } }
        public string Password { set { this.password = value; } }


        protected override void OnClick(object sender, EventArgs e)
        {
            Membership p = new Membership(SingletonDatabase.getInstance().connString);
            p.Login(this.username, this.password);
        }
    }
}
