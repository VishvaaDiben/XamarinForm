using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageC : ContentPage
	{
		public PageC ()
		{

            
             var source = new HtmlWebViewSource();

             source.Html = @"<html><body bgcolor='yellow'>
           <h2 align='center' style='color: black; '>Setting</h2>

 <br>
           <p style='color: black; '>Setting function to custom preferences in-built features.</p>

 <br><br>
 <br><br>
 <br><br>

 &nbsp;&nbsp;<p style='color:black; '><<< Slide to following screen >>></>
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
                 Children =
                 {
                     webview ,
                  }
             };
        }
	}
}