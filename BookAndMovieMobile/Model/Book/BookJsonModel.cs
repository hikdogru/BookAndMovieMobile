using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.Book
{
    public class BookJsonModel
    {
        public int TotalItems { get; set; }
        public List<BookInfoModel> Items { get; set; }
    }
}
