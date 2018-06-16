using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageScan : ContentPage
    {
        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
        

        public PageScan() : base()
        {
            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

           

            zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () => {


                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    zxing.IsAnalyzing = false;
                    zxing.IsScanning = false;
                    
                    // Show an alert
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    await Navigation.PopModalAsync();
                    if (await DisplayAlert("", "Do you want to open browser?", "Yes", "No"))
                      {
                        
                       // Application.Current.MainPage = new NavigationPage(new PageX());
                        //Device.OpenUri(new Uri("https://www.google.com/?gfe_rd=cr&ei=ccRwWIS7D8ao8weY9b_ADA#q=" + result.Text));
                        Device.OpenUri(new Uri("https://www.google.co.in/search?q=" + result.Text));
                       
                      }

                  

                    //

                    /* rdrBtn.Clicked += (sender, e) => //Product Details Button

                     {

                         Device.OpenUri(new Uri("https://www.google.co.in/search?q=" + result.Text));


                     };*/
                    // Navigate away
                    //await Navigation.PopAsync();

                });

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                //ShowFlashButton = zxing.HasTorch,
            };
            /* var rdrBtn = new Button
             {
                 Text = "more",
                 HorizontalOptions = LayoutOptions.End,
                 VerticalOptions = LayoutOptions.End
             };
             rdrBtn.Clicked += (sender, e) => //Product Details Button

             {

                 Device.OpenUri(new Uri(lblurl));


             }; */
           
            var back = new Button
            {
                Text = "Cancel",
                //BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End
            };
            back.Clicked += (sender, e) => {
                //Navigation.PushModalAsync(new ());
                //Application.Current.MainPage = new NavigationPage(new MainPage());
                //
                Navigation.PopModalAsync();

            };

            var rdrBtn = new Button
            {
                Text = "more",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End           };


            var flash = new Button
            { 
            Image = "ic_flash_on_black_24dp.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            flash.Clicked += (sender, e) => {
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
            grid.Children.Add(rdrBtn);
            grid.Children.Add(flash);

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