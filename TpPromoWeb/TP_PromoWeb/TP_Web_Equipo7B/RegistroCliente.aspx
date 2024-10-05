<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="TP_Web_Equipo7B.RegistroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <title>Promo WEB - Registro de Cliente</title>

  
        <div>
            <h2>Registro de Cliente</h2>
            <p>Complete los siguientes datos para finalizar el canje.</p>

            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox><br />
            <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido"></asp:TextBox><br />
            <asp:TextBox ID="txtDocumento" runat="server" placeholder="DNI"></asp:TextBox><br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox><br />
            <asp:TextBox ID="txtDireccion" runat="server" placeholder="Dirección"></asp:TextBox><br />
            <asp:TextBox ID="txtCiudad" runat="server" placeholder="Ciudad"></asp:TextBox><br />
            <asp:TextBox ID="txtCP" runat="server" placeholder="Código Postal"></asp:TextBox><br />

            <asp:Button ID="btnRegistrar" runat="server" Text="Finalizar Registro" Onclick="btnRegistrar_Click" />
        </div>





</asp:Content>
