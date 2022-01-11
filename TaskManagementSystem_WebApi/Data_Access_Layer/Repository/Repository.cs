using Dapper;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
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
        private readonly TaskManagementSystemDBContext _context;
        private readonly IConfiguration _configuration; 
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new TaskManagementSystemDBContext(configuration);
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

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
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

        //public async Task<TEntity?> GetAsync(int id)
        //{
        //    try
        //    {
        //        return await _context.Set<TEntity>().FindAsync(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public async Task<List<TEntity>> GetAsync()
        //{
        //    try
        //    {
        //        return await _context.Set<TEntity>().ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        public async Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            IEnumerable<TEntity> data;
            using (var con =  new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString")))
            {
                con.Open();
                data = await con.QueryAsync<TEntity>(query);
                con.Close();
            }
            return data;
        }
        public async Task<TEntity?> GetAsync(string query)
        {
            TEntity data;
            using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString")))
            {
                con.Open();
                data = await con.QueryFirstOrDefaultAsync<TEntity>(query);
                con.Close();
            }
            return data;
        }
    }
}
