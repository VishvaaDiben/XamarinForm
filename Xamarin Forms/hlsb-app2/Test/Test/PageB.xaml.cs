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
    public partial class PageB : ContentPage
    {
        public PageB()
        {
            
            var source = new HtmlWebViewSource();
            
            source.Html = @"<html><body bgcolor='black'>
          <h2 align='center' style='color: white; '>Account</h2>
             
<br>
          <p style='color: white; '>Create Account before register and login.</p>
          <p style='color: white; '>Edit Account at the Account page.</p>
<br><br>
<br><br>
<br><br>

&nbsp;&nbsp;<p style='color: white; '><<< Slide to following screen >>></>
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