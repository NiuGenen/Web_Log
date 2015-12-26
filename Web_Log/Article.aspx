<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="Web_Log.Article" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>所有文章列表</h1>
            <hr />
        </div>
        <div style="position: relative">
            <div id="article_anounymous" runat="server" class="article_form_anounymous">
                <h2>您尚未登陆</h2>
            </div>
            <div id="article_login" runat="server" class="article_form_login">
                <div id="article_login_title" runat="server">
                    <h3 id="article_welcome" runat="server">欢迎栏，显示用户名称</h3>
                </div>
                <div id="article_login_list" runat="server">
                    <asp:Repeater runat="server" ID="repeaterform" OnItemCommand="repeaterform_ItemCommand">
                        <HeaderTemplate>
                            <table class="article_table">
                                <tr>
                                    <th class="article_repeaterform_header">Title</th>
                                    <th class="article_repeaterform_header">Auther</th>
                                    <th class="article_repeaterform_header">Edit</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="article_repeaterform_title">
                                    <asp:LinkButton runat="server" ID="Title" CssClass="article_title" CommandName="title" CommandArgument='<%#Eval("ID") %>'><%#Eval("Title") %></asp:LinkButton>
                                </td>
                                <td class="article_repeaterform_author">
                                    <asp:LinkButton runat="server" ID="labelusername" Text='<%# Eval("UserName") %>' CssClass="article_title" CommandName="user" CommandArgument='<%#Eval("UserName") %>' />
                                </td>
                                <td class="article_repeaterform_edit">
                                    <asp:LinkButton runat="server" ID="Edit" CssClass="article_edit_and_delete" CommandName="edit" CommandArgument='<%# Eval("ID") %>'>[编辑]</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="Delete" CssClass="article_edit_and_delete" CommandName="delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('确认删除?')">[删除]</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
