﻿using System.Data.Common;
using System.Data;

namespace PizzaSalesAPI.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        DataTable GetData(string query, params DbParameter[] parameters);
    }
}
