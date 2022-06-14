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
            //Dapper.SqlMapper.SetTypeMap(typeof(T), new TableAttributeTypeMapper<>)
            //SqlMapper.TableNameMapper = type => {
            //    return SqlMapper.DefaultTableNameMapper(type);
            //};
            //Dapper.SqlMapper.SetTypeMap(
            //    typeof(T),
            //    new ColumnAttributeTypeMapper<T>());
            conn = (MySqlConnection)RepositoryContext.CreateConnection();
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            //Dapper.My
        }

        public DapperContext GetRepositoryContext()
        {
            return RepositoryContext;
        }
        public void Create(T entity)
        {
            //using(IDbConnection conn = )
            //{
            conn.Insert<T>(entity);
            //}
            //RepositoryContext.Add(entity);
        }

        public void Delete(T entity)
        {
            //using (IDbConnection conn = RepositoryContext.CreateConnection())
            //{
            conn.Delete(entity);
            //}
            //RepositoryContext.Remove(entity);
        }

        public IEnumerable<T> findAll()
        {
            return conn.GetList<T>();//(IQueryable<T>)conn.Query<T>($"SELECT * FROM {typeof(T).GetProperty("")}");
            //return conn.;//RepositoryContext.SelectAll();
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
    }
}
