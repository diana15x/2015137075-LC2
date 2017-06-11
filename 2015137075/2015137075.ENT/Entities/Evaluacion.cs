using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Evaluacion
    {
        public int EvaluacionId { get; set; }
        public string Nombre { get; set; }

        //relaciones

        public int LineaTelefonicaId { get; set; }
        public LineaTelefonica LineaTelefonica { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public int TrabajadorId { get; set; }
        public Trabajador Trabajador { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente{ get; set; }



    }
}
