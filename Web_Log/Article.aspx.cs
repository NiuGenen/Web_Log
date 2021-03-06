﻿using System;
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
            if (!IsPostBack)
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

        protected void repeaterform_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton username = e.Item.FindControl("labelusername") as LinkButton;
            if (e.CommandName == "title")
            {
                Response.Redirect("~/View.aspx?id=" + (string)e.CommandArgument);
            }
            else if (e.CommandName == "edit")
            {
                if (username.Text != Session["UserName"].ToString())
                {
                    Response.Write("<script>alert('您不是本篇文章的作者，无法完成操作')</script>");
                }
                else
                {
                    string id = e.CommandArgument as string;
                    Response.Redirect("~/Edit.aspx?id=" + id + "&mode=EDIT");
                }
            }
            else if (e.CommandName == "delete")
            {
                if (username.Text != Session["UserName"].ToString())
                {
                    Response.Write("<script>alert('您不是本篇文章的作者，无法完成操作')</script>");
                }
                else
                {
                    string id = e.CommandArgument as string;
                    OleDbConnection myconn = DB.createConnection();
                    myconn.Open();
                    string selectStr = "delete from Article where ID=" + id;
                    OleDbCommand cmd = new OleDbCommand(selectStr, myconn);
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
                    Response.Redirect("~/Article.aspx");
                }
            }
            else if(e.CommandName == "user")
            {
                string visitname = e.CommandArgument as string;
                Response.Redirect("~/UserCenter/Manage.aspx?username=" + visitname);
            }
        }
    }
}