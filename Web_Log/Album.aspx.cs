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
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径

            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    OleDbConnection myconn = DB.createConnection();
                    myconn.Open();
                    string selectStr = "select * from Album";
                    OleDbDataAdapter oda = new OleDbDataAdapter(selectStr, myconn);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    AlbumList.DataSource = ds;
                    AlbumList.DataBind();

                    myconn.Close();
                }
                else
                {
                    AlbumLabel.Text = "请先登录";
                    AlbumLabel.Visible = true;
                }
            }
        }

        protected void AlbumList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "user")
            {
                Response.Redirect("~/UserCenter/Manage.aspx?username=" + e.CommandArgument.ToString());
            }
            else if(e.CommandName == "image")
            {
                Response.Redirect("~/Image.aspx?imageurl=" + e.CommandArgument.ToString());
            }
        }
    }
}