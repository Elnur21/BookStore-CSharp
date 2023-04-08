using Final.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final.DataModels
{
    internal class Book {
        int counter = 0;
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

    }
}
