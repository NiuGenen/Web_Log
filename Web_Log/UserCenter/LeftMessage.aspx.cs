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
    public partial class LeftMessage : System.Web.UI.Page
    {
        private string VisitedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));//设置数据库路径

            string[] visitedusers = Request.QueryString.GetValues("visiteduser");
            VisitedUser = visitedusers[0];

            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    LeftMessageTitle.InnerText = VisitedUser + " 的留言板";

                    OleDbConnection myconn = DB.createConnection();
                    myconn.Open();
                    string selectStr = "select * from LeftMessage where UserName='" + VisitedUser + "'";
                    OleDbDataAdapter oda = new OleDbDataAdapter(selectStr, myconn);
                    DataSet ds = new DataSet();
                    try
                    {
                        oda.Fill(ds);
                        LeftMessageList.DataSource = ds;
                        LeftMessageList.DataBind();
                    }
                    catch (Exception)
                    {
                        LeftMessageTitle.InnerText = "数据读取出错";
                    }

                    myconn.Close();
                }
                else
                {
                    LeftMessageTitle.InnerText = "请先登录";
                    LeftMessageBolck.Style.Add("display", "none");
                }
            }
        }
        /// <summary>
        /// 打开留言编辑器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LeftMessageButton_Click(object sender, EventArgs e)
        {
            LeftMessageBoxUp.Visible = true;
            LeftMessageBoxDown.Visible = true;
            LeftMessageTextBox.Visible = true;
            LeftMessageConfirm.Visible = true;
            LeftMessafeCancle.Visible = true;
        }
        /// <summary>
        /// 关闭留言编辑器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LeftMessafeCancle_Click(object sender, EventArgs e)
        {
            LeftMessageBoxUp.Visible = false;
            LeftMessageBoxDown.Visible = false;
            LeftMessageTextBox.Visible = false;
            LeftMessageTextBox.Text = string.Empty;
            LeftMessageConfirm.Visible = false;
            LeftMessafeCancle.Visible = false;
        }
        /// <summary>
        /// 发表留言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LeftMessageConfirm_Click(object sender, EventArgs e)
        {
            string content = LeftMessageTextBox.Text;
            if (content != string.Empty)
            {
                string username = Session["UserName"].ToString();
                //string VisitedUser
                string datetime = DateTime.Now.ToString();

                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string insertStr = "insert into LeftMessage (UserName,LeftUser,LeftContent,LeftTime) values('"+VisitedUser+"','"+username+"','"+content+"','"+datetime+"')";
                OleDbCommand cmd = new OleDbCommand(insertStr, myconn);
                try
                {
                    cmd.ExecuteNonQuery();
                    myconn.Close();
                    Response.Redirect("~/UserCenter/LeftMessage.aspx?visiteduser=" + VisitedUser);
                    return;
                }
                catch (Exception)
                {
                    LeftMessageTextBox.Text = "留言失败";
                }

                myconn.Close();
            }
        }
        /// <summary>
        /// 留言板单击
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void LeftMessageList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "user")
            {
                Response.Redirect("~/UserCenter/Manage.aspx?username=" + e.CommandArgument.ToString());
            }
            else if(e.CommandName == "reply")
            {
                LeftMessageButton_Click(new object(),new EventArgs());
                LeftMessageTextBox.Text = "回复:[" + e.CommandArgument.ToString() + "]\n";
            }
        }
    }
}