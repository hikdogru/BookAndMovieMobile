using BooksAndMovies.Entity;
using BooksAndMovies.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndMovies.Data.Abstract
{
    public interface IBookRepository : IEntityRepository<Book>
    {
    }
}
