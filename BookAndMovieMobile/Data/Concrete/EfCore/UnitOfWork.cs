using BookAndMovieMobile.Data.Concrete.EfCore;
using BooksAndMovies.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndMovies.Data.Concrete.Ef
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookAndMovieContext _context;

        public UnitOfWork(BookAndMovieContext context)
        {
            _context = context;
        }

        private EfCoreBookRepository _bookRepository;
        private EfCoreMovieRepository _movieRepository;
        private EfCoreTVShowRepository _tvShowRepository;
        private EfCoreUserRepository _userRepository;
        private EfCoreUserMovieRepository _userMovieRepository;
        private EfCoreUserTVShowRepository _userTVShowRepository;
        private EfCoreUserBookRepository _userBookRepository;

        public IBookRepository Books => _bookRepository = _bookRepository ?? new EfCoreBookRepository(context: _context);
        public IMovieRepository Movies => _movieRepository = _movieRepository ?? new EfCoreMovieRepository(context: _context);
        public ITVShowRepository TVShows => _tvShowRepository = _tvShowRepository ?? new EfCoreTVShowRepository(context: _context);
        public IUserRepository Users => _userRepository = _userRepository ?? new EfCoreUserRepository(context: _context);
        public IUserMovieRepository UserMovies => _userMovieRepository = _userMovieRepository ?? new EfCoreUserMovieRepository(context: _context);
        public IUserTVShowRepository UserTVShows => _userTVShowRepository = _userTVShowRepository ?? new EfCoreUserTVShowRepository(context: _context);
        public IUserBookRepository UserBooks => _userBookRepository = _userBookRepository ?? new EfCoreUserBookRepository(context: _context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
