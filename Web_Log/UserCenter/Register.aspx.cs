using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.Data;
using System.Data.OleDb;

namespace Web_Log.UserCenter
{
    public partial class Register : System.Web.UI.Page
    {
        private static string UserInfoDbPath = "~/App_Data/UserInfo.accdb";
        private string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath(UserInfoDbPath));
            email = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").ToString();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            bool IfOk = true;

            OleDbConnection myconn = DB.createConnection();
            myconn.Open();
            string insertStr = "insert into Info values('" +
                TextBoxUserName.Text + "','" +
                TextBoxUserName.Text + "','" +
                TextBoxPassWord.Text + "','" +
                RadioButtonListSex.SelectedValue + "','" +
                TextBoxAge.Text + "','" +
                TextBoxEmail.Text + "','" +
                DateTime.Now.ToString() +
                "')";
            OleDbCommand cmd = new OleDbCommand(insertStr, myconn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException)
            {
                LabelUserNameExists.Visible = true;
                IfOk = false;
            }
            myconn.Close();

            if (IfOk && IsValid) Response.Redirect("~/UserCenter/RegisterSucceed.aspx");
        }
    }
}