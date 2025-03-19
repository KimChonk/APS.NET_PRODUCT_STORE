using TH_WEB_4_UP.Models;

namespace TH_WEB_4_UP.Repository
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public MockProductRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Legion 9i", Description = "High performance gaming laptop with cutting-edge technology.", Price = 2000, CategoryId = 1, ImageUrl = "/images/legion9i.jpg" },
                new Product { Id = 2, Name = "iPad Air", Description = "Powerful. Colorful. Wonderful.", Price = 600, CategoryId = 2, ImageUrl = "/images/ipadAir.jpg" },
                new Product { Id = 3, Name = "iPhone 16 Pro", Description = "The ultimate iPhone experience.", Price = 1200, CategoryId = 3, ImageUrl = "/images/ip16.jpg" },
                new Product { Id = 4, Name = "Google Pixel 6", Description = "The best of Google, built around you.", Price = 700, CategoryId = 4, ImageUrl = "/images/ggpx6.jpg" },
                new Product { Id = 5, Name = "ASUS TUF VG249Q3A", Description = "Gaming monitor with high refresh rate and vibrant colors.", Price = 300, CategoryId = 5, ImageUrl = "/images/aus_tuf_screen.jpg" },
                new Product { Id = 6, Name = "Dell Alienware", Description = "High performance gaming laptop with advanced cooling.", Price = 2500, CategoryId = 1, ImageUrl = "/images/dell_alien_ware.jpg" },
            };
        }

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }


        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }
    }
}

