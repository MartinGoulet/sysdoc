using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amf.Documentation.Developpement.API.Entities;
using Amf.Documentation.Developpement.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amf.Documentation.Developpement.API.Infrastructure.Data
{
    public class GenericRepository<TEntite> : IGenericRepository<TEntite> where TEntite : class
    {
        private readonly DeveloppementContext _dbContext;

        public GenericRepository(DeveloppementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntite> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntite>().FindAsync(id);
        }

        public async Task<List<TEntite>> ListAsync()
        {
            return await _dbContext.Set<TEntite>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(TEntite entite)
        {
            _dbContext.Entry(entite).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(TEntite entite)
        {
            _dbContext.Set<TEntite>().Add(entite);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entite = await _dbContext.Set<TEntite>().FindAsync(id);
            _dbContext.Set<TEntite>().Remove(entite);
            await _dbContext.SaveChangesAsync();
        }
    }
}