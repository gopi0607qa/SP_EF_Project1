namespace SP_EF_Project1.Models
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }

        public Decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
