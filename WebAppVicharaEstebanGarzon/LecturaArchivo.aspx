<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LecturaArchivo.aspx.cs" Inherits="LecturaArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="">Load File to Database</asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnCargar" runat="server" Text="Load" onclick="btnCargar_Click" />
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

