using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Venta
    {
        public int VentaId { get; set; }
        public string Nombre { get; set; }

        //relaciones
        
        public int CentroAtencionId { get; set; }
        public CentroAtencion CentroAtencion { get; set; }

        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }

        public int EvaluacionId { get; set; }
        public Evaluacion Evaluacion { get; set; }


    }
}
