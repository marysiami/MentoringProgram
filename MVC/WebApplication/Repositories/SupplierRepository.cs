using MyWebApplication.Interfaces;
using MyWebApplication.Models;

namespace MyWebApplication.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private ILogger<SupplierRepository> Logger { get; set; }
        private MyDbContext _dbContext;
        public SupplierRepository(MyDbContext context, ILogger<SupplierRepository> logger)
        {
            _dbContext = context;
            Logger = logger;
        }
        public List<Supplier> GetAll()
        {
            var result = new List<Supplier>();
            try
            {
                var query = from supplier in _dbContext.Suppliers
                            select new
                            {
                                companyName = supplier.CompanyName,
                                supplierID = supplier.SupplierID
                            };

                foreach (var supplierInfo in query)
                {
                    result.Add(new Supplier()
                    {
                        SupplierID = supplierInfo.supplierID,
                        CompanyName = supplierInfo.companyName
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception during GetAllSuppliers");
            }

            return result;            
        }
    }
}
