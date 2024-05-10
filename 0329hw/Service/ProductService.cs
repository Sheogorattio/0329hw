using _0329hw.Models;

namespace _0329hw.Service
{
    public class ProductService
    {
        private List<Product> products;
        public ProductService()
        {
            products = new List<Product>()
            {
                new Product() {Id=1,Name="Salami", Price=50, Category="Meat", Description="A meat product"},
                new Product() {Id=2, Name="Milk", Price=40,Category="Dairy",Description="A dairy product"},
                new Product() {Id=3, Name="Cookies",Price=30, Category="Sweets",Description="A sweet product"}
            };
        }
        public void UpdateProduct(Product product)
        {
            var currentProduct = products.FirstOrDefault(e=>e.Id==product.Id);
            if (currentProduct != null)
            {
                currentProduct.Name = product.Name;
                currentProduct.Price = product.Price;
                currentProduct.Category = product.Category;
                currentProduct.Description = product.Description;
            }
        }
        public Product GetProduct(int productId)
        {
            return products.FirstOrDefault(e => e.Id == productId);
        }
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
