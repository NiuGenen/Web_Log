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
    public partial class Edit : System.Web.UI.Page
    {
        private bool changed = false;
        private string originaltitle;
        private string USERID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] ids = Request.QueryString.GetValues("id");
            USERID = ids[0];

            if (!IsPostBack)
            {
                DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径

                /*加载文章*/
                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string selectStr = "select Content from Article where ID=" + USERID;
                OleDbCommand cmd = new OleDbCommand(selectStr, myconn);//打开数据库并查询文章内容

                try
                {
                    string content = cmd.ExecuteScalar().ToString();
                    EditContent.Text = content;
                    EditContent.Rows = 15;
                }
                catch (Exception)
                {
                    EditContent.Text = "文章读取出错";
                    EditContent.ForeColor = System.Drawing.Color.Red;
                }

                selectStr = "select Title from Article where ID=" + USERID;
                cmd = new OleDbCommand(selectStr, myconn);
                originaltitle = cmd.ExecuteScalar().ToString();
                EditTitle.Text = originaltitle;

                myconn.Close();
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                string title = EditTitle.Text;
                string content = EditContent.Text;

                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string updateStr = "update Article set Title='" + title + "',Content='" + content + "' where ID=" + USERID;
                OleDbCommand cmd = new OleDbCommand(updateStr, myconn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('保存失败')</script>");
                }

                myconn.Close();

                Response.Redirect("~/Edit.aspx?id=" + USERID);
            }
            else
            {
                Response.Write("<script>alert('尚未修改无需保存')</script>");
            }
        }

        protected void editcontent_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        protected void Edit_Title_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }
    }
}