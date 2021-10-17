using BookAndMovieMobile.Model.Book;
using BookAndMovieMobile.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookAndMovieMobile.ViewModel.Book
{
    public class BookViewModel
    {
        public ObservableCollection<BookModel> Books { get; set; }
        public ICommand BookDetailCommand => new Command(BookDetail);

        public BookViewModel()
        {
            GetPopularBooks();
        }

        private void GetPopularBooks()
        {
            Books = new ObservableCollection<BookModel>();
            string clientUrl = "https://www.googleapis.com/books/v1/volumes?q=flowers&orderBy=newest&key=AIzaSyAWeKsrZKQlLMC2AaDxM1zRbLoBHoEMj8w&maxResults=20";
            var books = new BookApiModel().GetBookFromGoogle(url: clientUrl);
            books.ForEach(x => x.VolumeInfo.Id = x.Id);
            books.ForEach(x => x.VolumeInfo.Thumbnail = x.VolumeInfo.ImageLinks.Thumbnail);
            books.ForEach(x => x.VolumeInfo.SmallThumbnail = x.VolumeInfo.ImageLinks.SmallThumbnail);
            books.ForEach(m => Books.Add(m.VolumeInfo));
        }

        private void BookDetail(object obj)
        {
            var book = ((BookModel)obj);
            Application.Current.MainPage.Navigation.PushModalAsync(new BookDetail(book: book), true);
        }
    }
}
