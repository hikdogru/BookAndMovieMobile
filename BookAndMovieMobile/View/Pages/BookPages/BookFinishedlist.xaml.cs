using BookAndMovieMobile.Model.Book;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.Pages.BookPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookFinishedlist : ContentPage
    {
        public BookFinishedlist(ObservableCollection<BookModel> books)
        {
            InitializeComponent();
            bookList.ItemsSource = books;
        }
    }
}