using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageX : ContentPage
    {
        public PageX()
        {
           
            InitializeComponent();
            
        }

        

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PageScan());
            //Application.Current.MainPage = new NavigationPage(new Page3());
        }

       
    }
}