using Responsiblegarbage.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Responsiblegarbage.Services
{
    public interface IDumpsterService
    {
        Task<List<DumpsterDto>> GetByProductAsync(int productId);
    }
}