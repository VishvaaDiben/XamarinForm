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
    public partial class PageA : ContentPage
    {
        public PageA()
        {
            var source = new HtmlWebViewSource();

            source.Html = @"<html><body bgcolor='blue'>
          <h2 align='center' style='color: white; '>Home</h2>
             
<br>
          <p style='color: white; '>Navigate to other features from home</p>
<br><br>
<br><br>
<br><br>

&nbsp;&nbsp;<p style='color: white; '>>>> Slide to following screen >>></>
          </body></html>";

            var labelhtml = new Xamarin.Forms.Label
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Text = source.Html,
            };
            var webview = new WebView
            {
                Source = source,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var inMemoryScrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                IsClippedToBounds = true,
                Content = labelhtml
            };

            Content = new StackLayout
            {
                Children = { webview ,
                            }
            };

        }
    }
}