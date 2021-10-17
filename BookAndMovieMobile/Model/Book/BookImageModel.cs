namespace BookAndMovieMobile.Model.Book
{
    public class BookImageModel
    {
        private string _thumbnail;
        private string _smallThumbnail;
        public string Thumbnail
        {
            get => _thumbnail;
            set => _thumbnail = value.Replace("http", "https");
        }
        public string SmallThumbnail
        {
            get => _smallThumbnail;
            set => _smallThumbnail = value.Replace("http", "https");
        }
    }
}