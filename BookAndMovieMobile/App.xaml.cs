using BookAndMovieMobile.Business.Abstract;
using BookAndMovieMobile.View.TabMenu;
using BooksAndMovies.Business.Concrete;
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
            Startup.Init();

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
