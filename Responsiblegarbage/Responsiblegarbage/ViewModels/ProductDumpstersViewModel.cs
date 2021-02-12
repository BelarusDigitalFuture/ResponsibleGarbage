using Responsiblegarbage.Services;
using Responsiblegarbage.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Responsiblegarbage.ViewModels
{
    public class ProductDumpstersViewModel : BaseViewModel
    {
        public Command LoadDumpstersCommand { get; set; }
        IDumpsterService dumpsterService;
        
        public ProductDumpstersViewModel(ProductDto product)
        {
            Product = product;
            LoadDumpstersCommand = new Command(async () => await ExecuteLoadDumpstersCommand());
            dumpsterService = DependencyService.Get<IDumpsterService>();
        }

        public ProductDto Product { get; }
        public ObservableCollection<DumpsterDto> Dumpsters { get; set; }

        async Task ExecuteLoadDumpstersCommand()
        {
            IsBusy = true;

            try
            {
                
                var dumpsters = await dumpsterService.GetByProductAsync(Product.Id);
                Dumpsters = new ObservableCollection<DumpsterDto>(dumpsters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
