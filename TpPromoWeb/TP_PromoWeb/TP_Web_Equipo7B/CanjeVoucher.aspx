<%@ Page Title="CanjeVoucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CanjeVoucher.aspx.cs" Inherits="TP_Web_Equipo7B.CanjeVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <head>
        <title>Promo WEB - Canje de Premio</title>
    </head>
   
        
            <div>
                <h2>Canje su premio</h2>
                <p>Seleccione un premio de la lista:</p>

                <asp:DropDownList ID="ddlPremios" runat="server"></asp:DropDownList>
                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar Premio" Onclick="btnSeleccionar_Click" />
            </div>

    



</asp:Content>
