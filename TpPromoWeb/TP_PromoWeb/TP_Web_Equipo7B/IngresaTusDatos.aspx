<%@ Page Title="IngresaTusDatos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresaTusDatos.aspx.cs" Inherits="TP_Web_Equipo7B.IngresaTusDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Ingresa Tus Datos</h2>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" HeaderText="Por favor corrige los siguientes errores:" />

        <div class="form-group">
            <label for="txtDNI">DNI:</label>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" MaxLength="10" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="txtEmail" 
                ErrorMessage="El formato del correo es incorrecto" 
                ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" 
                CssClass="text-danger" />
        </div>
        <div class="form-group">
            <label for="txtDireccion">Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCiudad">Ciudad:</label>
            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCodigoPostal">Código Postal:</label>
            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>



        <div class="text-center mt-4">
            <asp:Button ID="btnParticipar" runat="server" Text="Participar!" CssClass="btn btn-primary" OnClick="btnParticipar_Click" />
        </div>
    </div>
</asp:Content>
