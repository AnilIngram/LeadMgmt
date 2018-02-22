using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadMgmt.Api.Infrastructure;
using LeadMgmt.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace LeadMgmt.Api.Repository
{
    public class LeadsRepository : ILeadsRepository
    {
        private readonly LeadMgmtContext _dbContext; 

        public LeadsRepository(LeadMgmtContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Lead>> GetAll()
        {
            return await _dbContext.Set<Lead>().ToListAsync();
        }

        public async Task<Lead> GetById(long id)
        {
            return await _dbContext.Set<Lead>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task Create(Lead entity)
        {
            await _dbContext.Set<Lead>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Lead entity)
        {
            _dbContext.Set<Lead>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(long ID)
        {
            var entity = await GetById(ID);
            _dbContext.Set<Lead>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
