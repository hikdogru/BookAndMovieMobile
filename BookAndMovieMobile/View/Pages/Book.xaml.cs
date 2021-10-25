using BookAndMovieMobile.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Book : ContentPage
    {
        public Book()
        {
            InitializeComponent();
        }
    }
}