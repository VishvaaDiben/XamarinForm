using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage1 : ContentPage
    {


        public ScanPage1()
        {
            InitializeComponent();
            Browser.Source = "http://www.holographic.asia/holo_wrdp/?page_id=391";


        }

        private void Browser_Navigating(object sender, WebNavigatingEventArgs e)
        {
            loading.IsVisible = true;
        }

        private void Browser_Navigated(object sender, WebNavigatedEventArgs e)
        {
            loading.IsVisible = false;
        }

    }


}