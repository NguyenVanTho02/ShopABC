namespace ShopABC.Models
{
    public class PostModel
    {
        public int Idpost { get; set; }
        public string ContentPost { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string Title { get; set; } = null!;
        public int? Iduser { get; set; }
    }
}
