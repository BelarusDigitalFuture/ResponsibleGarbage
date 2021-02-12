using Responsiblegarbage.Extensions;
using Responsiblegarbage.Services;
using Responsiblegarbage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Responsiblegarbage.Views
{
    public class ProductScanPage : ContentPage
    {
        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
        IProductService productService;

        public ProductScanPage() : base()
        {
            productService = DependencyService.Get<IProductService>();

            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
                //Options = new ZXing.Mobile.MobileBarcodeScanningOptions()
                //{
                //    PossibleFormats = new List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.EAN_13 },
                //    CameraResolutionSelector = ZxingExtensions.SelectLowestResolutionMatchingDisplayAspectRatio
                //}
                
            };

            zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () =>
                {

                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    zxing.IsAnalyzing = false;

                    var product = await productService.SearchProductAsync(result.Text);

                    if (product == null)
                    {
                        await DisplayAlert("Резултаты поиска", "Товар не найден", "OK");
                        //await Navigation.PopAsync();
                        zxing.IsAnalyzing = true;
                    }

                    await Navigation.PushAsync(new ProductDumpsterPage(new ProductDumpstersViewModel(product)));

                });

            overlay = new ZXingDefaultOverlay
            {
                TopText = "",
                BottomText = "Наведите камеру на штрих-код",
                ShowFlashButton = zxing.HasTorch,
                AutomationId = "zxingDefaultOverlay",
            };
            overlay.FlashButtonClicked += (sender, e) =>
            {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxing);
            grid.Children.Add(overlay);

            // The root page of your application
            Content = grid;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
            zxing.IsAnalyzing = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsAnalyzing = false;
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}