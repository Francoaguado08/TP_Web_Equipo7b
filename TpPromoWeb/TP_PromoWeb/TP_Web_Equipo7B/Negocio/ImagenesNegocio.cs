using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenesNegocio
    {


        
        public List<string>listar(int idArticulo)
        {
            List<string> lista = new List<string>(); 
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Consulta para obtener las imagenes relacionadas con el articulo.
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarLectura();

                //Recorremos el lector para agregar cada url de imagen a la lista...
                while (datos.Lector.Read())
                {
                    lista.Add((string)datos.Lector["ImagenUrl"]);
                }

                return lista;   

            }


            catch (Exception ex)
            {

                throw ex;

            }
            finally { datos.cerrarConexion();}



        }


        // HACER LOS METODOS  PARA AGREGAR, MODIFICAR Y ELIMIANAR!!








        





    }
}
