using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Test.SplashPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static SqlHelper Database { get { if (database == null) { database = new SqlHelper(); } return database; } }

        public static SqlHelper database { get; private set; }





    }
}
