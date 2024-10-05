using System;
using System.Collections.Generic;
using System.ComponentModel; //esto es para poder usar el display.
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
       //Constructores:
       
        public Articulo() 
        {
            ID = 0;
            Codigo = "0";
            Nombre = ""; 
            Descripcion = "";
            Precio = 0;
            Categoria = new Categoria();
            Marca = new Marca();
            UrlImagen = "";

         }
        
        
        public Articulo(string codigo,string nombre, string descripcion, decimal precio, Categoria categoria, Marca marca, string urlImagen)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
            Marca = marca;
            UrlImagen = urlImagen;


        }



        
          

        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }
        public string UrlImagen { get; set; }








    }
}
