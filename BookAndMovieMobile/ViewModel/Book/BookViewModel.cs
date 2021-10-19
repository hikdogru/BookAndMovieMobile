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
        private readonly string _rootUrl = "https://www.googleapis.com/books/v1/volumes?key=AIzaSyAWeKsrZKQlLMC2AaDxM1zRbLoBHoEMj8w";

        public ObservableCollection<BookModel> Books { get; set; }
        public string SearchQuery { get; set; }
        public ICommand BookDetailCommand => new Command(BookDetail);
        public ICommand BookSearchCommand => new Command(RedirectToBookSearchPage);
        public ICommand SearchCommand => new Command(Search);


        public BookViewModel()
        {
            GetPopularBooks();
        }

        private void GetPopularBooks()
        {
            Books = new ObservableCollection<BookModel>();
            string clientUrl = _rootUrl + "&maxResults=20&q=flowers&orderBy=newest";
            var books = new BookApiModel().GetBookFromGoogle(url: clientUrl);
            BookConfiguration(books: books);
        }

        private void BookConfiguration(List<BookInfoModel> books)
        {
            books.ForEach(x => x.VolumeInfo.Id = x.Id);
            books.ForEach(x => x.VolumeInfo.Thumbnail = x.VolumeInfo.ImageLinks?.Thumbnail);
            books.ForEach(x => x.VolumeInfo.SmallThumbnail = x.VolumeInfo.ImageLinks?.SmallThumbnail);
            books.ForEach(m => Books.Add(m.VolumeInfo));
        }

        private void BookDetail(object obj)
        {
            var book = ((BookModel)obj);
            Application.Current.MainPage.Navigation.PushModalAsync(new BookDetail(book: book), true);
        }

        private void RedirectToBookSearchPage(object obj)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new BookSearch(), true);

        }

        private void Search(object obj)
        {
            Books = new ObservableCollection<BookModel>();
            string query = SearchQuery;
            string clientUrl = _rootUrl + $"&q={query}";
            var books = new BookApiModel().GetBookFromGoogle(url: clientUrl);
            BookConfiguration(books: books);
            Application.Current.MainPage.Navigation.PushModalAsync(new BookList(books: Books), true);
        }
    }
}
