﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT.IRepositories
{
    public interface IContratoRepository : IRepository<Contrato>
    {
        Contrato Get(int? id);
    }
}
