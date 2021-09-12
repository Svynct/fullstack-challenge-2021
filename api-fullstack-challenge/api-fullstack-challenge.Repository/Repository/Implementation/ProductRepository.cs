using api_fullstack_challenge.Models;
using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace api_fullstack_challenge.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static IMongoCollection<Product> Collection => ContextMongo.Database.GetCollection<Product>("products");

        public void CreateProduct(Product product)
        {
            product.Id = ObjectId.GenerateNewId().ToString();

            Collection.InsertOne(product);
        }

        public void CreateManyProducts(List<Product> proudcts)
        {
            Collection.InsertMany(proudcts);
        }

        public Product GetProductById(string Id)
        {
            return Collection.Find(p => p.Id == Id).FirstOrDefault();
        }

        public Product GetProductByCode(long code)
        {
            return Collection.Find(p => p.code == code).FirstOrDefault();
        }

        public List<Product> GetManyProductsByCode(List<long> codes)
        {
            var result = Collection.Find(p => codes.Contains(p.code)).ToList();

            return result;
        }

        public List<Product> GetProductByFiltro(ProductFiltroModel filtro)
        {
            var result = Collection.Find(
                p => p.barcode.ToLower().Contains(filtro.Barcode.ToLower()) &&
                p.product_name.ToLower().Contains(filtro.Nome.ToLower())
            ).ToList();

            return result;
        }

        public List<Product> GetAllProducts()
        {
            var result = Collection.Aggregate()
                .Skip(0)
                .Limit(10)
                .SortBy(p => p.code)
                .ToList();

            return result;
        }
        
        public bool? UpdateProduct(ProductViewModel product, long code)
        {
            var update = Builders<Product>.Update
               .Set("brands", product.brands)
               .Set("packaging", product.packaging)
               .Set("categories", product.categories)
               .Set("quantity", product.quantity);

            var result = Collection.UpdateOne(p => p.code == code, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public bool? DeleteProduct(string Id)
        {
            var result = Collection.DeleteOne(p => p.Id == Id);

            return result.IsAcknowledged;
        }

        public bool? DeleteAll()
        {
            var result = Collection.DeleteMany(p => p.Id != null);

            return result.IsAcknowledged;
        }
    }
}
