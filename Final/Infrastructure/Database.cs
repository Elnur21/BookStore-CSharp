using Final.DataModels;

namespace Final.Infrastructure
{
    [Serializable]
    public class Database
    {
        public Generic<Author> Authors { get; set; }
        public Generic<Book> Books { get; set; }
    }
}
