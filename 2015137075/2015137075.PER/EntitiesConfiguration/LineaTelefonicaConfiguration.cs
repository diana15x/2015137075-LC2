using _2015137075.ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.EntitiesConfiguration
{
    public class LineaTelefonicaConfiguration : EntityTypeConfiguration<LineaTelefonica>
    {
        public LineaTelefonicaConfiguration()
        {
            //Table Configurations
            ToTable("LineaTelefonica");
            HasKey(a => a.LineaTelefonicaId);
        }
    }
}
