using Final.Infrastructure;

namespace Final.DataModels
{
    public class Author: IEquatable<Author>, IEntity
    {
        static int counter = 0;
        public Author()
        {
            counter++;
            this.ID=counter;
        }
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surename { get; set; }

        public bool Equals(Author? other)
        {
            if (other == null) return false;
            return other.ID == this.ID;
        }
    }
}
