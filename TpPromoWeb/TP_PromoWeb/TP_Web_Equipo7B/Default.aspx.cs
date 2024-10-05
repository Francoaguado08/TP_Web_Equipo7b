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


            string codigoVoucher = txtCodigoVoucher.Text.Trim();
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            Voucher voucher = voucherNegocio.ObtenerVoucher(codigoVoucher);

            if (voucher == null)
            {
                // El voucher no existe o es incorrecto
                // Muestra un mensaje de error al usuario
                lblMensaje.Text = "El código de voucher ingresado no es válido. Por favor, verifique e intente nuevamente.";
                lblMensaje.CssClass = "text-danger"; // Agrega una clase para estilizar el mensaje
            }
            else
            {
                // El voucher es válido, procede con el canje
                // Aquí podrías agregar la lógica para registrar el canje y mostrar un mensaje de éxito
                lblMensaje.Text = "¡Canje exitoso! Has canjeado el voucher.";
                lblMensaje.CssClass = "text-success"; // Agrega una clase para estilizar el mensaje
            }
        }



        
    }
}