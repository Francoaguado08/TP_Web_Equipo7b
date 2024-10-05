using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {

        public string CodigoVoucher { get; set; }
        public Cliente Cliente { get; set; } // Relación con el cliente
        public DateTime? FechaCanje { get; set; } // Fecha cuando el voucher fue canjeado
        public Articulo Articulo { get; set; } // Premio seleccionado


    }
}
