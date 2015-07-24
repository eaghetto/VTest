<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Welcome to VICHARA TEST!
    </h2>
    <p>
        To upload the information to the database 
        <asp:LinkButton ID="lkbuttonDB" runat="server" onclick="lkbuttonDB_Click">Upload DB</asp:LinkButton>
    </p>
    <p>
        Display reports:
        <br />
        <asp:LinkButton ID="lkbuttonRep" runat="server" onclick="lkbuttonRep_Click">See Report Orders</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lkbuttonRep2" runat="server" onclick="lkbuttonRep2_Click">See Report Customers</asp:LinkButton>
    </p>
</asp:Content>

