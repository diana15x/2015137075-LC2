using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        public string Nombre { get; set; }

        //relaciones

        public List<Venta> Ventas { get; set; }

        public Contrato()
        {
            Ventas = new List<Venta>();
        }

    }
}
