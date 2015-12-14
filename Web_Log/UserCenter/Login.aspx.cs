using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Log.UserCenter
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLoginSubmit_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                bool IfRemember = RadioButtonRememberMe.Checked;
                string username = TextBoxLoginUserName.Text;
                string password = TextBoxLoginPassWord.Text;

                ((Site)Master).Login(username);

                Response.Redirect("~/UserCenter/Manage.aspx");
            }
        }

        protected void ButtonLoginRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserCenter/Login.aspx");
        }
    }
}