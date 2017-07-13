<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateCon.aspx.cs" Inherits="CMS.UpdateCon" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <hr />
                <div class="form-group">
                    <asp:Label ID="lblContainer" runat="server" Text="Container" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dropContainer" runat="server" CssClass="btn btn-info"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCompany" runat="server" Text="" CssClass="col-md-2 control-label"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblLocation" runat="server" Text="" CssClass="col-md-2 control-label"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dropStatus" runat="server" CssClass="btn btn-info"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" OnClick="btnUpdate_Click"></asp:Button>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="col-md-offset-2 control-label" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
