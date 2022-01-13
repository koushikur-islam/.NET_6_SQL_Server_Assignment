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
    //Implements IRepository interface for generic repository methods.
    //All the CRUD methods have exception handled.
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TaskManagementSystemDBContext _context;
        private readonly IConfiguration _configuration; 

        //Registering necessary services with dependency injection.
        //EF Core DB context is registered for DB operations.
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new TaskManagementSystemDBContext(configuration);
        }

        //EF Core context object is used for insertion operations along with mapping the generic entity.
        //Accepts a generic entity class and makes and insertion operation on the database.
        //Returns true if any rows affected (new row inserted) else returns false.
        //Handled exceptions.
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

        //Takes a generics entity as parameter and maps with EF DB Context and updates the record.
        //Returns true if any rows affected (row updated) else returns false.
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Entry<TEntity>(entity).State = EntityState.Modified;
                var res = await _context.SaveChangesAsync();
                if (res != 0) return true; else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //Takes generic entity to delete using EF Db Context.
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

        //Used Dapper to map database entities with generic entities.
        //Takes the sql query as parameter to perform select operations.
        //Returns collection of entities.
        //Using statement is used for memory management.
        public async Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            IEnumerable<TEntity> data;
            try
            {
                using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString")))
                {
                    con.Open();
                    data = await con.QueryAsync<TEntity>(query);
                    con.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //Takes sql query as parameter and returns a single entity from database also maps the entities.
        //Using statement is used for memory management.
        public async Task<TEntity?> GetAsync(string query)
        {
            TEntity data;
            try
            {

                using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString")))
                {
                    con.Open();
                    data = await con.QueryFirstOrDefaultAsync<TEntity>(query);
                    con.Close();
                }
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}