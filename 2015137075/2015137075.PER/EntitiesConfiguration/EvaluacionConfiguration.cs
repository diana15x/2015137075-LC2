﻿using _2015137075.ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.EntitiesConfiguration
{
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {
            //Table Configurations
            ToTable("Evaluacion");
            HasKey(a => a.EvaluacionId);

            HasRequired(c => c.LineaTelefonica)
              .WithMany(c => c.Evaluaciones)
               ;

            HasRequired(c => c.Plan)
              .WithMany(c => c.Evaluaciones)
               ;

            HasRequired(c => c.Trabajador)
              .WithMany(c => c.Evaluaciones)
               ;
            HasRequired(c => c.Cliente)
              .WithMany(c => c.Evaluaciones)
               ;
        }
    }
}
