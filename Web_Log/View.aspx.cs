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
        private string ARTICLEID;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径

            string[] ids = Request.QueryString.GetValues("id");
            ARTICLEID = ids[0];

            if (!IsPostBack)
            {
                OleDbConnection myconn = DB.createConnection();
                myconn.Open();

                /*打开文章*/
                string selectStr = "select Content from Article where ID=" + ARTICLEID;
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

                selectStr = "select Title from Article where ID=" + ARTICLEID;
                cmd = new OleDbCommand(selectStr, myconn);
                try
                {
                    ArticleName.InnerText = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    ArticleName.InnerText = "文章标题获取出错";
                    ArticleName.Style.Add("color", "#ff0000");
                }

                selectStr = "select UserName from Article where ID=" + ARTICLEID;
                cmd = new OleDbCommand(selectStr, myconn);
                try
                {
                    ArticleAuthor.InnerText = "   author: " + cmd.ExecuteScalar().ToString();

                }
                catch (Exception)
                {
                    ArticleAuthor.InnerText = "作者获取出错";
                    ArticleAuthor.Style.Add("color", "#ff0000");
                }
                /*打开评论区*/
                selectStr = "select * from Remark where ArticleId='" + ARTICLEID.ToString() + "'";
                OleDbDataAdapter oda = new OleDbDataAdapter(selectStr, myconn);
                DataSet ds = new DataSet();
                try
                {
                    oda.Fill(ds);
                    ViewRemarkList.DataSource = ds;
                    ViewRemarkList.DataBind();
                }
                catch (Exception) { }

                myconn.Close();
            }
        }

        protected void ArticleEdit_Click(object sender, EventArgs e)
        {
            if ("   author: " + Session["UserName"].ToString() != ArticleAuthor.InnerText)
            {
                Response.Write("<script>alert('您不是本篇文章的作者，无法完成操作')</script>");
            }
            else
            {
                Response.Redirect("~/Edit.aspx?id=" + ARTICLEID + "&mode=EDIT");
            }
        }

        protected void RemarkButton_Click(object sender, EventArgs e)
        {
            IRemarkCancel.Visible = true;
            IRemarkConfirm.Visible = true;
            IRemarkContent.Visible = true;
            IRemarkLine.Style.Add("display", "block");
            IRemarkLine2.Style.Add("display", "block");
        }

        protected void IRemarkCancel_Click(object sender, EventArgs e)
        {
            IRemarkCancel.Visible = false;
            IRemarkConfirm.Visible = false;
            IRemarkContent.Visible = false;
            IRemarkLine.Style.Add("display", "none");
            IRemarkLine2.Style.Add("display", "none");
        }

        protected void IRemarkConfirm_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string username = Session["UserName"].ToString();
                string datetime = DateTime.Now.ToString();
                string content = IRemarkContent.Text;

                if (content != string.Empty)
                {
                    OleDbConnection myconn = DB.createConnection();
                    myconn.Open();
                    string insertStr = "insert into Remark (UserName,RemarkTime,RemarkContent,ArticleId) values ('" + username + "','" + datetime + "','" + content + "','" + ARTICLEID.ToString() + "')";
                    OleDbCommand cmd = new OleDbCommand(insertStr, myconn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        IRemarkContent.Text = "评论出错";
                        myconn.Close();
                        return;
                    }

                    myconn.Close();
                    Response.Redirect("~/View.aspx?id=" + ARTICLEID.ToString());
                }
                else
                {
                    Response.Write("<script>alert('请填写评论内容')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请先登录')</script>");
            }
        }
    }
}