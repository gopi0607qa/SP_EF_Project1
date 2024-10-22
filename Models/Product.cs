using System.ComponentModel.DataAnnotations;

namespace SP_EF_Project1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        public Decimal ProductPrice { get; set; }

        public int ProductStock { get; set; }
    }
}
