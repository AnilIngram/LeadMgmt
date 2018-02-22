using LeadMgmt.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadMgmt.Api.Repository
{
    public interface ILeadsRepository
    {
        Task<List<Lead>> GetAll(); 
        Task<Lead> GetById(long ID); 
        Task Create(Lead entity); 
        Task Update(Lead entity); 
        Task Delete(long ID);
    }
}
