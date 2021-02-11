using Responsiblegarbage.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Services
{
    public interface IDumpsterService
    {
        Task<List<DumpsterDto>> GetByProductAsync(int productId);
    }
}