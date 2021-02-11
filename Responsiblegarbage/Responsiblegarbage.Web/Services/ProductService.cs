using Mapster;
using Microsoft.EntityFrameworkCore;
using Responsiblegarbage.Shared;
using Responsiblegarbage.Web.Data;
using Responsiblegarbage.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext context;

        public ProductService(ApplicationContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<ProductDto> GetByBarcodeAsync(string barcode)
        {
            return await context.Products
                .ProjectToType<ProductDto>()
                .FirstOrDefaultAsync(x => x.Barcode == barcode);
        }
    }
}
