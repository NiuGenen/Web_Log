using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Log
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                login.Style.Add("display", "none");
                annonymous.Style.Add("display", "block");
            }
            else
            {
                annonymous.Style.Add("display", "none");
                login.Style.Add("display", "block");
            }
        }

        public void Login(string username)
        {
            Session["UserName"] = username;

            annonymous.Style.Add("display", "none");
            login.Style.Add("display", "block");
        }
        protected void Logout_click(object sender, EventArgs e)
        {
            Logout();

            Response.Redirect("~/Main.aspx");
        }

        public void Logout()
        {
            login.Style.Add("display", "none");
            annonymous.Style.Add("display", "block");

            Session["UserName"] = null;
        }
    }
}