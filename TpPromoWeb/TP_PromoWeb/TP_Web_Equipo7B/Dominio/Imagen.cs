using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public Imagen()
        {
            IDArticulo = 0;
            ImagenUrl = "";
        }
        

        public int ID { get; set; } 

        public int IDArticulo { get; set; }
        public string ImagenUrl { get; set; }





    }
}
