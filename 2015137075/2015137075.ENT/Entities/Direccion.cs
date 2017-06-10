using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Direccion
    {
        public int DireccionId { get; set; }

        public string Descripcion { get; set; }

        //relaciones

        public int DistritoId { get; set; }
        public Distrito Distrito { get; set; }

        public List<CentroAtencion> CentrosAtencions { get; set; }

        public Direccion()
        {
            CentrosAtencions = new List<CentroAtencion>();

        }
    }
}
