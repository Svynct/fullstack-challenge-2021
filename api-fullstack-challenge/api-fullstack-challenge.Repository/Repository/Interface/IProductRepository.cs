using api_fullstack_challenge.Models;
using api_fullstack_challenge.Models.Models;
using System.Collections.Generic;

namespace api_fullstack_challenge.Repository.Interface
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void CreateManyProducts(List<Product> products);
        Product GetProductById(string Id);
        Product GetProductByCode(long code);
        List<Product> GetManyProductsByCode(List<long> codes);
        List<Product> GetProductByFiltro(ProductFiltroModel filtro);
        List<Product> GetAllProducts();
        bool? UpdateProduct(ProductViewModel product, long code);
        bool? DeleteProduct(string Id);
        bool? DeleteAll();
    }
}
