using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Repositories.Interfaces
{
    public interface IIncidentRepository : IRepositoryBase<Incident>
    {
        Task<Incident> FindByIdAsync(int id);
    }
}
