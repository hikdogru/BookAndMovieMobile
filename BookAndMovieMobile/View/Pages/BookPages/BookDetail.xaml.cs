using BookAndMovieMobile.Model.Book;
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
    public partial class BookDetail : ContentPage
    {
        public BookDetail(BookModel book)
        {
            InitializeComponent();
            GetBookDetail(book: book);
        }

        public void GetBookDetail(BookModel book)
        {
            bookImage.Source =book.Thumbnail;
            bookTitle.Text = book.Title;
            bookAuthor.Text = book.Authors[0];
            bookPublisher.Text = book.Publisher;
            bookAverageRating.Text = book.AverageRating.ToString();
            bookDescription.Text = book.Description;
        }
    }
}