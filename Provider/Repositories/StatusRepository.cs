using Domain;
using Domain.Models;
using Provider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Repositories
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(FunDbContext dbContext) : base(dbContext) { }
    }
}
