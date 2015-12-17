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
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));

            if (Session["UserName"] == null)
            {
                article_anounymous.Style.Add("display", "block");
                article_login.Style.Add("display", "none");
            }
            else
            {
                article_login.Style.Add("display", "block");
                article_anounymous.Style.Add("display", "none");

                article_welcome.InnerText = "欢迎你，" + Session["UserName"].ToString();


                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string selectStr = "select * from Article";
                OleDbDataAdapter oda = new OleDbDataAdapter(selectStr, myconn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                repeaterform.DataSource = ds;
                repeaterform.DataBind();
                myconn.Close();

            }
        }
    }
}