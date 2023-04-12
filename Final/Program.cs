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
                    l2:
                    if (GetAllAuthors(true) == false)
                    {
                        goto case Menu.AuthorAdd;
                    }
                    selectedID = Helper.ReadInt("Duzeltme edeceyiniz muellifin ID-ni secin siyahidan: ");
                    selectedAuthor=authors.GetById(selectedID);
                    if (selectedAuthor == null)
                    {
                        goto l2;
                    }
                    Helper.ChangeLineColor($"Evvelki ad: {selectedAuthor.Name} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedAuthor.Name = Helper.ReadString("Muellifin adi: ");
                    Helper.ChangeLineColor($"Evvelki soyad: {selectedAuthor.Surename} \n", Console.ForegroundColor, ConsoleColor.Yellow);
                    selectedAuthor.Surename = Helper.ReadString("Muellifin soyadi: ");
                    Console.Clear();
                    Helper.ChangeLineColor($"{selectedID} bu ID-li muellif ugurla yenilendi. \n", Console.ForegroundColor, ConsoleColor.Blue);
                    goto case Menu.AuthorGetAll;
                case Menu.AuthorDelete:
                    break;
                case Menu.AuthorGetAll:
                    if (GetAllAuthors(true) == false)
                    {
                        goto case Menu.AuthorAdd;
                    }
                    ComeToWhere("Menuya qayitmaq ucun Her hansi duymeni sixin");
                    goto l1;

                case Menu.AuthorGetByID:
                    break;
                case Menu.AuthorGetByName:
                    break;
                case Menu.BookAdd:
                    break;
                case Menu.BookEdit:
                    break;
                case Menu.BookDelete:
                    break;
                case Menu.BookGetAll:
                    break;
                case Menu.BookGetByID:
                    break;
                case Menu.BookGetByName:
                    break;
                case Menu.SaveAndExit:
                    break;
                default:
                    break;
            }
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
    }
}