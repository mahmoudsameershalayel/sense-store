namespace Sense.Areas.Provider.Models
{
    public class UpdateProductPriceRequest
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
