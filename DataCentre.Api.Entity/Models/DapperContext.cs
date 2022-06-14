using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        //private T t;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("mysqlconnection");
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
        public string ConnectionString { get { return _connectionString; } }
        //public object Set<T>()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
