using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //private readonly IOptions<ConnectionStrings> _connectionStrings;
        //private readonly TaskManagementSystemDbContext _context;
        //public Repository(IOptions<ConnectionStrings> connectionStrings)
        //{
        //    _connectionStrings  = connectionStrings;
        //    _context = new TaskManagementSystemDbContext(_connectionStrings);
        //}
        private readonly IConfiguration _configuration;
        private readonly TaskManagementSystemDbContext _context;
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new TaskManagementSystemDbContext(configuration);
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                var res = await _context.SaveChangesAsync();
                if (res != 0) return true; else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                var res = await _context.SaveChangesAsync();
                if (res != 0) return true; else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await GetAsync(id);
                if (item != null)
                {
                    _context.Set<TEntity>().Remove(item);
                    var res = await _context.SaveChangesAsync();
                    if (res != 0) return true; else return false;

                }
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<TEntity>> GetAsync()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
