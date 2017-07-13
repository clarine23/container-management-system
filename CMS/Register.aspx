<%@ Page Title="Register New User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CMS.Register" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <hr />
                <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblUserType" runat="server" Text="User Type" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtUserType" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-default" OnClick="btnRegister_Click"></asp:Button>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="col-md-offset-2 control-label" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

