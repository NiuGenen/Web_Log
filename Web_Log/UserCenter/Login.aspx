<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Log.UserCenter.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>- 登录你的博客 -</h1>
            <hr />
        </div>
        <div>
            <div class="login_form">
                <asp:Label ID="LabelLoginUserName" runat="server" Text="用户名"></asp:Label>
                <asp:TextBox ID="TextBoxLoginUserName" runat="server" CssClass="login_textbox"></asp:TextBox>
                <div class="login_error">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLoginUserName" ErrorMessage="请填写用户名"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="login_form">
                <asp:Label ID="LabelLoginPassWord" runat="server" Text="　密码"></asp:Label>
                <asp:TextBox ID="TextBoxLoginPassWord" runat="server" CssClass="login_textbox"></asp:TextBox>
                <div class="login_error">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLoginPassWord" ErrorMessage="请填写密码"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="login_form">
                <div style="position:relative; left:60px;">
                    <asp:RadioButton ID="RadioButtonRememberMe" runat="server" Text="记住我?" />
                </div>
            </div>
            <div class="login_form">
                <div class="login_login">
                    <asp:Button ID="ButtonLoginSubmit" runat="server" BorderWidth="1px" BorderColor="#cccccc" Text="登录" OnClick="ButtonLoginSubmit_Click" />
                </div>
            </div>
            <div class="login_register">
                <h2>- 没有账户 -</h2>
                <a runat="server" href="~/UserCenter/Register.aspx">注册</a>您的账户
            </div>
            <br />
        </div>
    </div>
</asp:Content>
