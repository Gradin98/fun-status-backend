using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Repositories.Interfaces
{
    public interface ITrackerRepository : IRepositoryBase<Tracker>
    {
        Task<Tracker> FindByIdAsyncWithData(int id);
        Task<IQueryable<Tracker>> FindALlAsyncWithData();
    }
}
