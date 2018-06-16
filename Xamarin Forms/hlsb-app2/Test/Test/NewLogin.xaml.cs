using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.IO;
using System.Globalization;
using Test;
using System.Collections.ObjectModel;


namespace Test
{
    public partial class NewLogin : ContentPage
    {
        public string URL = "http://192.168.43.42:5000";

        public NewLogin()
        {
            InitializeComponent();
            txtname.Focus();
        }

       public async void Click_Reg(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewRegistration(URL));
        }

        async void Click_Login(object sender, EventArgs e)
        {
            
            RegEntity userDetail = App.Database.GetItem(txtname.Text, txtpassword.Text);
            
            if (userDetail != null)
            {
                if (txtname.Text == null || txtpassword.Text == null)
                {
                    await DisplayAlert("Login", "Login failed . Please fill up all fields", "OK");
                }

                if (txtname.Text != userDetail.Username && txtpassword.Text != userDetail.Password)
                {
                    await DisplayAlert("Login", "Login failed . Please try again ", "OK");
                }
                else
                {
                    await DisplayAlert("Success!", "Login Success ", "OK");
                    await Navigation.PushModalAsync(new MainPage(txtname.Text));
                    //await Navigation.PushModalAsync(new NewHome(txtuserid.Text));
                    //await Navigation.PushModalAsync(new NewHome(txtuserid.Text));
                }
            }
            else
            {
                await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
            }


        }
        /*
        public async void Test_Session(object sender, EventArgs e)
        {
            //await DisplayAlert("Success", "You are checking seesion", "OK");

            var label = sessionTxt;

            await Get_Session(label);
           
        }
        */

        public async void Test_Login(object sender, EventArgs e)
        {
            var txtemail = txtname.Text;

            await Test_Login(txtemail, txtpassword.Text);
        }

        public async void Test_Product(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductPage());
        }

        public async Task<string> Get_Session(Label label)
        {
            HttpClient client = new HttpClient();
            StringBuilder sb = new StringBuilder();
            client.MaxResponseContentBufferSize = 256000;
            var RestUrl = URL + "/Session/GetUser";
            var uri = new Uri(RestUrl);


            var response = await client.GetAsync(uri);

            var result = await response.Content.ReadAsStringAsync();

            if (result != null)
            {
                var content = result;
                label.Text = content.ToString();

            }
            return result;

        }

        public async Task<string> Test_Login(string email, string password)
        {
            var loginInfo = new LoginInput
            {
                EmailAddress = email,
                Password = password
            };

            HttpClient client = new HttpClient();
            StringBuilder sb = new StringBuilder();
            client.MaxResponseContentBufferSize = 256000;
            var RestUrl = URL + "/Authentication/ValidateUser";
                //"?EmailAddress=" + email + "&Password=" + password;
            var uri = new Uri(RestUrl);

            var credential = new StringContent(JsonConvert.SerializeObject(loginInfo), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, credential);

            var result = await response.Content.ReadAsStringAsync();
            dynamic res = JsonConvert.DeserializeObject<dynamic>(result);


            if (res["data"].UserId != null)
            {
                var userFullName = res.data.FirstName + " " + res.data.LastName;
                var hasSelected =  await DisplayAlert("Success", "Welcome " + userFullName + ", Shall we proceed?", "Yeah bring me in!", "Nope I stay here");

                if(hasSelected)
                    await Navigation.PushModalAsync(new MainPage(userFullName.Value));


                //label.Text = content.ToString();
                //Result<Session> result = new Result<Session>();
                //result = JsonConvert.DeserializeObject<Result<Session>>(content);

                //foreach (var r in result.Data)
                //    txtSession.Text = txtSession.Text + "Welcome " + r.FirstName + " " + r.LastName + ", your UserID: " + r.UserId;


                //    string cFotoBase64 = emptemp.image;
                //    byte[] ImageFotoBase64 = System.Convert.FromBase64String(cFotoBase64);

                //    employeeDetail.Add(emptemp);
                //}
                //listView.ItemsSource = employeeDetail;
            }
            return result;



        }

           
    }
}