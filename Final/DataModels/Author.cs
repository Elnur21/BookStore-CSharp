using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DataModels
{
    internal class Author
    {
        int counter = 0;
        public Author()
        {
            counter++;
            this.ID = counter;
        }
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        
        
    }
}
