<%@ Page Title="Container Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCon.aspx.cs" Inherits="CMS.ManageCon" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">
            <p><a href ="Import" class="btn btn-info">Import</a></p>
            <p><a href ="Export" class="btn btn-info">Export</a></p>
            <p><a href ="UpdateCon" class="btn btn-primary">Update Container Status</a></p>
        </div>
        <div class="form-group">
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="col-md-offset-2 control-label" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
