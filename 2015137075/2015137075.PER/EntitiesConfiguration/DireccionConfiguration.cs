using _2015137075.ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.EntitiesConfiguration
{
    public class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            //Table Configurations
            ToTable("Direccion");
            HasKey(a => a.DireccionId);

            //Relations Configuration

            HasRequired(c => c.Distrito)
              .WithMany(c => c.Direcciones);
        }
    }
}
