using System.ComponentModel.DataAnnotations;

namespace TH_WEB_4_UP.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(100000)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; } // Đảm bảo không có StringLength ở đây
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
