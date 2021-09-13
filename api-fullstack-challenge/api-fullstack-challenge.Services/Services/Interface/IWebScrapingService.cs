using api_fullstack_challenge.Models;
using System.Collections.Generic;

namespace api_fullstack_challenge.Services.Interface
{
    public interface IWebScrapingService
    {
        List<ProductScrapingModel> GetProductsInfo();
    }
}
