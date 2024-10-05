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



            string codigoVoucher = txtCodigoVoucher.Text;

            VoucherNegocio voucherNegocio = new VoucherNegocio();
            Voucher voucher = voucherNegocio.ObtenerVoucher(codigoVoucher);

            if (voucher != null && voucher.FechaCanje == null)
            {
                // Guardamos el código de voucher en la sesión y redirigimos
                Session["CodigoVoucher"] = codigoVoucher;
                Response.Redirect("CanjeVoucher.aspx");
            }
            else
            {
                // Mensaje de error si el voucher no es válido o ya fue canjeado
                Response.Write("<script>alert('Voucher inválido o ya canjeado');</script>");
            }



        }
    }
}