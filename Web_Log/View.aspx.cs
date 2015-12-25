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
    public partial class View : System.Web.UI.Page
    {
        private string USERID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] ids = Request.QueryString.GetValues("id");
            USERID = ids[0];

            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径
            OleDbConnection myconn = DB.createConnection();
            myconn.Open();
            string selectStr = "select Content from Article where ID=" + USERID;
            OleDbCommand cmd = new OleDbCommand(selectStr, myconn);//打开数据库并查询文章内容

            try
            {
                string content = cmd.ExecuteScalar().ToString();
                ArticleContent.Text = content;
                ArticleContent.Rows = 15;
            }
            catch (NullReferenceException)
            {
                ArticleContent.Text = "文章读取出错";
                ArticleContent.ForeColor = System.Drawing.Color.Red;
            }

            selectStr = "select Title from Article where ID=" + USERID;
            cmd = new OleDbCommand(selectStr, myconn);
            ArticleName.InnerText = cmd.ExecuteScalar().ToString();

            selectStr = "select UserName from Article where ID=" + USERID;
            cmd = new OleDbCommand(selectStr, myconn);
            ArticleAuthor.InnerText = "   author: " + cmd.ExecuteScalar().ToString();

            myconn.Close();
        }

        protected void ArticleEdit_Click(object sender, EventArgs e)
        {
            if ("   author: " + Session["UserName"].ToString() != ArticleAuthor.InnerText)
            {
                Response.Write("<script>alert('您不是本篇文章的作者，无法完成操作')</script>");
            }
            else
            {
                Response.Redirect("~/Edit.aspx?id=" + USERID +"&mode=EDIT");
            }
        }
    }
}