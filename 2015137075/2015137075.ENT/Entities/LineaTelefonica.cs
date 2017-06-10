using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class LineaTelefonica
    {
        public int LineaTelefonicaId { get; set; }
        public string Nombre { get; set; }

        //relaciones

        public List<Evaluacion> Evaluaciones { get; set; }
        public LineaTelefonica()
        {
            Evaluaciones = new List<Evaluacion>();
        }
    }
}
