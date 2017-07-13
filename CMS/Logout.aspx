<%@ Page Title="Log out" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="CMS.Logout" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>    
    <div class="form-group">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="col-md-offset-2 control-label" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
