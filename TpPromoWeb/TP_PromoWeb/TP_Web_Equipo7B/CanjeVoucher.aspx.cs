﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo7B
{
    public partial class CanjeVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargamos los premios solo la primera vez que se carga la página
                CargarPremios();
            }
        }



        private void CargarPremios()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<Articulo> articulos = articuloNegocio.listar();

            ddlPremios.DataSource = articulos;
            ddlPremios.DataTextField = "Nombre";
            ddlPremios.DataValueField = "Id";
            ddlPremios.DataBind();
        }


        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

            string codigoVoucher = Session["CodigoVoucher"] as string;

            if (!string.IsNullOrEmpty(codigoVoucher))
            {
                int idArticuloSeleccionado = int.Parse(ddlPremios.SelectedValue);

                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.CanjearVoucher(codigoVoucher, idArticuloSeleccionado);

                Response.Redirect("RegistroCliente.aspx");
            }
            else
            {
                Response.Write("<script>alert('Error: No se encontró el código del voucher');</script>");
            }


        }
    }
}