using DataCentre.Api.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> findAll(IDbTransaction transaction = null);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, IDbTransaction transaction = null);
        IEnumerable<T> FindByCondition(string expression, IDbTransaction transaction = null);
        IEnumerable<T> FindByCondition(object whereConditions, IDbTransaction transaction = null);
        object Query(string SQL, object param, IDbTransaction transaction = null);
        int Execute(string SQL, object param, IDbTransaction transaction = null);
        void Create(T entity, IDbTransaction transaction = null);
        void Update(T entity, IDbTransaction transaction = null);
        void Delete(T entity, IDbTransaction transaction = null);
        DapperContext GetRepositoryContext();
    }
}
