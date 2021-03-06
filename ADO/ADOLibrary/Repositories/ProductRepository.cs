using ADOLibrary.Interfaces;
using ADOLibrary.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace ADOLibrary.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private string ConnectionString { get; set; }
        public ProductRepository(DbConfig dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }
        
        public async Task Delete(int id)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            var queryString = "DELETE FROM [dbo].[Product] WHERE Id = @Id";
            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@Id", id);

            try
            {
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(command.CommandText, ex);
            }
        }

        public async Task DeleteAll()
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            var queryString = "DELETE FROM [dbo].[Product]";
            var command = new SqlCommand(queryString, connection);

            try
            {
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public DataSet Get(int id)
        {
            using SqlConnection connection = new(ConnectionString);

            var queryString = "SELECT * FROM [dbo].[Product] WHERE Id = @Id";

            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@Id", id);                     

            try
            {
                connection.Open();
                using SqlDataAdapter sda = new(command);
                DataSet dsData = new();
                sda.Fill(dsData);

                connection.Close();
                    
                return dsData;
            }
            catch (Exception ex)
            {
                throw new Exception(queryString, ex);        
            }
        }

        public List<Product> GetAll()
        {
            var result = new List<Product>();
            using SqlConnection connection = new(ConnectionString);

            var queryString = "SELECT * FROM dbo.Product ";

            var command = new SqlCommand(queryString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        Weight = (int)reader["Weight"],
                        Length = (int)reader["Length"],
                        Width = (int)reader["Width"]
                    });
                    
                }
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(queryString, ex);
            }
        }

        public async Task Insert(Product product)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"INSERT INTO [dbo].[Product]
                ([Name], [Description], [Weight], [Width], [Length])
                VALUES
                (@Name, @Description, @Weight, @Width, @Length)";

            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Weight", product.Weight);
            command.Parameters.AddWithValue("@Width", product.Width);
            command.Parameters.AddWithValue("@Length", product.Length);                       

            try
            {
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch(DbException ex)
            {
                throw ex;
            }            
        }

        public async Task Update(Product product)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @" UPDATE [dbo].[Product]
                SET [Name] = @Name,
                [Description] = @Description,
                [Weight] = @Weight,
                [Width] = @Width,
                [Length] = @Length
                WHERE Id = @Id";

            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Weight", product.Weight);
            command.Parameters.AddWithValue("@Width", product.Width);
            command.Parameters.AddWithValue("@Length", product.Length);

            try
            {
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
    }
}
