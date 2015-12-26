<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="Web_Log.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>所有图片</h1>
        <hr />
    </div>
    <div>
        <asp:Label runat="server" ID ="AlbumLabel" Visible="false"></asp:Label>
        <asp:Repeater runat="server" ID="AlbumList" OnItemCommand="AlbumList_ItemCommand">
            <HeaderTemplate>
                <table class="album_table">
                    <tr>
                        <th>用户名</th>
                        <th>图片</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="album_username">
                        <asp:LinkButton runat="server" Text='<%#Eval("UserName") %>' CommandName="user" CommandArgument='<%#Eval("UserName") %>' CssClass="album_username_linkbutton"></asp:LinkButton>
                    </td>
                    <td class="album_image">
                        <asp:ImageButton runat="server" ID="Image1" ImageUrl='<%#Eval("ImageURL") %>' Width="30%" CommandName="image" CommandArgument='<%#Eval("ImageURL") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
