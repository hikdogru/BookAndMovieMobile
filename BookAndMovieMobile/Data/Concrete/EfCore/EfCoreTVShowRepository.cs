using BookAndMovieMobile.Data.Concrete.EfCore;
using BooksAndMovies.Data.Abstract;
using BooksAndMovies.Entity;

namespace BooksAndMovies.Data.Concrete.Ef
{
    public class EfCoreTVShowRepository : EfCoreEntityRepositoryBase<TVShow, BookAndMovieContext> , ITVShowRepository
    {
        public EfCoreTVShowRepository(BookAndMovieContext context) : base(context: context)
        {

        }

    }
}
