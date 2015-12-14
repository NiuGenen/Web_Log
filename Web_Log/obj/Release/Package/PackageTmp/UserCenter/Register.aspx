<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web_Log.UserCenter.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>用户注册中心</h1>
        <hr />
        <div>
            <div class="register_form">
                <asp:Label ID="LabelUserName" runat="server" Text="　用户名"></asp:Label>
                <asp:TextBox ID="TextBoxUserName" runat="server" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="请填写用户名" ControlToValidate="TextBoxUserName"></asp:RequiredFieldValidator>
                </div>
                <div class="register_error">
                    <asp:Label ID="LabelUserNameExists" runat="server" Text="此用户名已存在" Visible="False"></asp:Label>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="LabelPassWord" runat="server" Text="　　密码"></asp:Label>
                <asp:TextBox ID="TextBoxPassWord" runat="server" TextMode="Password" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="请填写密码" ControlToValidate="TextBoxPassWord"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="Label1" runat="server" Text="确认密码"></asp:Label>
                <asp:TextBox ID="TextBoxPassWordConfirm" runat="server" TextMode="Password" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:CompareValidator runat="server" ControlToCompare="TextBoxPassWordConfirm" ControlToValidate="TextBoxPassWord" Display="Dynamic" ErrorMessage="两次填写的密码不一致"></asp:CompareValidator>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="LabelSex" runat="server" Text="　　性别"></asp:Label>
                <div style="position: absolute; top: 5px; left: 76px;">
                    <asp:RadioButtonList ID="RadioButtonListSex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="register_error">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonListSex" ErrorMessage="请选择您的性别"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="LabelAge" runat="server" Text="　　年龄"></asp:Label>
                <asp:TextBox ID="TextBoxAge" runat="server" CssClass="register_textbox" TextMode="Number"></asp:TextBox>
                <div class="register_error">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAge" ErrorMessage="请填写您的年龄"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="register_form">
                <asp:Label ID="LabelEmail" runat="server" Text="　　邮箱"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="register_textbox"></asp:TextBox>
                <div class="register_error">
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="请正确填写您的邮箱" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="register_form">
                <div style="position: absolute; top: 8px; left: 51px; margin-top: 0px;">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="注册" OnClick="ButtonSubmit_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>

