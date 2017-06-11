using _2015137075.ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly _2015137075DbContext _Context;
        public static readonly UnityOfWork Instance;

        //private static UnityOfWork _Instance;
        //private static readonly object _Lock = new object();

        public ICentroAtencionRepository CentroAtencions { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IContratoRepository Contratos { get; private set; }
        public IDepartamentoRepository Departamentos { get; private set; }
        public IDireccionRepository Direccions { get; private set; }
        public IDistritoRepository Distritos { get; private set; }
        public IEvaluacionRepository Evaluacion { get; private set; }
        public ILineaTelefonicaRepository LineaTelefonicas { get; private set; }
        public IPlanRepository Plans { get; private set; }
        public IProvinciaRepository Provincias { get; private set; }
        public ITrabajadorRepository Trabajadors { get; private set; }
        public IVentaRepository Ventas { get; private set; }

        public UnityOfWork()
        {
                
        }
        private UnityOfWork(_2015137075DbContext context)
        {
            //_Context = new _2015137075DbContext();
            _Context = context;

            CentroAtencions = new CentroAtencionRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Contratos = new ContratoRepository(_Context);
            Departamentos = new DepartamentoRepository(_Context);
            Direccions = new DireccionRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            Evaluacion = new EvaluacionRepository(_Context);
            LineaTelefonicas = new LineaTelefonicaRepository(_Context);
            Plans = new PlanRepository(_Context);
            Provincias = new ProvinciaRepository(_Context);
            Trabajadors = new TrabajadorRepository(_Context);
            Ventas = new VentaRepository(_Context);


        }


        //public static UnityOfWork Instance
       // {
         //   get
           // {
             //   lock (_Lock)
               // {
                 //   if (_Instance == null)
                   //     _Instance = new UnityOfWork();

 //               }

   //             return _Instance;
     //       }
       // }


        public void Dispose()
        {
            _Context.Dispose();  
        }

        public int SaveChanges()
        {
           return _Context.SaveChanges();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
