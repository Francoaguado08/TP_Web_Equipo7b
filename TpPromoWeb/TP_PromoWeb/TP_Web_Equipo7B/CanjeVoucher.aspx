<%@ Page Title="CanjeVoucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CanjeVoucher.aspx.cs" Inherits="TP_Web_Equipo7B.CanjeVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Elegí tu premio</h2>
        <div class="row">
           <asp:Repeater ID="rptProductos" runat="server">
    <ItemTemplate>
        <div class="col-md-4">
            <div class="card">
                <!-- Carrusel de imágenes para el producto -->
                <div id="carousel<%# Eval("ID") %>" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                            <ItemTemplate>
                                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                    <img class="d-block w-100" src='<%# Container.DataItem %>' alt="Imagen del producto" style="height: 200px;">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- Controles del carrusel -->
                    <a class="carousel-control-prev" href="#carousel<%# Eval("Id") %>" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carousel<%# Eval("Id") %>" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>

                <!-- Información del producto -->
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <asp:Button ID="btnSeleccionar" runat="server" CommandArgument='<%# Eval("Id") %>' Text="¡Quiero este!" CssClass="btn btn-primary" OnClick="btnSeleccionar_Click" />
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
        </div>
    </div>
</asp:Content>
