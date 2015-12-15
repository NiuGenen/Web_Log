<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="Web_Log.Article" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>文章列表</h1>
            <hr />
        </div>
        <div style="position: relative">
            <div id="article_anounymous" runat="server" class="article_form_anounymous">
                <h2>您尚未登陆</h2>
            </div>
            <div id="article_login" runat="server" class="article_form_login">
                <h3 id="article_welcome" runat="server">欢迎栏，显示用户名称</h3>
                <hr />
                <div>
                    <asp:GridView runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
