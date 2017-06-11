using _2015137075.ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.EntitiesConfiguration
{
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            //Table Configurations
            ToTable("Distrito");
            HasKey(a => a.DistritoId);

            HasRequired(c => c.Provincia)
                .WithMany(c => c.Distritos)
                .HasForeignKey(c => c.ProvinciaId);
        }
    }
}
