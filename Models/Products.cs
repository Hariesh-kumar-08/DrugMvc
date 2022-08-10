using System.ComponentModel.DataAnnotations;

namespace DrugMvc.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public DateTime MfdDate { get; set; }

        public DateTime ExpDate { get; set; }

        public int price { get; set; }

        public int Stock { get; set; }

        public virtual ICollection<Dummy>? Dummies { get; set; }
    }
}
