using _2015137075.ENT;
using _2015137075.ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.Repositories
{
    public class CentroAtencionRepository : Repository<CentroAtencion>, ICentroAtencionRepository
    {
        private readonly _2015137075DbContext _Context;

     

        public CentroAtencionRepository(_2015137075DbContext context) : base(context)
        {
            _Context = context;
        }

        CentroAtencion ICentroAtencionRepository.Get(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
