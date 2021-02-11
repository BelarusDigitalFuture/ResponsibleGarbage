using Responsiblegarbage.Shared;
using System.Threading.Tasks;

namespace Responsiblegarbage.Web.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetByBarcodeAsync(string barcode);
    }
}