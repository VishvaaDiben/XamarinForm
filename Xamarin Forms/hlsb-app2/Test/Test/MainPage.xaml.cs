using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
        }

        //private Guid id;

        public MainPage(string parameter)
        {
            InitializeComponent();
            Detail = new NavigationPage( new PageX());
            IsPresented = false;
            txtname.Text = parameter;
            

        }

       

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageX());
            IsPresented = false;
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
           
            //RegEntity fileexist = App.Database.GetItem(txtuserid.Text);
            Detail = new NavigationPage(new NewHome(txtname.Text));
           
            IsPresented = false;

        }

        private void Button_Clicked3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page2());
            IsPresented = false;
        }


        private void Button_Clicked4(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page());
            IsPresented = false;
        }

        private void Button_Clicked5(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page3());
            IsPresented = false;
        }

        private void Button_Clicked6(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page5());
            IsPresented = false;
        }

        private void Button_Clicked7(object sender, EventArgs e)
        {
            
            DisplayActionSheet( "-Author: Diben-","","- version 1.0.0-");
            //DisplayAlert("", "", "", "");

        }

        private void  Button_Clicked8(object sender, EventArgs e)
        {

            Device.BeginInvokeOnMainThread(new Action(async () =>
            {
                if (await DisplayAlert("", "Are you sure want to Logout?", "Yes", "No"))
                {
                    //Navigation.PushAsync(new Login());
                    // DisplayAlert("LOGOUT", "you have log-out, please login to continue access", "OK");
                    //Navigation.PushModalAsync(new NewLogin());
                   
                    Application.Current.MainPage = new NavigationPage(new NewLogin());
                    await DisplayAlert(title: "Alert", message: "you have log-out, please login to continue access", cancel: "OK");
                    //Navigation.PopToRootAsync();
                }
            }));
         
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageScan1());
            IsPresented = false;
        }





        //private async void Button_Clicked5(object sender, EventArgs e) => await DisplayAlert("Header", "Body", cancel: "ok");
    }
}
