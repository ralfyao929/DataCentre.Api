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
        protected MySqlTransaction Transaction { get; }
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
        public void Create(T entity, IDbTransaction transaction = null)
        {
            conn.Insert<T>(entity, transaction);
        }

        public void Delete(T entity, IDbTransaction transaction = null)
        {
            conn.Delete(entity, transaction);
        }

        public IEnumerable<T> findAll(IDbTransaction transaction = null)
        {
            return conn.GetList<T>(transaction);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, IDbTransaction transaction = null)
        {
            var result = from l in conn.GetList<T>(transaction) select l;
            return ((IQueryable<T>)result).Where(expression);
        }

        public IEnumerable<T> FindByCondition(string expression, IDbTransaction transaction = null)
        {
            return conn.GetList<T>(expression, null, transaction);
        }

        public void Update(T entity, IDbTransaction transaction = null)
        {
            conn.Update(entity, transaction);
            //RepositoryContext.Set<T>().Update(entity);
        }

        public IEnumerable<T> FindByCondition(object whereConditions, IDbTransaction transaction = null)
        {
            return conn.GetList<T>(whereConditions, transaction);
        }

        public object Query(string SQL, object param, IDbTransaction transaction = null)
        {
            return conn.Query(SQL, param, transaction);
        }

        public int Execute(string SQL, object param, IDbTransaction transaction = null)
        {
            return conn.Execute(SQL, param, transaction);
        }
    }
}
