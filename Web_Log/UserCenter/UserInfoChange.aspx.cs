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
    public partial class UserInfoChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径
            if (!IsPostBack)
            {
                userinfochangetitle.InnerText += " - " + Session["UserName"].ToString();
            }
        }
        protected void ButtonSubmitChange_Click(object sender, EventArgs e)
        {
            string oldpassword = TextBoxOldPassWord.Text;
            string newpassword = TextBoxChangePassWordConfirm.Text;
            string newsex = RadioButtonListChangeSex.SelectedValue;
            string newage = TextBoxChangeAge.Text;
            string newemail = TextBoxChangeEmail.Text;

            OleDbConnection myconn = DB.createConnection();
            myconn.Open();

            string selectStr = "select [PassWord] from UserInfo where UserName='" + Session["UserName"].ToString() + "'";
            OleDbCommand cmd = new OleDbCommand(selectStr, myconn);
            //try
            //{
            string password = cmd.ExecuteScalar().ToString();
            if (password == oldpassword)
            {
                LabelOlePassWordWrong.Visible = false;

                string updateStr = "update UserInfo set [PassWord] ='" + newpassword + "' where UserName='" + Session["UserName"].ToString() + "'";
                cmd = new OleDbCommand(updateStr, myconn);
                cmd.ExecuteNonQuery();

                if (newsex != string.Empty)
                {
                    updateStr = "update UserInfo set Sex='" + newsex + "' where UserName='" + Session["UserName"].ToString() + "'";
                    cmd = new OleDbCommand(updateStr, myconn);
                    cmd.ExecuteNonQuery();
                }
                if (newage != string.Empty)
                {
                    updateStr = "update UserInfo set Age='" + newage + "' where UserName='" + Session["UserName"].ToString() + "'";
                    cmd = new OleDbCommand(updateStr, myconn);
                    cmd.ExecuteNonQuery();
                }
                if (newemail != string.Empty)
                {
                    updateStr = "update UserInfo set Email='" + newemail + "' where UserName='" + Session["UserName"].ToString() + "'";
                    cmd = new OleDbCommand(updateStr, myconn);
                    cmd.ExecuteNonQuery();
                }
                Response.Redirect("~/UserCenter/Login.aspx");
            }
            else
            {
                LabelOlePassWordWrong.Visible = true;
            }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            myconn.Close();
        }
    }
}