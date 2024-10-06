<%@ Page Title="CanjeVoucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CanjeVoucher.aspx.cs" Inherits="TP_Web_Equipo7B.CanjeVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Canje su premio</h2>
        <p>Seleccione un premio de la lista:</p>

        <asp:DropDownList ID="ddlPremios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPremios_SelectedIndexChanged"></asp:DropDownList>
        <asp:Image ID="imgPremio" runat="server" Width="300px" Height="300px" />

        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar Premio" Onclick="btnSeleccionar_Click" />
    </div>

</asp:Content>
