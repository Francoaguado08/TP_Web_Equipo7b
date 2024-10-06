using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo7B
{
    public partial class CanjeVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar productos e imágenes solo la primera vez que se carga la página
                CargarProductosConImagenes();
            }
        }

        private void CargarProductosConImagenes()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<Articulo> articulos = articuloNegocio.listar();

            // Filtrar solo 3 artículos únicos por su nombre o categoría
            var articulosUnicos = articulos
                .GroupBy(a => a.Nombre) // Agrupa por nombre o cualquier otra propiedad
                .Select(g => g.First())
                .Take(3) // Tomamos solo 3 artículos únicos
                .ToList();

            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

            // Cargar las imágenes de cada producto
            foreach (Articulo articulo in articulosUnicos)
            {
                articulo.Imagenes = imagenesNegocio.listar(articulo.ID);
            }

            // Asignamos los productos al Repeater
            rptProductos.DataSource = articulosUnicos;
            rptProductos.DataBind();
        }



        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // Obtener el código del voucher de la sesión
            string codigoVoucher = Session["CodigoVoucher"] as string;

            if (!string.IsNullOrEmpty(codigoVoucher))
            {
                // Obtener el ID del producto seleccionado del CommandArgument del botón
                Button btnSeleccionar = (Button)sender;
                int idArticuloSeleccionado = int.Parse(btnSeleccionar.CommandArgument);

                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.CanjearVoucher(codigoVoucher, idArticuloSeleccionado);

                // Redirigir a la página de registro de cliente
                Response.Redirect("RegistroCliente.aspx");
            }
            else
            {
                // Mostrar un mensaje de error si no se encuentra el código del voucher
                Response.Write("<script>alert('Error: No se encontró el código del voucher');</script>");
            }
        }
    }
}
