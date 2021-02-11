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
    public class DumpsterService : IDumpsterService
    {
        private readonly ApplicationContext context;

        public DumpsterService(ApplicationContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<DumpsterDto>> GetByProductAsync(int productId)
        {
            var types = await context
                .ProductGarbageTypes
                .Where(x => x.ProductId == productId)
                .Select(x => x.TypeId)
                .ToListAsync();

            return await context.Dumpsters
                .Include(x => x.Types)
                .Where(x => x.Types.Any(x => types.Contains(x.TypeId)))
                .ProjectToType<DumpsterDto>()
                .ToListAsync();
        }
    }
}
