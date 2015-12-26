<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Web_Log.UserCenter.Manage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1 runat="server" id="ManageUserName">用户名</h1>
            <asp:Button runat="server" Visible="false" ID="AddAttentionButton" Text="+关注" OnClick="AddAttentionButton_Click" CssClass="manage_addattentionbutton" />
            <asp:Button runat="server" ID="LeftMessage" Text="进入留言板" OnClick="LeftMessage_Click" CssClass="manage_leftmessage" />
            <asp:Button runat="server" ID="ChangeInfo" Text="修改个人信息" OnClick="ChangeInfo_Click" CssClass="manage_changeinfo"/>
        </div>
        <div class="manage_article_block" runat="server" id="ArticleBlock">
            <div>
                <hr />
                <h1>文章列表</h1>
                <asp:Button runat="server" ID="NewArticle" Text="新建文章" OnClick="NewArticle_Click" CssClass="manage_newarticle_button" />
            </div>
            <hr />
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
                                <asp:LinkButton runat="server" ID="ManageTitle" CommandName="Title" CommandArgument='<%#Eval("ID") %>' CssClass="manage_linkbutton"><%#Eval("Title") %></asp:LinkButton>
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
        <div class="manage_album_block" runat="server" id="AlbumBlock">
            <div>
                <h1>相册</h1>
                <asp:FileUpload runat="server" ID="GetImage" CssClass="manage_getimage" />
                <asp:Button runat="server" ID="AddImage" Text="上传" OnClick="Add_Image_Click" CssClass="manage_addimage" />
                <hr />
            </div>
            <div>
                <asp:DataList runat="server" ID="ManageAlbum" RepeatColumns="3" OnItemCommand="Manage_Album_ItemCommand">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ImageUrl='<%#Eval("ImageURL") %>' CssClass="manage_image" CommandName="image" CommandArgument='<%#Eval("ImageURL") %>'/>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="manage_friend_block" id="FriendBlock" runat="server">
            <div>
                <h3>- 关注列表 - </h3>
                <hr />
                <asp:Repeater runat="server" ID="ManageFriend" OnItemCommand="ManageFriend_ItemCommand">
                    <HeaderTemplate>
                        <table class="manage_frinedlist">
                            <tr>
                                <th class="manage_frinedlist_header">关注</th>
                                <th class="manage_frinedlist_header">在线</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="manage_friendlist_username_block">
                                <asp:LinkButton runat="server" ID="ManageFriendName" Text='<%#Eval("FriendName") %>' CommandName="friend" CommandArgument='<%#Eval("FriendName") %>' CssClass="manage_friendlist_username_linkbutton"></asp:LinkButton>
                            </td>
                            <td class="manage_friendlist_online_block">
                                <asp:Label runat="server" Text='<%#Eval("OnLine") %>' CssClass="manage_friendlist_online_label"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div>
            </div>
        </div>
    </div>
</asp:Content>
