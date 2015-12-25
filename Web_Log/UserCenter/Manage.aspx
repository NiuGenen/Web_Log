<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Web_Log.UserCenter.Manage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1 runat="server" id="ManageUserName">用户名</h1>
            <div>
                <asp:Button runat="server" ID="NewArticle" Text="新建文章" OnClick="NewArticle_Click" CssClass="manage_newarticle_button"/>
            </div>
            <hr />
        </div>
        <div class="manage_whole_table">
            <asp:Repeater runat="server" ID="ManageArticleList" OnItemCommand="ManageArticleList_ItemCommand">
                <HeaderTemplate>
                    <table class="manage_table">
                        <tr>
                            <th>Title</th>
                            <th>Edit</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="manage_title">
                            <asp:LinkButton runat="server" ID="ManageTitle" CommandName ="Title" CommandArgument='<%#Eval("ID") %>' CssClass="manage_linkbutton"><%#Eval("Title") %></asp:LinkButton>
                        </td>
                        <td class="manage_edit">
                            <asp:LinkButton runat="server" ID="ManageEdit" CommandName="Edit" CommandArgument='<%#Eval("ID") %>' CssClass="manage_linkbutton">[编辑]</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="ManageDelete" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' CssClass="manage_linkbutton" OnClientClick="return confirm('确认删除?')">[删除]</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
