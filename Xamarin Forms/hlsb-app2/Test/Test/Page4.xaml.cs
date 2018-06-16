using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
        
        public Page4() : base()
        {
            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,              
            };

           
            zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread( async () => {
                   

                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    zxing.IsAnalyzing = false;
                   

                    // Show an alert
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    await DisplayAlert("open url link?",result.ToString(), "Yes", cancel: "No");

                    // Navigate away
            await Navigation.PopAsync();
                                                           
                });

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = zxing.HasTorch,
                

            };

            var back = new Button
            {
                Text = "Cancel",
                //BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            back.Clicked += (sender, e) => {
                //Navigation.PushModalAsync(new ());
                //Application.Current.MainPage = new NavigationPage(new MainPage());
                //
                //Navigation.PushModalAsync(new MainPage());

            };

            overlay.FlashButtonClicked += (sender, e) => {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxing);
            grid.Children.Add(overlay);
            grid.Children.Add(back);

            // The root page of your application
            Content = grid;
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
            /*zxing.IsEnabled= true;          
            zxing.IsTorchOn = true;
            zxing.IsAnalyzing = true;*/
            zxing.IsScanning = true;

        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;
            /*zxing.IsAnalyzing = false;
            zxing.IsTorchOn = false;
            zxing.IsEnabled = false;*/
            

            base.OnDisappearing();
        }
    }
}