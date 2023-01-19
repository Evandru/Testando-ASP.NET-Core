using DarkStore.Models;
using DarkStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DarkStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductsServices;
        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productServices)
        {
            _logger = logger;
            ProductsServices = productServices;
        }

        public void OnGet()
        {
            Products = ProductsServices.GetProducts();
        }
    }
}