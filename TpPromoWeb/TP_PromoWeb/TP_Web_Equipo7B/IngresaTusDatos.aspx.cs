using System;
using System.Web.UI;

namespace TP_Web_Equipo7B
{
    public partial class IngresaTusDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Obtener los datos ingresados
                string dni = txtDNI.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string direccion = txtDireccion.Text;
                string ciudad = txtCiudad.Text;
                string codigoPostal = txtCodigoPostal.Text;

               
              
                Response.Redirect("GraciasPorParticipar.aspx");
            }
        }
    }
}
