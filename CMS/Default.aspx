<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Market Line</h1>
        <p class="lead">Market Line is the global container division and the largest operating unit of the A.P. Moller - 
            Market Group, a Danish business conglomerate. It is the world's largets container shipping company having cutomers 
            through 374 offices in 116 countries. The company was founded in 1928.
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Container Management System</h2>
            <p>
                Container Management System (CSM) is used to cater to manage the containers. It is a solution that can reduces
                overall supply chain costs and an efficient way to manage logistics.
            </p>
            <% if ((string)Session["Username"] == null) { %>
                <p><a href ="Login" class="btn btn-primary btn-lg">Log in</a></p>
            <% } %>            
        </div>        
    </div>
</asp:Content>
