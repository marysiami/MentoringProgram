using ORMLibrary.Models;

namespace ORMLibrary.Interfaces
{
    public interface IOrderRepository
    {
        public Task Insert(Order order);
        public void Update(Order order);
        public Order? Get(int id);
        public List<Order> GetAll(Status? status, DateTime? createdDateFrom, DateTime? createdDateTo, int? productId);
        public void Delete(int id);
        public void Delete(Status? status, DateTime? createdDateFrom, DateTime? createdDateTo, int? productId);
    }
}
