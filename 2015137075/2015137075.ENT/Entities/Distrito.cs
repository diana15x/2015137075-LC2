using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Distrito
    {
        public int DistritoId { get; set; }

        public string Nombre { get; set; }

        //relaciones

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

        public List<Direccion> Direcciones { get; set; }
        public Distrito()
        {
            Direcciones = new List<Direccion>();
        }
    }
}
