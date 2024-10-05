using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //(0) Agrego esto para la conexion.
using Dominio;//(1) Agrego
using Negocio;//(2) Agrego
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class ArticuloNegocio
    {





        public List<Articulo> listar()
        {

            List<Articulo> lista = new List<Articulo>(); //Se crea una lista vacía de Articulo que se irá llenando con los datos de la base de datos.
            AccesoDatos datos = new AccesoDatos(); // Se crea una instancia de la clase AccesoDatos, que maneja la conexión y ejecución de consultas a la base de datos.

            try
            {

                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo");
                datos.ejecutarLectura();
                
                
                //Voy a leer, si es que pudo me posiciona el puntero en la siguiente posicion;
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    //Aca procedo a evaluar si tiene nulos  o no.
                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }
                    else
                    {
                        aux.UrlImagen = "";
                    }
                    //-------------------------------------------------
                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "";
                    }

                    //---------------------------------------------------

                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    }
                    else
                    {
                        aux.Categoria.Descripcion = "";
                    }

                    lista.Add(aux);// Agrego finalmente a la lista este articulo.     

                }

                return lista; //Cuando termino de leer que me devuelva la lista.





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




         
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos  =  new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria ) VALUES (@Codigo, @Nombre, @Descripcion,@Precio, @IdMarca, @IdCategoria)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdMarca", nuevo.Marca.ID);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.ID);
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
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Articulos WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}


        }
        public void modificar(Articulo modificar) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio, Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametro("@Id", modificar.ID);
                datos.setearParametro("@Codigo", modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@Precio", modificar.Precio);


                datos.cerrarConexion();
                datos.ejecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }



     





        public void modificarCategoriaArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET IdCategoria = @IdCategoria WHERE Id = @IdArticulo");
                datos.setearParametro("@IdArticulo", modificar.ID);
                datos.setearParametro("@IdCategoria", modificar.Categoria.ID);
                datos.cerrarConexion();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarMarcaArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET IdMarca = @IdMarca WHERE Id = @IdArticulo");
                datos.setearParametro("@IdArticulo", modificar.ID);
                datos.setearParametro("@IdMarca", modificar.Marca.ID);
                datos.cerrarConexion();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarImagenArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE Id = (SELECT TOP 1 Id FROM IMAGENES WHERE IdArticulo = @IdA)");
                datos.setearParametro("@IdA", modificar.ID);
                datos.setearParametro("@ImagenUrl", modificar.UrlImagen);
                datos.cerrarConexion();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void agregarImagen(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo articulo = new Articulo();
            articulo = listar().Last();

            try
            {
                int idArticulo = articulo.ID;
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@ImagenUrl", nuevoArticulo.UrlImagen);
                datos.cerrarConexion();
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
