namespace ShopABC.Models
{
    public class ProductModel
    {
        public int Idproduct { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
