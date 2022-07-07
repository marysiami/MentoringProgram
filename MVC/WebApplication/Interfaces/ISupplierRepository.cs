using MyWebApplication.Models;

namespace MyWebApplication.Interfaces
{
    public interface ISupplierRepository
    {
        List<Supplier> GetAll();
    }
}
