﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CVentas.aspx.cs" Inherits="GestionDeVentas.Consultas.CVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Consulta de Ventas</div>
</div>
    <asp:Label ID="LabelFiltrar" runat="server" Text="Filtrar"></asp:Label>
    <p>
    </p>
    <asp:DropDownList ID="DropDownListFiltro" runat="server">
        <asp:ListItem>Todos</asp:ListItem>
        <asp:ListItem>VentaId</asp:ListItem>
        <asp:ListItem>VendedorId</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:GridView ID="GridViewConsultaVenta" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="225px" Width="331px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:button runat="server" class="btn btn-info" text="Buscar" ID="ButtonBuscar" OnClick="ButtonBuscar_Click" />

<%--    <asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" Text="Buscar" />--%>
</asp:Content>
