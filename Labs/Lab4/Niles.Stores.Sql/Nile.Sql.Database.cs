using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nile;
using Nile.Stores;

namespace Niles.Stores.Sql
{
    public class SqlDatabase : ProductDatabase
    {
        public SqlDatabase ( string connectionString )
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection String cannot be empty.", nameof(connectionString));

            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override Product AddCore(Product product)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            throw new NotImplementedException();
        }

        protected override Product GetCore(int id)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore(int id)
        {
            throw new NotImplementedException();
        }

        protected override Product UpdateCore(Product existing, Product newItem)
        {
            throw new NotImplementedException();
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
