<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web_Log.Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <div>
                <asp:TextBox runat="server" ID="EditTitle" OnTextChanged="Edit_Title_TextChanged" CssClass="edit_title"></asp:TextBox>
            </div>
            <div class="edit_save">
                <asp:Button runat="server" Text="保存" CssClass="edit_save_button" OnClick="Save_Click" />
            </div>
            <hr />
        </div>
        <div>
            <div>
                <asp:TextBox runat="server" ID="EditContent" TextMode="MultiLine" CssClass="edit_text_content" OnTextChanged="editcontent_TextChanged"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
