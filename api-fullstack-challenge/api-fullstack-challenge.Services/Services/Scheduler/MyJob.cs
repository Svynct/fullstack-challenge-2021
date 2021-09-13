using api_fullstack_challenge.Models;
using api_fullstack_challenge.Models.Enum;
using api_fullstack_challenge.Repository;
using api_fullstack_challenge.Repository.Repository.Implementation;
using api_fullstack_challenge.Repository.Repository.Interface;
using api_fullstack_challenge.Services.Implementation;
using api_fullstack_challenge.Services.Interface;
using MongoDB.Bson;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_fullstack_challenge.Services.Services.Scheduler
{
    public class MyJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            IWebScrapingService webScrapingService = new WebScrapingService();
            IProductService productService = new ProductService(new ProductRepository());
            ILogRepository logRepository = new LogRepository();

            var list = webScrapingService.GetProductsInfo();

            var returnList = new List<Product>();

            list.ForEach(product =>
            {
                var p = new Product
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    code = product.code,
                    barcode = product.barcode,
                    brands = product.brands,
                    categories = product.categories,
                    image_url = product.image_url,
                    status = EStatus.Imported,
                    imported_t = DateTime.Now,
                    packaging = product.packaging,
                    product_name = product.product_name,
                    quantity = product.quantity,
                    url = product.url
                };

                returnList.Add(p);
            });

            var count = productService.CreateManyProductsWithCount(returnList);

            logRepository.CreateLog($"SERVIÇO OPEN FOOD FACTS RODADO AUTOMATICAMENTE: {count} PRODUTOS ADICIONADOS");
            
            return Task.FromResult(0);
        }
    }
}
