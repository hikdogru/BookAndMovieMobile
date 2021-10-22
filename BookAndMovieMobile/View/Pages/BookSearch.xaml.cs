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
    public partial class BookSearch : ContentPage
    {
        private List<BookModel> _books;

        public BookSearch()
        {
            InitializeComponent();
        }

       

        private void SearchBook(object sender, EventArgs e)
        {
            string query = txtSearchQuery.Text;
            string clientUrl = "https://www.googleapis.com/books/v1/volumes?key=AIzaSyAWeKsrZKQlLMC2AaDxM1zRbLoBHoEMj8w" + "&q=" + query + "+intitle:" + query;
            var model = new BookApiModel();
            var books = model.GetBookFromGoogle(url: clientUrl);
            BookConfiguration(books: books);
            bookList.ItemsSource = _books.Where(x => x.SmallThumbnail != null);
            txtSearchQuery.Text = "";
        }

        private void BookConfiguration(List<BookInfoModel> books)
        {
            _books = new();
            books.ForEach(x => x.VolumeInfo.Id = x.Id);
            books.ForEach(x => x.VolumeInfo.Thumbnail = x.VolumeInfo.ImageLinks?.Thumbnail);
            books.ForEach(x => x.VolumeInfo.SmallThumbnail = x.VolumeInfo.ImageLinks?.SmallThumbnail);
            books.ForEach(m => _books.Add(m.VolumeInfo));
        }
    }
}