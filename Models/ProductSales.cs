using System.ComponentModel.DataAnnotations.Schema;

namespace SP_EF_Project1.Models
{
    [NotMapped]
    public class ProductSales
    {
        public int SalesID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public Decimal ProductPrice { get; set; }

    }
}
