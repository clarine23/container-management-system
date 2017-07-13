<%@ Page Title="Export" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="CMS.Export" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <hr />
                <div class="form-group">
                    <asp:Label ID="lblYard" runat="server" Text="Yard" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dropYard" runat="server" CssClass="btn btn-info" AutoPostBack="true" OnSelectedIndexChanged="dropYard_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblGate" runat="server" Text="Gate" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dropGate" runat="server" CssClass="btn btn-info" AutoPostBack="true" OnSelectedIndexChanged="dropGate_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblContainer" runat="server" Text="Container" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dropContainer" runat="server" CssClass="btn btn-info" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCompany" runat="server" Text="Company" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDestination" runat="server" Text="Destination" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtDestination" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAdd_Click"></asp:Button>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="col-md-offset-2 control-label" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

