namespace EFCodeFirst.Data.Factories
{
    public class ProductContextFactory : IProductContextFactory
    {
        public ProductContext Create()
        {
            return new ProductContext();
        }
    }
}
