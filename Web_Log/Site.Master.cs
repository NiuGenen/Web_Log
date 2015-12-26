using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.OleDb;

namespace Web_Log
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径

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
        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="username">用户名</param>
        public void Login(string username)
        {
            Session["UserName"] = username;
            annonymous.Style.Add("display", "none");
            login.Style.Add("display", "block");

            OleDbConnection myconn = DB.createConnection();
            myconn.Open();
            string updateStr = "update Friend set OnLine=1 where FriendName='" + username+"'";
            OleDbCommand cmd = new OleDbCommand(updateStr, myconn);
            cmd.ExecuteNonQuery();

            myconn.Close();
        }
        /// <summary>
        /// 用户注销
        /// </summary>
        public void Logout()
        {
            login.Style.Add("display", "none");
            annonymous.Style.Add("display", "block");

            OleDbConnection myconn = DB.createConnection();
            myconn.Open();
            string updateStr = "update Friend set OnLine=0 where FriendName='" + Session["UserName"].ToString() + "'";
            OleDbCommand cmd = new OleDbCommand(updateStr, myconn);
            cmd.ExecuteNonQuery();

            Session["UserName"] = null;
            myconn.Close();
        }
        protected void Logout_click(object sender, EventArgs e)
        {
            Logout();

            Response.Redirect("~/Main.aspx");
        }
        protected void UserCenter_click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
                Response.Redirect("~/UserCenter/Manage.aspx?username=" + Session["UserName"].ToString());
            else
            {
                Response.Write("<script>alert('请先登录')</script>");
            }
        }
    }
}