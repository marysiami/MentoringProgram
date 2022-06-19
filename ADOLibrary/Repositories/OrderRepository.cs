using ADOLibrary.Interfaces;
using ADOLibrary.Models;
using System.Data.SqlClient;
using System.Data;
using Z.BulkOperations;

namespace ADOLibrary.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_ORM_mentoring;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public async Task Delete(int id)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();

            var queryString = "DELETE FROM [dbo].[Order] WHERE Id = @Id";
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

        public async Task Delete(string status,
            DateTime createdDateFrom,
            DateTime createdDateTo,
            int productId)
        {
            var dt = GetAll(status, createdDateFrom, createdDateTo, productId);

            using SqlConnection connection = new(connectionString);
            connection.Open();  

            try
            {
                using (var bulk = new BulkOperation(connection))
                {
                    bulk.DestinationTableName = "Order";

                    await bulk.BulkDeleteAsync(dt);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Bulk delete async", ex);
            }
        }

        public DataSet Get(int id)
        {
            var result = new Order();

            using SqlConnection connection = new(connectionString);

            var queryString = "SELECT * FROM [dbo].[Order] WHERE Id = @Id";

            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();
                SqlDataAdapter sda = new(command);
                DataSet dsData = new();
                sda.Fill(dsData);
                return dsData;
            }
            catch (Exception ex)
            {
                throw new Exception(queryString, ex);
            }
        }

        public DataTable GetAll(string status,
            DateTime createdDateFrom,
            DateTime createdDateTo,
            int productId)
        {
            string procedure = "GetOrdersProcedure";

            using SqlConnection connection = new(connectionString);

            var command = new SqlCommand(procedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter  param = command.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
            param.Value = status;

            param = command.Parameters.Add("@CreatedDateFrom", SqlDbType.Date);
            param.Value = createdDateFrom;

            param = command.Parameters.Add("@CreatedDateTo", SqlDbType.Date);
            param.Value = createdDateTo;

            param = command.Parameters.Add("@ProductId", SqlDbType.Int);
            param.Value = productId;

            try
            {
                connection.Open();
                SqlDataAdapter sda = new(command);
                DataTable dt = new();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(procedure, ex);
            }
        }

        public async Task Insert(Order Order)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = @"INSERT INTO [dbo].[Order]
                ([UpdatedDate], [Status], [CreatedDate], [ProductId])
                VALUES
                (@UpdatedDate, @Status, @CreatedDate, @ProductId)";

            command.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@Status", Order.Status);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@ProductId", Order.ProductId);

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

        public async Task Update(Order Order)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = @" UPDATE [dbo].[Order]
                SET [UpdatedDate] = @UpdatedDate,
                [Status] = @Status
                WHERE Id = @Id";

            command.Parameters.AddWithValue("@Id", Order.Id);
            command.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@Status", Order.Status);;

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
    }
}
