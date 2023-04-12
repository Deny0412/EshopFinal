using Web.Models;

namespace Web.DataModels
{
    public class ProductDataModel
    {
        public virtual Product product { get; set; }
        public virtual TotalProduct variant { get; set; }

        public ProductDataModel()
        {
            
        }
        public ProductDataModel(Product product, TotalProduct variant)
        {
            this.product = product;
            this.variant = variant;
        }
    }
    
}
