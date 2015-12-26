<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeftMessage.aspx.cs" Inherits="Web_Log.UserCenter.LeftMessage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1 runat="server" id="LeftMessageTitle">标题</h1>
            <hr />
        </div>
        <div runat="server" id="LeftMessageBolck">
            <div class="leftmessage_block">
                <asp:Repeater runat="server" ID="LeftMessageList" OnItemCommand="LeftMessageList_ItemCommand">
                    <HeaderTemplate>
                        <table class="leftmessage_messagetable">
                            <tr>
                                <th class="leftmessage_messagetable_header">用户名</th>
                                <th class="leftmessage_messagetable_header">留言内容</th>
                                <th class="leftmessage_messagetable_header">时间</th>
                                <th class="leftmessage_messagetable_header">回复</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="leftmessage_messagetable_username">
                                <asp:LinkButton runat="server" ID="LeftMessageUser" CommandName="user" CommandArgument='<%#Eval("LeftUser") %>' CssClass="leftmessage_messagetable_linkbutton"><%#Eval("LeftUser") %></asp:LinkButton>
                            </td>
                            <td class="leftmessage_messagetable_content">
                                <asp:Label runat="server" ID="LeftMessageContent"><%#Eval("LeftContent") %></asp:Label>
                            </td>
                            <td class="leftmessage_messagetable_time">
                                <asp:Label runat="server" ID="LeftMessageTime"><%#Eval("LeftTime") %></asp:Label>
                            </td>
                            <td class="leftmessage_messagetable_reply">
                                <asp:LinkButton runat="server" ID="LeftMessageReply" CommandName="reply" CommandArgument='<%#Eval("LeftUser") %>' CssClass="leftmessage_messagetable_linkbutton">[回复]</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="leftmessage_block">
                <hr />
                <asp:Button runat="server" ID="LeftMessageButton" Text="留言" OnClick="LeftMessageButton_Click" CssClass="leftmessage_leftmessafebutton" />
                <hr runat="server" id="LeftMessageBoxUp" visible="false" />
                <div>
                    <asp:TextBox runat="server" ID="LeftMessageTextBox" TextMode="MultiLine" Rows="5" Visible="false" CssClass="leftmessage_leftmessagetextbox"></asp:TextBox>
                </div>
                <hr runat="server" id="LeftMessageBoxDown" visible="false" />
                <div>
                    <asp:Button runat="server" ID="LeftMessageConfirm" Text="发表" Visible="false" OnClick="LeftMessageConfirm_Click" CssClass="leftmessage_leftmessageconfirm" />
                    <asp:Button runat="server" ID="LeftMessafeCancle" Text="取消" Visible="false" OnClick="LeftMessafeCancle_Click" CssClass="leftmessage_leftmessagecancel" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
