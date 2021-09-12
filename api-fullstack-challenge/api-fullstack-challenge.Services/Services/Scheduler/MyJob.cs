﻿using api_fullstack_challenge.Models;
using api_fullstack_challenge.Models.Enum;
using api_fullstack_challenge.Repository.Repository.Interface;
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
        private readonly IWebScrapingService webScrapingService;
        private readonly IProductService productService;
        private readonly ILogRepository logRepository;

        public MyJob(IWebScrapingService _webScrapingService, IProductService _productService, ILogRepository _logRepository)
        {
            webScrapingService = _webScrapingService;
            productService = _productService;   
            logRepository = _logRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var list = webScrapingService.GetProductsInfoScheduled();

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

            return Task.CompletedTask;
        }
    }
}
