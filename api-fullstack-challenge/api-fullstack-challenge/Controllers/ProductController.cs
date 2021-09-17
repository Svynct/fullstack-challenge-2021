using api_fullstack_challenge.Models;
using api_fullstack_challenge.Models.Enum;
using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Models.Models.Enum;
using api_fullstack_challenge.Repository.Repository.Interface;
using api_fullstack_challenge.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace api_fullstack_challenge.Controllers
{
    [Route("/"), ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IWebScrapingService webScrapingService;
        private readonly ILogRepository logRepository;

        public ProductController(
            IProductService _productService,
            IWebScrapingService _webScrapingService,
            ILogRepository _logRepository)
        {
            service = _productService;
            webScrapingService = _webScrapingService;
            logRepository = _logRepository;
        }

        #region GET

        [HttpGet, Route("")]
        public ActionResult GetFullstackChallenge2021()
        {
            return Ok("Fullstack Challenge 2021");
        }

        [HttpGet, Route("Products/{code}")]
        public ActionResult GetProductByCode(long code)
        {
            try
            {
                var result = service.GetByCode(code);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("Products/Filtro")]
        public ActionResult GetProductFiltro([FromQuery]ProductFiltroModel filtro)
        {
            filtro.Nome = filtro.Nome == null ? "" : filtro.Nome;
            filtro.Barcode = filtro.Barcode == null ? "" : filtro.Barcode;

            try
            {
                var result = service.GetByFiltro(filtro);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("Products")]
        public ActionResult GetAllProducts()
        {
            try
            {
                var result = service.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("Products/Retrieve")]
        public ActionResult RetrieveProducts()
        {
            try
            {
                var list = webScrapingService.GetProductsInfo();
                //var list = webScrapingService.GetOneProductInfo();

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

                if (returnList?.Count > 0)
                    service.CreateManyProducts(returnList);

                logRepository.CreateLog($"SERVIÇO OPEN FOOD FACTS RODADO MANUALMENTE: {returnList?.Count} PRODUTOS ADICIONADOS", ELogType.Sync);

                return Ok(returnList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        #endregion

        #region POST
        [HttpPost, Route("Product")]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                service.CreateProduct(product);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        #endregion

        #region PUT
        [HttpPut, Route("Product/Update/{code}")]
        public ActionResult UpdateProduct(long code, [FromBody] ProductViewModel view)
        {
            try
            {
                var result = service.UpdateProduct(view);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        #endregion

        #region DELETE
        [HttpDelete, Route("Product/DeleteAll")]
        public ActionResult DeleteAll()
        {
            try
            {
                var result = service.DeleteAll();

                logRepository.CreateLog("EXCLUINDO TODOS OS PRODUTOS DO BANCO", ELogType.Delete);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete, Route("Product/Delete/{Id}")]
        public ActionResult DeleteProduct(string Id)
        {
            try
            {
                var result = service.DeleteProduct(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        #endregion
    }
}
