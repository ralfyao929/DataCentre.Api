using DataCentre.Api.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> findAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindByCondition(string expression);
        IEnumerable<T> FindByCondition(object whereConditions);
        object Query(string SQL, object param);
        int Execute(string SQL, object param);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        DapperContext GetRepositoryContext();
    }
}
