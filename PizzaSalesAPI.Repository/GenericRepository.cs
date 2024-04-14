using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Repository.Interfaces;
using System.Data;
using System.Data.Common;

namespace PizzaSalesAPI.Repository
{
    public abstract class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly PizzaSalesAPIContext _dbContext;

        protected GenericRepository(PizzaSalesAPIContext context)
        {
            _dbContext = context;
        }

        public async Task<T> GetById(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public DataTable GetData(string query, params DbParameter[] parameters) {
            DataTable dataTable = new DataTable();
            DbConnection connection = _dbContext.Database.GetDbConnection();

            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}
