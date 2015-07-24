<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteCompradores.aspx.cs" Inherits="ReporteCompradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="">CUSTOMER REPORT</asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvReporte" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CustomerName" HeaderText="Customer" />
                <asp:BoundField DataField="Quantities" HeaderText="Quantity Orders" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

