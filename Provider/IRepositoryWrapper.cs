using Provider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ITrackerRepository Tracker { get; }
        IStatusRepository Status { get; }
        IPingGraphRepository PingGraph { get; }
        IIncidentRepository Incident { get; }
        IGraphPointRepository GraphPoint { get; }
        Task Save();
    }
}
