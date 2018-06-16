using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test
{
    public class ProductPage : ContentPage
    {
        public string URL = "http://192.168.43.42:5000";
        public ObservableCollection<ProductViewModel> products { get; set; }

        public ProductPage()
        {
            products = new ObservableCollection<ProductViewModel>();
            ListView lstView = new ListView();
            lstView.RowHeight = 60;
            this.Title = "Products";
            lstView.ItemTemplate = new DataTemplate(typeof(CustomProductCell));

            Get_Product(); //this is synchronous call (so watchout)
            
            lstView.ItemsSource = products;
            Content = lstView;
        }

        public class CustomProductCell : ViewCell
        {
            public CustomProductCell()
            {
                //instantiate each of our views
                var image = new Image();
                var nameLabel = new Label { TextColor = Color.Maroon };
                var typeLabel = new Label { TextColor = Color.Red };
                var verticaLayout = new StackLayout();
                var horizontalLayout = new StackLayout() { BackgroundColor = Color.White };

                //set bindings
                nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
                typeLabel.SetBinding(Label.TextProperty, new Binding("Type"));
                image.SetBinding(Image.SourceProperty, new Binding("Image"));

                //Set properties for desired design
                horizontalLayout.Orientation = StackOrientation.Horizontal;
                horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
                image.HorizontalOptions = LayoutOptions.End;
                nameLabel.FontSize = 20;

                //add views to the view hierarchy
                horizontalLayout.Children.Add(image);
                verticaLayout.Children.Add(nameLabel);
                verticaLayout.Children.Add(typeLabel);
                horizontalLayout.Children.Add(verticaLayout);
               

                // add to parent view
                View = horizontalLayout;
            }
   
        }

        public async Task Get_Product()
        {

            HttpClient client = new HttpClient();
            StringBuilder sb = new StringBuilder();

            var RestUrl = URL + "/api/Products";
            var uri = new Uri(RestUrl);

            var response = await client.GetAsync(uri);

            var result = await response.Content.ReadAsStringAsync();
            var productObject = JsonConvert.DeserializeObject<List<Product>>(result);


            if (productObject.FirstOrDefault() != null)
            {
                var items = productObject.Select(x => new ProductViewModel
                {
                    Image = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(x.ProductImage))),
                    Name = x.ProductName,
                    Type = x.ProductDetail
                }).ToList();

                foreach (var item in items)
                    products.Add(item);

            }

        }

    }
}


