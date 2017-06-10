﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }

        public string Nombre { get; set; }

        // relaciones 

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public List<Distrito> Distritos { get; set; }

        public Provincia()
        {
            Distritos = new List<Distrito>();

        }

    }
}
