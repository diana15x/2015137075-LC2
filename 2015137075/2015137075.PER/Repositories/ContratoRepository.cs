﻿using _2015137075.ENT;
using _2015137075.ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.PER.Repositories
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        private readonly _2015137075DbContext _Context;

        public ContratoRepository(_2015137075DbContext context): base(context)
        {
            _Context = context;
        }

        
    }
}
