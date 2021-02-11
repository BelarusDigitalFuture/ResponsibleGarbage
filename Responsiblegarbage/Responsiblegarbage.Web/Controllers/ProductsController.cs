using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Responsiblegarbage.Web.Services;

namespace Responsiblegarbage.Web.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search([FromQuery] string barcode)
        {
            var product = await productService.GetByBarcodeAsync(barcode);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
