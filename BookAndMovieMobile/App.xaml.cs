using BookAndMovieMobile.View.TabMenu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabControl();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
