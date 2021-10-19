using BookAndMovieMobile.Model.Book;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookList : ContentPage
    {
        public BookList(ObservableCollection<BookModel> books)
        {
            InitializeComponent();
            bookList.ItemsSource = books;
        }
    }
}