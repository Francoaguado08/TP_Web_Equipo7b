<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo7B._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">




    <head>
        <title>Promo WEB - Ingreso de Voucher</title>
    </head>
    <body>
        
            <div class="container">
                <h2 class="text-center mt-5">Bienvenido a la Promo WEB</h2>
                <p class="text-center">Ingrese su código de voucher para canjear premios.</p>

                <div class="mb-3 d-flex justify-content-center">
                    <asp:TextBox ID="txtCodigoVoucher" runat="server" CssClass="form-control" placeholder="Ingrese su código" Style="max-width: 300px;"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnCanjear" runat="server" Text="Canjear" CssClass="btn btn-primary" OnClick="btnCanjear_Click" />
                </div>
            </div>
       
    </body>








</asp:Content>
