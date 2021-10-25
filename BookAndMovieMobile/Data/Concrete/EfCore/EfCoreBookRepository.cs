using BookAndMovieMobile.Data.Concrete.EfCore;
using BooksAndMovies.Data.Abstract;
using BooksAndMovies.Entity;

namespace BooksAndMovies.Data.Concrete.Ef
{
    public class EfCoreBookRepository : EfCoreEntityRepositoryBase<Book, BookAndMovieContext>, IBookRepository
    {
        public EfCoreBookRepository(BookAndMovieContext context) : base(context)
        {
        }
    }
}
