using Domain;
using Domain.Models;
using Provider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Repositories
{
    public class GraphPointRepository : RepositoryBase<GraphPoint>, IGraphPointRepository
    {
        public GraphPointRepository(FunDbContext dbContext) : base(dbContext) { }
    }
}
