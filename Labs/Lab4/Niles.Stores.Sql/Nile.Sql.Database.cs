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
            if (product == null)
                throw new ArgumentNullException("product");

            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                conn.Open();
                var result = cmd.ExecuteScalar();
                var id = Convert.ToInt32(result);

                return product;
            }
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {                       
                       yield return new Product()
                       {                          
                           Id = reader.GetFieldValue<int>(0),
                           Name = reader.GetFieldValue<string>(1),
                           Price = reader.GetFieldValue<decimal>(2),
                           Description = reader.GetFieldValue<string>(3),
                           IsDiscontinued = reader.GetFieldValue<bool>(4)
                       };                     
                    };
                };
            };
        }

        protected override Product GetCore(int id)
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productId = reader.GetSqlInt32(0);
                        if (id != productId)
                            continue;

                        return new Product()
                        {
                            Id = reader.GetFieldValue<int>(0),
                            Name = reader.GetFieldValue<string>(1),
                            Price = reader.GetFieldValue<decimal>(2),
                            Description = reader.GetFieldValue<string>(3),
                            IsDiscontinued = reader.GetFieldValue<bool>(4)
                        };
                    };
                };
            };

            return null;
        }

        protected override void RemoveCore(int id)
        {
            var product = GetCore(id);
            if (product == null)
                return;

            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("RemoveProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", product.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        protected override Product UpdateCore(Product existing, Product newItem)
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

                conn.Open();
                cmd.ExecuteNonQuery();

                return newItem;
            };
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
