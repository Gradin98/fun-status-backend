using Domain;
using Domain.Models;
using Provider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Repositories
{
    public class IncidentRepository : RepositoryBase<Incident>, IIncidentRepository
    {
        public IncidentRepository(FunDbContext dbContext) : base(dbContext){ }

        public async Task<Incident> FindByIdAsync(int id)
        {
            var incident = await DbContext.Set<Incident>().FindAsync(id);
            DbContext.Entry(incident).Reference(x => x.Status).Load();
            DbContext.Entry(incident).Reference(x => x.Tracker).Load();

            return incident;
        }
    }
}
