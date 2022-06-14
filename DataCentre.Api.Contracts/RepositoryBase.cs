//using Dapper;
using Dapper;
using DataCentre.Api.Entity.Models;
using MySqlConnector;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DapperContext RepositoryContext { get; set; }
        protected MySqlConnection conn { get; set; }
        public RepositoryBase(DapperContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            conn = (MySqlConnection)RepositoryContext.CreateConnection();
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
        }

        public DapperContext GetRepositoryContext()
        {
            return RepositoryContext;
        }
        public void Create(T entity)
        {
            conn.Insert<T>(entity);
        }

        public void Delete(T entity)
        {
            conn.Delete(entity);
        }

        public IEnumerable<T> findAll()
        {
            return conn.GetList<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var result = from l in conn.GetList<T>() select l;
            return ((IQueryable<T>)result).Where(expression);
        }

        public IEnumerable<T> FindByCondition(string expression)
        {
            return conn.GetList<T>(expression);
        }

        public void Update(T entity)
        {
            conn.Update(entity);
            //RepositoryContext.Set<T>().Update(entity);
        }

        public IEnumerable<T> FindByCondition(object whereConditions)
        {
            return conn.GetList<T>(whereConditions);
        }

        public object Query(string SQL, object param)
        {
            return conn.Query(SQL, param);
        }

        public int Execute(string SQL, object param)
        {
            return conn.Execute(SQL, param);
        }
    }
}
