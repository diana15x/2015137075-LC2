using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Nombre { get; set; }

        //relaciones

        public List<Evaluacion> Evaluaciones { get; set; }
        public Plan()
        {
            Evaluaciones = new List<Evaluacion>();
        }

    }
}
