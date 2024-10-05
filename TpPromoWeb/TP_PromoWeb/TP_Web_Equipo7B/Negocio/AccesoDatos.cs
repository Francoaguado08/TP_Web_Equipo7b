using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        

        //Centralizamos la cadena de conexion.
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"); 
            comando = new SqlCommand(); // por si quiero hacer una consulta/accion contra la BD
        }


        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();//ExecuteReader(): Ejecuta la consulta que pusiste con setearConsulta y guarda los datos en el lector, que es como una tabla de resultados.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion() //Este método es para ejecutar acciones en la base de datos que no devuelven datos, como INSERT, UPDATE, o DELETE.
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conexion.Close(); }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public int ejecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                int cantidad = (int)comando.ExecuteScalar();
                return cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
