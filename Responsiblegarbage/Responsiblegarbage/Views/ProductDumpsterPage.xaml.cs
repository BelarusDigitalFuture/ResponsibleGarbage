using Responsiblegarbage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Responsiblegarbage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDumpsterPage : ContentPage
    {
        ProductDumpstersViewModel viewModel;
        public ProductDumpsterPage(ProductDumpstersViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
    }
}