using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }

        //relaciones

        public List<Provincia> Provincias { get; set; }

        public Departamento()
        {
            Provincias = new List<Provincia>();

        }
    }
}
