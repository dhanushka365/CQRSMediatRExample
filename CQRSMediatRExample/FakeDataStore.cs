namespace CQRSMediatRExample
{
    public class FakeDataStore
    {
        private static List<Product> _products ;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Product 1"},
                new Product() {Id = 2, Name = "Product 2"},
                new Product() {Id = 3, Name = "Product 3"},
                new Product() {Id = 4, Name = "Product 4"},
                new Product() {Id = 5, Name = "Product 5"}

            };
        }

      
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.FromResult(_products);
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateProduct(Product product)
        {
            var productToUpdate = _products.FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteProduct(int id)
        {
            var productToDelete = _products.FirstOrDefault(p => p.Id == id);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
            await Task.CompletedTask;
        }

        public async Task<Product> GetProductById(int id) =>  await Task.FromResult(_products.Single(p => p.Id == id));
        

    }
}
