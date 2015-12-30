<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfoChange.aspx.cs" Inherits="Web_Log.UserCenter.UserInfoChange" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1 runat="server" id="userinfochangetitle">用户信息修改</h1>
        <hr />
        <div>
            <div class="register_form">
                <asp:Label ID="OldPassWord" runat="server" Text="　原密码"></asp:Label>
                <asp:TextBox ID="TextBoxOldPassWord" runat="server" TextMode="Password" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="请填写原密码" ControlToValidate="TextBoxChangePassWord"></asp:RequiredFieldValidator>
                </div>
                <div class="register_error">
                    <asp:Label ID="LabelOlePassWordWrong" runat="server" Text="密码错误" Visible="False"></asp:Label>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="ChangePassWord" runat="server" Text="　新密码"></asp:Label>
                <asp:TextBox ID="TextBoxChangePassWord" runat="server" TextMode="Password" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="请填写新密码" ControlToValidate="TextBoxChangePassWord"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="ChangePassWordConfirm" runat="server" Text="确认密码"></asp:Label>
                <asp:TextBox ID="TextBoxChangePassWordConfirm" runat="server" TextMode="Password" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:CompareValidator runat="server" ControlToCompare="TextBoxChangePassWordConfirm" ControlToValidate="TextBoxChangePassWord" Display="Dynamic" ErrorMessage="两次填写的密码不一致"></asp:CompareValidator>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="ChangeLabelSex" runat="server" Text="　　性别"></asp:Label>
                <div style="position: absolute; top: 5px; left: 76px;">
                    <asp:RadioButtonList ID="RadioButtonListChangeSex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="ChangeLabelAge" runat="server" Text="　　年龄"></asp:Label>
                <asp:TextBox ID="TextBoxChangeAge" runat="server" CssClass="register_textbox" TextMode="Number"></asp:TextBox>
            </div>
            <div class="register_form">
                <asp:Label ID="ChangeLabelEmail" runat="server" Text="　　邮箱"></asp:Label>
                <asp:TextBox ID="TextBoxChangeEmail" runat="server" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxChangeEmail" ErrorMessage="请正确填写您的邮箱" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="register_form">
                <div style="position: absolute; top: 8px; left: 51px; margin-top: 0px;">
                    <asp:Button ID="ButtonSubmitChange" runat="server" Text="提交" OnClick="ButtonSubmitChange_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>