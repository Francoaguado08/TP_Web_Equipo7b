using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VoucherNegocio
    {

        public Voucher ObtenerVoucher(string codigoVoucher)
        {
            Voucher voucher = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT * FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    voucher = new Voucher
                    {
                        CodigoVoucher = (string)datos.Lector["CodigoVoucher"],
                        FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime?)datos.Lector["FechaCanje"] : null
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (log, mostrar mensaje, etc.)
                throw new Exception("Error al obtener el voucher: " + ex.Message);

            }
            finally
            {
                datos.cerrarConexion();
            }

            return voucher;
        }

        public void CanjearVoucher(string codigoVoucher, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Vouchers SET FechaCanje = GETDATE(), IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", codigoVoucher);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
