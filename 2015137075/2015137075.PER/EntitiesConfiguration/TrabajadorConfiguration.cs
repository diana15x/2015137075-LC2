﻿using _2015137075.ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.EntitiesConfiguration
{
    public class TrabajadorConfiguration : EntityTypeConfiguration<Trabajador>

    {
        public TrabajadorConfiguration()
        {
            //Table Configurations
            ToTable("Trabajador");
            HasKey(a => a.TrabajadorId);
        }
    }
}
