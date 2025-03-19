using Microsoft.EntityFrameworkCore;
using TH_WEB_4_UP.Models;

namespace TH_WEB_4_UP.Repository
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Category category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.categories.FindAsync(id);
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        public async Task SeedCategoriesAsync()
        {
            if (!_context.categories.Any())
            {
                var categories = new List<Category>
            {
                new Category { Name = "SmartPhone" },
                new Category { Name = "Laptop" },
                new Category { Name = "Desktop" },
                new Category { Name = "Tablet" },
                new Category { Name = "Parts" }
            };

                _context.categories.AddRange(categories);
                await _context.SaveChangesAsync();
            }
        }
    }
}
