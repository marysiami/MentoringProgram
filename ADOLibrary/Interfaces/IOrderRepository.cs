using ADOLibrary.Models;
using System.Data;

namespace ADOLibrary.Interfaces
{
    public interface IOrderRepository
    {
        public Task Insert(Order product);
        public Task Update(Order product);
        public DataSet Get(int id);
        public DataTable GetAll(string status, DateTime createdDateFrom, DateTime createdDateTo, int productId);
        public Task Delete(int id);
        public Task Delete(string status, DateTime createdDateFrom, DateTime createdDateTo, int productId);
    }
}
