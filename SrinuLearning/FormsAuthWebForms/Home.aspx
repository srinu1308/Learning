<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FormsAuthWebForms.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 258px">
        <p style="height: 229px">I am Home&nbsp; </p>
        <br />
        <a href="Details.aspx">Details</a>
        <br />
        <a href="Update.aspx">Update</a>
    </div>
</asp:Content>
