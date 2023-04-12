using Final.DataModels;
using Final.Enums;
using Final.Helpers;
using Final.Infrastructure;

namespace Final
{
    internal class Program
    {
        static Generic<Book> books = new Generic<Book>();
        static Generic<Author> authors = new Generic<Author>();


        static void Main(string[] args)
        {
            Menu m;
            int selectedID;
            string selectedName;
            Author selectedAuthor;
            Book selectedBook;
        l1:
            m = Helper.ReadEnum<Menu>("Siyahidan secin: ");
            switch (m)
            {
                case Menu.AuthorAdd:
                    Console.WriteLine("Elave etmek istediyiniz muellifin melumatlarini daxil edin: ");
                    selectedAuthor = new Author();
                    selectedAuthor.Name = Helper.ReadString("Muellifin adini daxil edin: ");
                    selectedAuthor.Surename = Helper.ReadString("Muellifin soyadini daxil edin: ");
                    authors.Add(selectedAuthor);
                    Console.Clear();
                    Helper.ChangeLineColor("Muellif ugurla elave olundu. \n", Console.ForegroundColor, ConsoleColor.Blue);
                    ComeToWhere("Butun muellifleri gormek ucun istenilen bir duymeni sixin");
                    goto case Menu.AuthorGetAll;
                case Menu.AuthorEdit:
                    if (GetAllAuthors(true) == false)
                    {
                        goto case Menu.AuthorAdd;
                    }
                    selectedID = Helper.ReadUInt16("Duzeltme edeceyiniz muellifin ID-ni secin siyahidan: ");
                    selectedAuthor=authors.GetById(selectedID);
                    if (selectedAuthor == null)
                    {
                        goto case Menu.AuthorEdit;
                    }
                    Helper.ChangeLineColor($"Evvelki ad: {selectedAuthor.Name} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedAuthor.Name = Helper.ReadString("Muellifin adi: ");
                    Helper.ChangeLineColor($"Evvelki soyad: {selectedAuthor.Surename} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedAuthor.Surename = Helper.ReadString("Muellifin soyadi: ");
                    Console.Clear();
                    Helper.ChangeLineColor($"{selectedID} bu ID-li muellif ugurla yenilendi. \n", Console.ForegroundColor, ConsoleColor.Blue);
                    goto case Menu.AuthorGetAll;
                case Menu.AuthorDelete:
                    if (GetAllAuthors(true) == false)
                    {
                        goto case Menu.AuthorAdd;
                    }
                    selectedID = Helper.ReadUInt16("Silmek istediyiniz muellifin ID-ni secin siyahidan: ");
                    selectedAuthor = authors.GetById(selectedID);
                    Helper.ChangeLineColor($"{selectedID}. {selectedAuthor.Name} {selectedAuthor.Surename} silindi \n", Console.ForegroundColor, ConsoleColor.Red);
                    authors.Remove(selectedAuthor);
                    ComeToWhere("Butun siyahini gormek ucun her hansi duymeni sixin...");
                    goto case Menu.AuthorGetAll;
                case Menu.AuthorGetAll:
                    if (GetAllAuthors(true) == false)
                    {
                        goto case Menu.AuthorAdd;
                    }
                menu:
                    ComeToWhere("Menuya qayitmaq ucun Her hansi duymeni sixin");
                    goto l1;
                case Menu.AuthorGetByID:
                    if (!GetAllAuthors(true))
                    {
                        goto case Menu.AuthorAdd;
                    }
                    selectedID = Helper.ReadUInt16("Muellif ID-i secin siayhidan: ");
                    selectedAuthor= authors.GetById(selectedID);
                    Helper.ChangeLineColor($"{selectedID}. {selectedAuthor.Name} {selectedAuthor.Surename} \n", Console.ForegroundColor, ConsoleColor.Magenta);
                    goto menu;
                case Menu.AuthorGetByName:
                    if (!GetAllAuthors(true))
                    {
                        goto case Menu.AuthorAdd;
                    }
                    selectedName = Helper.ReadString("Muellifin adini secin siayhidan: ");
                    Author[] selectedAuthors = authors.GetAll(a => a.Name==selectedName);
                    foreach (var author in selectedAuthors)
                    {
                        Helper.ChangeLineColor($"{author.ID}. {author.Name} {author.Surename} \n", Console.ForegroundColor, ConsoleColor.Cyan);
                    }
                    goto menu;
                case Menu.BookAdd:
                    Console.WriteLine("Elave etmek istediyiniz kitabin melumatlarini daxil edin: ");
                    selectedBook = new Book();
                    selectedBook.Name = Helper.ReadString("Kitabin adini daxil edin: ");
                    selectedBook.Genre = Helper.ReadEnum<BookGenres>("Kitab janrlarindan 1-i secin: ");
                    selectedBook.Price = Helper.ReadDecimal("Kitabin qiymetini daxil edin: ");
                    selectedBook.PageCount = Helper.ReadInt("Seife sayini daxil edin: ");
                    
                    selectedBook.AuthorID = DefineAuthor();
                    books.Add(selectedBook);
                    Console.Clear();
                    Helper.ChangeLineColor("Kitab ugurla elave olundu. \n", Console.ForegroundColor, ConsoleColor.Blue);
                    ComeToWhere("Butun kitablari gormek ucun istenilen bir duymeni sixin");
                    goto case Menu.BookGetAll;
                case Menu.BookEdit:
                    if (GetAllBooks(true) == false) goto case Menu.BookAdd;
                    selectedID = Helper.ReadUInt16("Duzeltme edeceyiniz kitabin ID-i secin siyahidan: ");
                    selectedBook = books.GetById(selectedID);
                    if (selectedBook == null) goto case Menu.BookEdit;
                    Helper.ChangeLineColor($"Evvelki ad: {selectedBook.Name} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedBook.Name = Helper.ReadString("Kitabin adi: ");
                    Helper.ChangeLineColor($"Evvelki janr: {selectedBook.Genre} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedBook.Genre = Helper.ReadEnum<BookGenres>("Janrlardan 1-i secin: ");
                    Helper.ChangeLineColor($"Evvelki qiymet: {selectedBook.Price} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedBook.Price = Helper.ReadDecimal("Yeni qiymet: ");
                    Helper.ChangeLineColor($"Evvelki sehife sayi: {selectedBook.PageCount} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedBook.PageCount = Helper.ReadInt("Yeni sehife sayi: ");

                    Helper.ChangeLineColor($"Evvelki muellif: {authors.GetById(selectedBook.AuthorID).Name} {authors.GetById(selectedBook.AuthorID).Surename} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedBook.AuthorID = DefineAuthor();

                    Console.Clear();
                    Helper.ChangeLineColor($"{selectedID} bu ID-li muellif ugurla yenilendi. \n", Console.ForegroundColor, ConsoleColor.Blue);
                    goto case Menu.BookGetAll;
                case Menu.BookDelete:
                    if (GetAllBooks(true) == false)
                    {
                        goto case Menu.BookAdd;
                    }
                    selectedID = Helper.ReadUInt16("Silmek istediyiniz kitabin ID-ni secin siyahidan: ");
                    selectedBook = books.GetById(selectedID);
                    Helper.ChangeLineColor($"{selectedID}. {selectedBook.Name} silindi \n", Console.ForegroundColor, ConsoleColor.Red);
                    books.Remove(selectedBook);
                    ComeToWhere("Butun siyahini gormek ucun her hansi duymeni sixin...");
                    goto case Menu.BookGetAll;
                case Menu.BookGetAll:
                    if (!GetAllBooks(true))
                    {
                        goto case Menu.BookAdd;
                    }
                    goto menu;
                case Menu.BookGetByID:
                    if (!GetAllBooks(true))
                    {
                        goto case Menu.BookAdd;
                    }
                    selectedID = Helper.ReadUInt16("Kitab ID-i secin siayhidan: ");
                    selectedBook = books.GetById(selectedID);
                    Helper.ChangeLineColor($"{selectedID}. {selectedBook.Name} \n", Console.ForegroundColor, ConsoleColor.Magenta);
                    goto menu;
                case Menu.BookGetByName:
                    if (!GetAllAuthors(true))
                    {
                        goto case Menu.BookAdd;
                    }
                    selectedName = Helper.ReadString("Muellifin adini secin siayhidan: ");
                    Book[] selectedBooks = books.GetAll(b => b.Name == selectedName);
                    foreach (var book in selectedBooks)
                    {
                        Helper.ChangeLineColor($"{book.ID}. {book.Name} \n  Janri: {book.Genre} \n Qiymeti: {book.Price} \n Sehife sayi: {book.PageCount}", Console.ForegroundColor, ConsoleColor.DarkCyan);
                    }
                    goto menu;
                case Menu.SaveAndExit:
                    break;
                default:
                    break;
            }
        }

        private static int DefineAuthor()
        {
            GetAllAuthors();
        l1:
            var authorID = Helper.ReadInt("Muellif idsini siyahidan secin: ");
            Author author = authors.GetById(authorID);
            if (author == null)
            {
                goto l1;
            }
            return authorID;
        }

        private static void ComeToWhere(string expalin)
        {
            Console.Write(expalin);
            Console.ReadKey();
            Console.Clear();
        }

        private static bool GetAllAuthors(bool clearBefore=false)
        {
            if (authors.Length == 0)
            {
                Helper.ChangeLineColor("Muellif yoxdur, siyahi bosdur. \n", Console.ForegroundColor, ConsoleColor.Red);
                return false;
            }
            if (clearBefore==true)
            {
                Console.Clear();
            }
            Console.WriteLine("Butun muellifler: ");
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.ID}. {author.Name} {author.Surename}");
            }
            return true;
        }
        private static bool GetAllBooks(bool clearBefore=false)
        {
            if (books.Length == 0)
            {
                Helper.ChangeLineColor("Kitab yoxdur, siyahi bosdur. \n", Console.ForegroundColor, ConsoleColor.Red);
                return false;
            }
            if (clearBefore == true)
            {
                Console.Clear();
            }
            Console.WriteLine("Butun Kitablar: ");
            foreach (var author in authors)
            {
                Console.WriteLine($">> {author.Name}");
                foreach (var book in books.GetAll(b=>b.AuthorID==author.ID))
                {
                    Console.WriteLine($"{book.ID}. {book.Name} \n  Janri: {book.Genre} \n Qiymeti: {book.Price} \n Sehife sayi: {book.PageCount}");
                    Console.WriteLine("---------------------------");
                }
                Console.WriteLine("===========================");
            }
            return true;
        }
    }
}