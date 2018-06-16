using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {


        public Page2()
        {
            InitializeComponent();
            Browser.Source = "http://www.holographic.asia/holo_wrdp/?page_id=368";


        }

        private void Browser_Navigating(object sender, WebNavigatingEventArgs e)
        {
          loading.IsVisible = true;
        }

        private void Browser_Navigated(object sender, WebNavigatedEventArgs e)
        {
          loading.IsVisible = false;
        }

        /* public bool IsLoading { get; private set; }

         private async Task ExecuteLoadCommand()
         {
             if (IsLoading) return;
             IsLoading = true;


         }*/
    }
}