using _2015137075.ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER
{
    public class _2015137075DbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<LineaTelefonica> LineasTelefonica { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
