using api_fullstack_challenge.Models;
using api_fullstack_challenge.Services.Interface;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace api_fullstack_challenge.Services.Implementation
{
    public class WebScrapingService : IWebScrapingService
    {
        public List<ProductScrapingModel> GetProductsInfo()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://world.openfoodfacts.org");

            var productsHtml = doc.DocumentNode.SelectNodes("//ul[@class='products']/li/a[@title!='']");

            List<string> htmls = new List<string>();

            foreach(var p in productsHtml)
            {
                htmls.Add(p.GetAttributeValue("href", null));
            }

            List<ProductScrapingModel> list = new List<ProductScrapingModel>();

            htmls.ForEach(html =>
            {
                doc = web.Load($"https://world.openfoodfacts.org{html}");

                var productCodeNode = doc.DocumentNode.SelectNodes("//p[@id='barcode_paragraph']/span[@id='barcode']");
                var productBarcodeNode = doc.DocumentNode.SelectNodes("//p[@id='barcode_paragraph']");
                var productQuantityNode = doc.DocumentNode.SelectNodes("//p[@id='field_quantity']/span[@class='field_value']");
                var productBrandsNode = doc.DocumentNode.SelectNodes("//p[@id='field_brands']/span[@class='field_value']");
                var productPackagingNode = doc.DocumentNode.SelectNodes("//p[@id='field_packaging']/span[@class='field_value']");
                var productCategoriesNode = doc.DocumentNode.SelectNodes("//p[@id='field_categories']/span[@class='field_value']");
                var productImgUrlNode = doc.DocumentNode.SelectNodes("//img[@itemprop='contentUrl']");
                var productNameNode = doc.DocumentNode.SelectNodes("//h1[@property='food:name']");

                if (productCodeNode == null) return;
                if (productBarcodeNode == null) return;
                if (productQuantityNode == null) return;
                if (productBrandsNode == null) return;
                if (productPackagingNode == null) return;
                if (productCategoriesNode == null) return;
                if (productImgUrlNode == null) return;
                if (productNameNode == null) return;

                string categories = productCategoriesNode[0].InnerText.Trim();
                string brands = productBrandsNode[0].InnerText.Trim();
                string packaging = productPackagingNode[0].InnerText.Trim();
                var barcode = productBarcodeNode[0].InnerText.Trim().Substring(10);
                var productName = productNameNode[0].InnerText.Split("-")[0].Trim();
                var imgUrl = productImgUrlNode[0].GetAttributeValue("src", null);
                var code = long.Parse(productCodeNode[0].InnerText);

                var Product = new ProductScrapingModel
                {
                    code = code,
                    barcode = barcode,
                    quantity = productQuantityNode[0].InnerText.Trim(),
                    categories = categories,
                    brands = brands,
                    packaging = packaging,
                    url = $"https://world.openfoodfacts.org{html}",
                    image_url = $"https://static.openfoodfacts.org{imgUrl}",
                    product_name = productName
                };

                list.Add(Product);
            });

            return list;
        }
    }
}
