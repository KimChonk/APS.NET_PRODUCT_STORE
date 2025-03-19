using TH_WEB_4_UP.Models;

namespace TH_WEB_4_UP.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
