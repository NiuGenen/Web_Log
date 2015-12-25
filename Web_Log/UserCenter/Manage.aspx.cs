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
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));

            if (Session["UserName"] != null)
            {
                ManageUserName.InnerText = "欢迎你，" + Session["UserName"].ToString();

                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string selectStr = "select * from Article where UserName='" + Session["UserName"].ToString() + "'";
                OleDbDataAdapter oda = new OleDbDataAdapter(selectStr, myconn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                ManageArticleList.DataSource = ds;
                ManageArticleList.DataBind();
                myconn.Close();
            }
        }

        protected void ManageArticleList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName=="Title")
            {
                Response.Redirect("~/View.aspx?id=" + (string)e.CommandArgument);
            }
            else if(e.CommandName=="Edit")
            {
                Response.Redirect("~/Edit.aspx?id=" + (string)e.CommandArgument + "&mode=EDIT");
            }
            else if(e.CommandName=="Delete")
            {
                string USERID = (string)e.CommandArgument;

                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string deleteStr = "delete from Article where ID=" + USERID;
                OleDbCommand cmd = new OleDbCommand(deleteStr, myconn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('删除失败')</script>");
                    myconn.Close();
                    return;
                }
                myconn.Close();
                Response.Redirect("~/UserCenter/Manage.aspx");
            }
        }

        protected void NewArticle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Edit.aspx?id=-1&mode=NEW");
        }
    }
}