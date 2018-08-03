using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amf.Documentation.Developpement.API.Entities;

namespace Amf.Documentation.Developpement.API.Interfaces
{
    public interface IGenericRepository<TEntite> where TEntite : class
    {
        Task<TEntite> GetByIdAsync(int id);
        Task<List<TEntite>> ListAsync();
        Task UpdateAsync(TEntite mv);
        Task AddAsync(TEntite mv);
        Task DeleteAsync(int id);

    }
}