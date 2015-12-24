<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Web_Log.View" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1 id="ArticleName" runat="server" class="view_title">Title</h1>
            <h5 id="ArticleAuthor" runat="server" class="view_title">Author</h5>
            <hr />
        </div>
        <div>
            <div runat="server" class="view_content">
                <asp:TextBox runat="server" id="ArticleContent" TextMode="MultiLine" ReadOnly="true" CssClass="view_text_content"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div>
            <asp:Button runat="server" ID="ArticleEdit" Text="Edit" CssClass="view_edit_button" OnClick="ArticleEdit_Click" />
        </div>
    </div>
</asp:Content>
