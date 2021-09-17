using api_fullstack_challenge.Models;
using api_fullstack_challenge.Models.Enum;
using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Repository.Interface;
using api_fullstack_challenge.Services.Interface;
using System.Collections.Generic;

namespace api_fullstack_challenge.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public Product GetById(string Id)
        {
            return productRepository.GetProductById(Id);
        }

        public Product GetByCode(long code)
        {
            return productRepository.GetProductByCode(code);
        }

        public List<Product> GetByFiltro(ProductFiltroModel filtro)
        {
            var result = productRepository.GetProductByFiltro(filtro);

            if (filtro.Status == "Draft" || filtro.Status == "Imported")
            {
                EStatus status = filtro.Status == "Draft" ? EStatus.Draft : EStatus.Imported;

                result.RemoveAll(p => p.status != status);
            }

            return result;
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAllProducts();
        }

        public void CreateProduct(Product product)
        {
            productRepository.CreateProduct(product);
        }

        public void CreateManyProducts(List<Product> products)
        {
            List<long> codes = new List<long>();

            products.ForEach(p => codes.Add(p.code));

            var existingProducts = productRepository.GetManyProductsByCode(codes);

            codes.Clear();

            existingProducts.ForEach(p => codes.Add(p.code));

            products.RemoveAll(p => codes.Contains(p.code));

            if (products?.Count > 0)
                productRepository.CreateManyProducts(products);
        }

        public int CreateManyProductsWithCount(List<Product> products)
        {
            List<long> codes = new List<long>();

            products.ForEach(p => codes.Add(p.code));

            List<Product> existingProducts = new List<Product>();

            if (codes?.Count > 0)
                existingProducts = productRepository.GetManyProductsByCode(codes);

            codes.Clear();

            existingProducts.ForEach(p => codes.Add(p.code));

            products.RemoveAll(p => codes.Contains(p.code));

            if (products?.Count > 0)
                productRepository.CreateManyProducts(products);

            return products.Count;
        }

        public bool? UpdateProduct(ProductViewModel product)
        {
            return productRepository.UpdateProduct(product, product.code);
        }

        public bool? DeleteProduct(string Id)
        {
            return productRepository.DeleteProduct(Id);
        }

        public bool? DeleteAll()
        {
            return productRepository.DeleteAll();
        }
    }
}
