using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Data.OleDb;

namespace Web_Log.UserCenter
{
    public partial class Manage : System.Web.UI.Page
    {
        private bool IsVisit;
        private string VisitedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.setDBPath(Page.Server.MapPath("/App_Data/UserCenter.accdb"));

            string[] usernames = Request.QueryString.GetValues("username");
            VisitedUser = usernames[0];

            if (Session["UserName"] != null && Session["UserName"].ToString() == VisitedUser)
            {
                ManageUserName.InnerText = "欢迎你，" + Session["UserName"].ToString();
                IsVisit = false;

                if (!IsPostBack)
                {
                    OleDbConnection myconn = DB.createConnection();
                    myconn.Open();
                    /*我的文章*/
                    string selectStr = "select * from Article where UserName='" + Session["UserName"].ToString() + "'";
                    OleDbDataAdapter oda = new OleDbDataAdapter(selectStr, myconn);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    ManageArticleList.DataSource = ds;
                    ManageArticleList.DataBind();
                    /*我的相册*/
                    selectStr = "select * from Album where UserName='" + Session["UserName"].ToString() + "'";
                    oda = new OleDbDataAdapter(selectStr, myconn);
                    DataSet dsp = new DataSet();
                    oda.Fill(dsp);
                    ManageAlbum.DataSource = dsp;
                    ManageAlbum.DataBind();
                    /*我的好友*/
                    selectStr = "select * from Friend where UserName='" + Session["UserName"].ToString() + "'";
                    oda = new OleDbDataAdapter(selectStr, myconn);
                    DataSet dsf = new DataSet();
                    oda.Fill(dsf);
                    ManageFriend.DataSource = dsf;
                    ManageFriend.DataBind();

                    myconn.Close();
                }
            }
            else if (Session["UserName"] != null)
            {
                NewArticle.Visible = false;
                ManageUserName.InnerText = "访客模式 to " + VisitedUser;
                AddAttentionButton.Visible = true;
                IsVisit = true;
                FriendBlock.Style.Add("display", "none");
                GetImage.Visible = false;
                AddImage.Visible = false;
                ChangeInfo.Visible = false;

                if (!IsPostBack)
                {
                    OleDbConnection myconn = DB.createConnection();
                    myconn.Open();
                    string selectStr = "select * from Article where UserName='" + usernames[0] + "'";
                    OleDbDataAdapter oda = new OleDbDataAdapter(selectStr, myconn);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    ManageArticleList.DataSource = ds;
                    ManageArticleList.DataBind();

                    selectStr = "select * from Album where UserName='" + VisitedUser + "'";
                    oda = new OleDbDataAdapter(selectStr, myconn);
                    DataSet dsp = new DataSet();
                    oda.Fill(dsp);
                    ManageAlbum.DataSource = dsp;
                    ManageAlbum.DataBind();

                    myconn.Close();
                }
            }
            else
            {
                ManageUserName.InnerText = "请先登录";
                AlbumBlock.Style.Add("display", "none");
                ArticleBlock.Style.Add("display", "none");
                FriendBlock.Style.Add("display", "none");
            }

        }
        /// <summary>
        /// 文章列表单击
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void ManageArticleList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Title")
            {
                Response.Redirect("~/View.aspx?id=" + (string)e.CommandArgument);
            }
            else if (IsVisit)
            {
                Response.Write("<script>alert('访客状态不能操作')</script>");
            }
            else if (e.CommandName == "Edit" && !IsVisit)
            {
                Response.Redirect("~/Edit.aspx?id=" + (string)e.CommandArgument + "&mode=EDIT");
            }
            else if (e.CommandName == "Delete" && !IsVisit)
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
                Response.Redirect("~/UserCenter/Manage.aspx?username=" + Session["UserNAme"].ToString());
            }
        }
        /// <summary>
        /// 新建文章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewArticle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Edit.aspx?id=-1&mode=NEW");
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddAttentionButton_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string myname = Session["UserName"].ToString();
                //string VisitUser

                OleDbConnection myconn = DB.createConnection();
                myconn.Open();

                string selectStr = "select * from Friend where UserName='" + myname + "' and FriendName='" + VisitedUser + "'";
                OleDbCommand cmd = new OleDbCommand(selectStr, myconn);
                try
                {
                    if (cmd.ExecuteScalar() == null)
                    {
                        string insertStr = "insert into Friend (UserName,FriendName) values('" + myname + "','" + VisitedUser + "')";
                        cmd = new OleDbCommand(insertStr, myconn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            Response.Write("<script>alert('操作失败,请重试')</script>");
                        }

                        Response.Write("<script>alert('关注成功')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('已关注')</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('操作失败,请重试')</script>");
                }

                myconn.Close();
            }
        }
        /// <summary>
        /// 图片单击
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Manage_Album_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "image")
            {
                string imageurl = e.CommandArgument as string;
                Response.Redirect("~/Image.aspx?imageurl=" + imageurl);
            }
        }
        /// <summary>
        /// 好友列表单击
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void ManageFriend_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "friend")
            {
                string friendname = e.CommandArgument as string;
                Response.Redirect("~/UserCenter/Manage.aspx?username=" + friendname);
            }
        }
        /// <summary>
        /// 进入留言板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LeftMessage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserCenter/LeftMessage.aspx?visiteduser=" + VisitedUser);
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Image_Click(object sender, EventArgs e)
        {
            if (GetImage.HasFile)
            {
                string sourceImage = GetImage.FileName;
                string newimagename =
                    DateTime.Now.Year + "_" +
                    DateTime.Now.Month + "_" +
                    DateTime.Now.Day + "_" +
                    DateTime.Now.Hour + "_" +
                    DateTime.Now.Minute + "_" +
                    DateTime.Now.Second +
                    Path.GetExtension(sourceImage);
                string newimagePath = "~/Album/" + Session["UserName"].ToString() + "/" + newimagename;
                try
                {
                    if (!Directory.Exists(Server.MapPath("~/Album/" + Session["UserName"].ToString())))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Album/" + Session["UserName"].ToString()));
                    }

                    Stream input = GetImage.FileContent;
                    FileStream output = new FileStream(Server.MapPath(newimagePath), FileMode.CreateNew);
                    byte[] buffer = new byte[2048];
                    int bytesread = 0;
                    do
                    {
                        bytesread = input.Read(buffer, 0, buffer.Length);
                        output.Write(buffer, 0, bytesread);
                    } while (bytesread > 0);
                    input.Close();
                    output.Close();
                }
                catch (Exception)
                {
                    string message = "<script>alert('" + Server.MapPath(newimagePath) + " 上传失败')</script>";
                    Response.Write(message);
                    return;
                }

                OleDbConnection myconn = DB.createConnection();
                myconn.Open();
                string insertStr = "insert into Album (UserName,ImageURL) values('" + Session["UserName"].ToString() + "','" + newimagePath + "')";
                OleDbCommand cmd = new OleDbCommand(insertStr, myconn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('上传失败')</script>");
                    myconn.Close();
                    return;
                }

                myconn.Close();
                Response.Redirect("~/UserCenter/Manage.aspx?username=" + VisitedUser);
            }
            else
            {
                Response.Write("<script>alert('请先选择图片')</script>");
            }
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChangeInfo_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
                Response.Redirect("~/UserCenter/UserInfoChange.aspx?username=" + Session["UserName"].ToString());
        }
    }
}