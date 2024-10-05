using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo7B
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Documento = txtDocumento.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text,
                Ciudad = txtCiudad.Text,
                CP = int.Parse(txtCP.Text)
            };

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clienteNegocio.Registrar(cliente);

            Response.Write("<script>alert('Registro completado con éxito');</script>");
        }
   
    
    
    }
    
}