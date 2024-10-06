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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCanjear_Click(object sender, EventArgs e)
        {
            string codigoVoucher = txtCodigoVoucher.Text.Trim(); // Obtiene el código de voucher ingresado
            VoucherNegocio voucherNegocio = new VoucherNegocio(); // Instancia la capa de negocio
            Voucher voucher = voucherNegocio.ObtenerVoucher(codigoVoucher); // Llama al método que busca el voucher

            if (voucher == null)
            {
                // El voucher no existe o es incorrecto
                lblMensaje.Text = "El código de voucher ingresado no es válido. Por favor, verifique e intente nuevamente.";
                lblMensaje.CssClass = "text-danger"; // Muestra un mensaje de error estilizado
            }
            else
            {
                // Verifica si el voucher ya fue canjeado
                if (voucher.FechaCanje == null)
                {
                    // El voucher no ha sido canjeado, permite el canje
                  /*  lblMensaje.Text = "¡Canje exitoso! Has canjeado el voucher.";
                    lblMensaje.CssClass = "text-success"; // Mensaje de éxito
                    
                   // Aquí puedes agregar la lógica para registrar el canje, como actualizar la FechaCanje
                  */

                    Response.Redirect("CanjeVoucher.aspx");
                   
                }
                else
                {
                    // El voucher ya fue canjeado previamente
                    lblMensaje.Text = "Este código de voucher ya ha sido utilizado.";
                    lblMensaje.CssClass = "text-danger"; // Mensaje de error estilizado
                }
            }
        }





    }
}