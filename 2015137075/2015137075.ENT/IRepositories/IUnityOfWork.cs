using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        ICentroAtencionRepository CentroAtencions { get; }
        IClienteRepository Clientes { get; }
        IContratoRepository Contratos { get; }
        IDepartamentoRepository Departamentos { get; }
        IDireccionRepository Direccions { get; }
        IDistritoRepository Distritos { get; }
        IEvaluacionRepository Evaluacion { get; }
        ILineaTelefonicaRepository LineaTelefonicas { get; }
        IPlanRepository Plans { get; }
        IProvinciaRepository Provincias { get; }
        ITrabajadorRepository Trabajadors { get; }
        IVentaRepository Ventas { get; }

        int SaveChanges();
        void StateModified(CentroAtencion centroAtencion);
        void StateModified(Cliente cliente);
        void StateModified(Contrato contrato);
        void StateModified(Departamento departamento);
        void StateModified(Direccion direccion);
        void StateModified(Distrito distrito);
    }
}
