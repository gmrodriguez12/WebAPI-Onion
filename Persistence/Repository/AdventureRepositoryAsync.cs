using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class AdventureRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly AdventureWorkDbContext dbContext;
        
        public AdventureRepositoryAsync(AdventureWorkDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
