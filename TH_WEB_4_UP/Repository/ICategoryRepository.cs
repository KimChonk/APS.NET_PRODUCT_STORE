using TH_WEB_4_UP.Models;

namespace TH_WEB_4_UP.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();

    }
}
