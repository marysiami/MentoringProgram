using ORMLibrary.Interfaces;
using ORMLibrary.Models;

namespace ORMLibrary.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyContext db;
        public OrderRepository(MyContext context)
        {
            db = context;
        }

        public void Delete(int id)
        {
            var order = Get(id);
            if(order != null)
            {
                db.Remove(order);
                SaveChanges();
            }
            else
            {               
                throw new Exception("No Order for ID");              
            }
        }

        public void Delete(Status? status, DateTime? createdDateFrom, DateTime? createdDateTo, int? productId)
        {
            var list = GetAll(status, createdDateFrom, createdDateTo, productId);
            db.Remove(list);
            SaveChanges();
        }

        public Order? Get(int id)
        {
            var all = db.Orders.ToList();
            var result = db.Orders
                .Where(b => b.Id == id)
                .FirstOrDefault();

            return result;
        }

        public List<Order> GetAll(Status? status, DateTime? createdDateFrom, DateTime? createdDateTo, int? productId)
        {
            var result = db.Orders.ToList();
            if (status != null)
            {
                result = result.Where(x => x.Status == status).ToList();
            }
            if (createdDateFrom != null)
            {
                result = result.Where(x => x.CreatedDate >= createdDateFrom).ToList();
            }
            if (createdDateTo != null)
            {
                result = result.Where(x => x.CreatedDate <= createdDateTo).ToList();
            }
            if (productId != null)
            {
                result = result.Where(x => x.ProductId == productId).ToList();
            }              

            return result;
        }

        public async Task Insert(Order order)
        {
            if (order == null)
            {
                throw new Exception("Order is null");
            }

            await db.Orders.AddAsync(order);
            SaveChanges();
        }

        public void Update(Order order)
        {
            if(order == null)
            {
                throw new Exception("Order is null");
            }

            db.Orders.Update(order);
            SaveChanges();
        }

        private void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
