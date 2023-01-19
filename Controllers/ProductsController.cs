using DarkStore.Models;
using DarkStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DarkStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService ProductService { get; }
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }

        //[HttpPatch]
        //public ActionResult Get([FromBody] RatingRequest request)
        //{
        //    ProductService.AddRating(request.ProductId, request.Rating);
        //    return Ok();
        //}

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get( [FromQuery] RatingRequest request )
        {
            //Query Sintax = localhost:7022/Products/Rate?ProductId=NOME&Rating="NUMERO"
            ProductService.AddRating(request.ProductId, request.Rating);
            return Ok();
        }
    }
}
