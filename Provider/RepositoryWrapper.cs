using Domain;
using Provider.Repositories;
using Provider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FunDbContext _dbContext;
        private IUserRepository _user;
        private ITrackerRepository _tracker;
        private IStatusRepository _status;
        private IPingGraphRepository _pingGraph;
        private IIncidentRepository _incident;
        private IGraphPointRepository _graphPoint;

        public RepositoryWrapper(FunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_dbContext);

                return _user;
            }
        }

        public ITrackerRepository Tracker
        {
            get
            {
                if (_tracker == null)
                    _tracker = new TrackerRepository(_dbContext);

                return _tracker;
            }
        }


        public IStatusRepository Status
        {
            get
            {
                if (_status == null)
                    _status = new StatusRepository(_dbContext);

                return _status;
            }
        }


        public IPingGraphRepository PingGraph
        {
            get
            {
                if (_pingGraph == null)
                    _pingGraph = new PingGraphRepository(_dbContext);

                return _pingGraph;
            }
        }


        public IIncidentRepository Incident
        {
            get
            {
                if (_incident == null)
                    _incident = new IncidentRepository(_dbContext);

                return _incident;
            }
        }


        public IGraphPointRepository GraphPoint
        {
            get
            {
                if (_graphPoint == null)
                    _graphPoint = new GraphPointRepository(_dbContext);

                return _graphPoint;
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
