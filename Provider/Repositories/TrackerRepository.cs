using Domain;
using Domain.Models;
using Provider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Repositories
{
    public class TrackerRepository : RepositoryBase<Tracker>, ITrackerRepository
    {
        public TrackerRepository(FunDbContext dbContext) : base(dbContext) { }

        public async Task<Tracker> FindByIdAsyncWithData(int id)
        {
            var tracker = await DbContext.Set<Tracker>().FindAsync(id);
            DbContext.Entry(tracker).Reference(x => x.Status).Load();
            
            return tracker;
        }

        Task<IQueryable<Tracker>> ITrackerRepository.FindALlAsyncWithData()
        {
            throw new NotImplementedException();
        }
    }
}
