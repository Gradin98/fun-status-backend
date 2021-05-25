using Domain;
using Domain.Models;
using Provider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Repositories
{
    public class PingGraphRepository : RepositoryBase<PingGraph>, IPingGraphRepository
    {
        public PingGraphRepository(FunDbContext dbContext) : base (dbContext) { }
    }
}
