using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class CentroAtencion
    {
        public int CentroDeAtencionId { get; set; }
        public string Nombre { get; set; }

        //Relaciones

        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }

        public List<Venta> Ventas { get; set; }

        public CentroAtencion()
        {
            Ventas = new List<Venta>();
        }


    }
}
