<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteOrdenes.aspx.cs" Inherits="ReporteOrdenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="">ORDER REPORT</asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvReporte" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="DateOrder" HeaderText="Date Order" />
                <asp:BoundField DataField="CustomerName" HeaderText="Customer" />
                <asp:BoundField DataField="VendorName" HeaderText="Vendor" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="ProductDesc" HeaderText="Product Description" />
                <asp:BoundField DataField="Quantities" HeaderText="Quantity" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

