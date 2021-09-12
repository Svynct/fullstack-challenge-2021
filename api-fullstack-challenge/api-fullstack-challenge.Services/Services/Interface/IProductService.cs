using api_fullstack_challenge.Models;
using api_fullstack_challenge.Models.Models;
using System.Collections.Generic;

namespace api_fullstack_challenge.Services.Interface
{
    public interface IProductService
    {
        Product GetById(string Id);
        Product GetByCode(long code);
        List<Product> GetAll();
        List<Product> GetByFiltro(ProductFiltroModel filtro);
        void CreateProduct(Product product);
        void CreateManyProducts(List<Product> products);
        int CreateManyProductsWithCount(List<Product> products);
        bool? UpdateProduct(ProductViewModel product);
        bool? DeleteProduct(string Id);
        bool? DeleteAll();
    }
}
