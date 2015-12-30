<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Web_Log.View" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1 id="ArticleName" runat="server" class="view_title">Title</h1>
            <h5 id="ArticleAuthor" runat="server" class="view_title">Author</h5>
            <asp:Button runat="server" ID="ArticleEdit" Text="Edit" CssClass="view_edit_button" OnClick="ArticleEdit_Click" />
            <hr />
        </div>
        <div>
            <div runat="server" class="view_content">
                <asp:TextBox runat="server" ID="ArticleContent" TextMode="MultiLine" ReadOnly="true" CssClass="view_text_content"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div>
            <div runat="server" class="view_content">
                <asp:Repeater runat="server" ID="ViewRemarkList">
                    <HeaderTemplate>
                        <table class="view_remarklist">
                            <tr>
                                <th class="view_remarklist_header">用户名</th>
                                <th class="view_remarklist_header">内容</th>
                                <th class="view_remarklist_header">时间</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="view_remarklist_username">
                                <asp:Label runat="server" ID="RemarkUserName" Text='<%#Eval("UserName") %>'></asp:Label>
                            </td>
                            <td class="view_remarklist_remarkcontent">
                                <asp:Label runat="server" ID="RemarkContent" Text='<%#Eval("RemarkContent") %>'></asp:Label>
                            </td>
                            <td class="view_remarklist_time">
                                <asp:Label runat="server" ID="RemarkTime" Text='<%#Eval("RemarkTime") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <hr />
                <asp:Button runat="server" ID="RemarkButton" Text="我要评论" CssClass="view_remarkbutton" OnClick="RemarkButton_Click" />
            </div>
            <div>
                <div runat="server" class="view_content">
                    <hr id="IRemarkLine" style="display:none" runat="server" />
                    <asp:TextBox runat="server" ID="IRemarkContent" TextMode="MultiLine" Rows="5" CssClass="view_remark_textbox" Visible="false"></asp:TextBox>
                    <hr id="IRemarkLine2" style="display:none" runat="server" />
                    <asp:Button runat="server" ID="IRemarkConfirm" Text="发表" CssClass="view_remarkconfirm_button" Visible="false" OnClick="IRemarkConfirm_Click"/>
                    <asp:Button runat="server" ID="IRemarkCancel" Text="取消" CssClass="view_remarkcancel_button" Visible="false" OnClick="IRemarkCancel_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
