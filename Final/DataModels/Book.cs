using Final.Enums;
using Final.Infrastructure;

namespace Final.DataModels
{
    public class Book: IEquatable<Book>, IEntity
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.ID= counter;
        }

        
        public int ID { get; private set; }
        public string Name { get; set; }
        public int AuthorID { get; set; }
        public BookGenres Genre { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }

        public bool Equals(Book? other)
        {
            if(other == null) return false;
            return other.ID == this.ID;
        }
    }
}
