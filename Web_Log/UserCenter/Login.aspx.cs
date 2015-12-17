using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.OleDb;

namespace Web_Log.UserCenter
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径

            HttpCookie cookie = Request.Cookies["RememberUser"];//是否记住用户
            if(cookie!=null)
            {
                TextBoxLoginUserName.Text = cookie["UserName"];
                TextBoxLoginPassWord.Text = cookie["PassWord"];
                RadioButtonRememberMe.Checked = true;
            }
        }

        protected void ButtonLoginSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                bool IfRemember = RadioButtonRememberMe.Checked;
                string username = TextBoxLoginUserName.Text;
                string password = TextBoxLoginPassWord.Text;//获取用户名、密码和记住状态

                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string selectStr = "select PassWord from UserInfo where UserName='" + username + "'";
                OleDbCommand cmd = new OleDbCommand(selectStr, myconn);//打开数据库并查询密码

                try
                {
                    string key = cmd.ExecuteScalar().ToString();//查询密码。捕获空引用异常（用户不存在）
                    if (key == password)//密码相同
                    {
                        LabelErrorUserNotExist.Visible = false;
                        LabelErrorWrongPassWord.Visible = false;
                        ((Site)Master).Login(username);//登录
                        if (IfRemember)//确认记住
                        {
                            HttpCookie cookie = new HttpCookie("RememerUser");
                            cookie["UserName"] = username;
                            cookie["PassWord"] = password;
                            cookie.Expires = DateTime.MaxValue;
                            Response.Cookies.Add(cookie);
                        }//否则清除cookie
                        else 
                            Request.Cookies.Remove("RememberUser");
                        //跳转页面
                        Response.Redirect("~/UserCenter/Manage.aspx");
                    }
                    else//密码错误
                    {
                        LabelErrorUserNotExist.Visible = false;
                        LabelErrorWrongPassWord.Visible = true;
                    }
                }
                catch (NullReferenceException)//用户名不存在
                {
                    LabelErrorUserNotExist.Visible = false;
                    LabelErrorUserNotExist.Visible = true;
                    myconn.Close();
                    return;
                }
                myconn.Close();//关闭数据库
            }
        }

        protected void ButtonLoginRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserCenter/Login.aspx");//注册页面
        }
    }
}