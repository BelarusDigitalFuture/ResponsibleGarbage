using Responsiblegarbage.Shared;
using System.Threading.Tasks;

namespace Responsiblegarbage.Services
{
    public interface IProductService
    {
        Task<ProductDto> SearchProductAsync(string barcode);
    }
}