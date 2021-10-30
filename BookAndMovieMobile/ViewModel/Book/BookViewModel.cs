using BookAndMovieMobile.Model.Book;
using BookAndMovieMobile.View.Pages;
using BookAndMovieMobile.View.Pages.BookPages;
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
        public string ApiKey { get; set; } = "AIzaSyAWeKsrZKQlLMC2AaDxM1zRbLoBHoEMj8w";

        public ObservableCollection<BookModel> Books { get; set; }
        public string SearchQuery { get; set; }
        public ICommand BookDetailCommand => new Command(BookDetail);
        public ICommand BookSearchCommand => new Command(RedirectToBookSearchPage);
        public ICommand SearchCommand => new Command(Search);
        public ICommand GetFinishedlistCommand => new Command(GetFinishedlist);
        public ICommand GetFavouritelistCommand => new Command(GetFavouritelist);
        public ICommand GetWishlistCommand => new Command(GetWishlist);

        public ICommand AddBookWishlistCommand => new Command(AddBookWishlist);
        public ICommand AddBookFinishedlistCommand => new Command(AddBookFinishedlist);
        public ICommand AddBookFavouritelistCommand => new Command(AddBookFavouritelist);



        public ICommand MoveBookFinishedlistCommand => new Command(MoveBookFinishedlist);
        public ICommand DeleteBookFinishedlistCommand => new Command(DeleteBookFinishedlist);
        public ICommand DeleteBookFavouritelistCommand => new Command(DeleteBookFavouritelist);
        public ICommand DeleteBookWishlistCommand => new Command(DeleteBookWishlist);

        

        public BookViewModel()
        {
            //GetPopularBooks();
        }

        private void GetPopularBooks()
        {
            Books = new ObservableCollection<BookModel>();
            string clientUrl = _rootUrl + "&maxResults=20&q=flowers&orderBy=newest";
            var books = new BookApiModel().GetBookFromGoogle(url: clientUrl);
            BookConfiguration(books: books);
        }

        private ObservableCollection<BookModel> BookConfiguration(List<BookInfoModel> books)
        {
            Books = new ObservableCollection<BookModel>();

            if (books != null)
            {
                books.ForEach(x => x.VolumeInfo.Id = x.Id);
                books.ForEach(x => x.VolumeInfo.Thumbnail = x.VolumeInfo.ImageLinks?.Thumbnail);
                books.ForEach(x => x.VolumeInfo.SmallThumbnail = x.VolumeInfo.ImageLinks?.SmallThumbnail);
                books.ForEach(m => Books.Add(m.VolumeInfo));

            }
            return Books;
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

        private void GetFinishedlist(object obj)
        {
            string clientUrl = "https://www.googleapis.com/books/v1/mylibrary/bookshelves/4/volumes?key=AIzaSyAWeKsrZKQlLMC2AaDxM1zRbLoBHoEMj8w";
            var books = new BookApiModel().GetBookFromGoogle(url: clientUrl, method: RestSharp.Method.GET);
            var newBooks = BookConfiguration(books: books);
            RedirectToBookFinishedlistPage(books: newBooks);
        }

        private void GetFavouritelist(object obj)
        {
            string clientUrl = "https://www.googleapis.com/books/v1/mylibrary/bookshelves/0/volumes?key=AIzaSyAWeKsrZKQlLMC2AaDxM1zRbLoBHoEMj8w";
            var books = new BookApiModel().GetBookFromGoogle(url: clientUrl, method: RestSharp.Method.GET);
            var newBooks = BookConfiguration(books: books);
            RedirectToBookFavouritelistPage(books: newBooks);
        }

        private void GetWishlist(object obj)
        {
            string clientUrl = "https://www.googleapis.com/books/v1/mylibrary/bookshelves/2/volumes?key=AIzaSyAWeKsrZKQlLMC2AaDxM1zRbLoBHoEMj8w";
            var books = new BookApiModel().GetBookFromGoogle(url: clientUrl, method: RestSharp.Method.GET);
            var newBooks = BookConfiguration(books: books ?? null);
            RedirectToBookWishlistPage(books: newBooks);
        }

        private void AddBookWishlist(object obj)
        {
            var book = ((BookModel)obj);
            string clientUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/2/addVolume?volumeId={book.Id}&key={ApiKey}";
            var model = new BookApiModel();
            model.AddBookToGoogle(url: clientUrl, method: RestSharp.Method.POST);
        }

        private void AddBookFinishedlist(object obj)
        {
            var book = ((BookModel)obj);
            string clientUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/4/addVolume?volumeId={book.Id}&key={ApiKey}";
            var model = new BookApiModel();
            model.AddBookToGoogle(url: clientUrl, method: RestSharp.Method.POST);
        }

        private void AddBookFavouritelist(object obj)
        {
            var book = ((BookModel)obj);
            string clientUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/0/addVolume?volumeId={book.Id}&key={ApiKey}";
            var model = new BookApiModel();
            model.AddBookToGoogle(url: clientUrl, method: RestSharp.Method.POST);
        }

        private void MoveBookFinishedlist(object obj)
        {
            var book = ((BookModel)obj);
            string addUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/4/addVolume?volumeId={book.Id}&key={ApiKey}";
            string deleteUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/2/removeVolume?volumeId={book.Id}&key={ApiKey}";
            var model = new BookApiModel();
            model.AddBookToGoogle(url: addUrl, method: RestSharp.Method.POST);
            model.AddBookToGoogle(url: deleteUrl, method: RestSharp.Method.POST);
            GetWishlist(obj: new object());
        }

        private void DeleteBookFinishedlist(object obj)
        {
            var book = ((BookModel)obj);
            string clientUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/4/removeVolume?volumeId={book.Id}&key={ApiKey}";
            var model = new BookApiModel();
            model.AddBookToGoogle(url: clientUrl, method: RestSharp.Method.POST);
            GetFinishedlist(obj: new object());
        }

        private void DeleteBookFavouritelist(object obj)
        {
            var book = ((BookModel)obj);
            string clientUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/0/removeVolume?volumeId={book.Id}&key={ApiKey}";
            var model = new BookApiModel();
            model.AddBookToGoogle(url: clientUrl, method: RestSharp.Method.POST);
            GetFavouritelist(obj: new object());
        }

        private void DeleteBookWishlist(object obj)
        {
            var book = ((BookModel)obj);
            string clientUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/2/removeVolume?volumeId={book.Id}&key={ApiKey}";
            var model = new BookApiModel();
            model.AddBookToGoogle(url: clientUrl, method: RestSharp.Method.POST);
            GetWishlist(obj: new object());
        }

        private static void RedirectToBookFinishedlistPage(ObservableCollection<BookModel> books)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
            Application.Current.MainPage.Navigation.PushModalAsync(new BookFinishedlist(books: books), true);
        }

        private static void RedirectToBookFavouritelistPage(ObservableCollection<BookModel> books)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
            Application.Current.MainPage.Navigation.PushModalAsync(new BookFavouritelist(books: books), true);
        }

        private static void RedirectToBookWishlistPage(ObservableCollection<BookModel> books)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
            Application.Current.MainPage.Navigation.PushModalAsync(new BookWishlist(books: books), true);
        }
    }
}
