using _2015137075.ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.EntitiesConfiguration
{
    public class CentroAtencionConfiguration : EntityTypeConfiguration<CentroAtencion>
    {
        public CentroAtencionConfiguration()
        {
            //Table Configurations
            ToTable("CentroAtencion");
            HasKey(a => a.CentroAtencionId);

            //Relations Configuration
            HasRequired(c => c.Direccion)
               .WithMany(c => c.CentrosAtencions)
               .HasForeignKey(c => c.DireccionId);
        }
    }
}
