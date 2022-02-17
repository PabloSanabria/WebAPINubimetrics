
namespace WebAPINubimetrics.Entity.DTO
{
    public class ProductoDTO
    {
        public string Id { get; set; }
        public string Site_Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public SellerDTO Seller { get; set; }
        public string PermaLink { get; set; }
    }
}
