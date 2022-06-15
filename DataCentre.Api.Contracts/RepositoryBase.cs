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
            if (transaction != null)
                transaction.Connection.Insert<T>(entity, transaction);
            else
                conn.Insert<T>(entity);
        }

        public void Delete(T entity, IDbTransaction transaction = null)
        {
            if (transaction != null)
                transaction.Connection.Delete<T>(entity, transaction);
            else
                conn.Delete(entity);
        }

        public IEnumerable<T> findAll(IDbTransaction transaction = null)
        {
            if (transaction != null)
                return transaction.Connection.GetList<T>(transaction);
            return conn.GetList<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, IDbTransaction transaction = null)
        {
            if (transaction != null)
            {
                var result1 = from l in transaction.Connection.GetList<T>(transaction) select l;
                return ((IQueryable<T>)result1).Where(expression);
            }
            var result = from l in conn.GetList<T>() select l;
            return ((IQueryable<T>)result).Where(expression);
        }

        public IEnumerable<T> FindByCondition(string expression, IDbTransaction transaction = null)
        {
            if (transaction != null)
                return transaction.Connection.GetList<T>(expression, null, transaction);
            return conn.GetList<T>(expression);
        }

        public void Update(T entity, IDbTransaction transaction = null)
        {
            if (transaction != null)
                transaction.Connection.Update<T>(entity, transaction);
            else
                conn.Update(entity);
            //RepositoryContext.Set<T>().Update(entity);
        }

        public IEnumerable<T> FindByCondition(object whereConditions, IDbTransaction transaction = null)
        {
            if(transaction != null)
                return transaction.Connection.GetList<T>(whereConditions, transaction);
            return conn.GetList<T>(whereConditions);
        }

        public object Query(string SQL, object param, IDbTransaction transaction = null)
        {
            if (transaction != null)
                return transaction.Connection.Query(SQL, param, transaction);
            return conn.Query(SQL, param);
        }

        public int Execute(string SQL, object param, IDbTransaction transaction = null)
        {
            if (transaction != null)
                return transaction.Connection.Execute(SQL, param, transaction);
            return conn.Execute(SQL, param);
        }
    }
}
