using System.ComponentModel.DataAnnotations;

namespace TH_WEB_4_UP.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
    }
}
