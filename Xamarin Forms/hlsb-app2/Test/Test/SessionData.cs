using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test
{
    public class SessionData
    {
        public static void GetSession(Label txtSession)
        {

            HttpClient client = new HttpClient(new HttpClientHandler());
            StringBuilder sb = new StringBuilder();
            client.MaxResponseContentBufferSize = 256000;
            var RestUrl = "https://jsonplaceholder.typicode.com/posts/1";
            var uri = new Uri(RestUrl);


            var response = client.GetAsync(uri);

            if (response.IsCompleted)
            {
                var content = response.Result.Content;
                txtSession.Text = content.ToString();
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


        }
    }
}
