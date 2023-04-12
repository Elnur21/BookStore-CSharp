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
                    goto case Menu.AuthorDelete;
                case Menu.AuthorGetAll:
                    if (GetAllAuthors(true) == false)
                    {
                        goto case Menu.AuthorAdd;
                    }
                    ComeToWhere("Menuya qayitmaq ucun Her hansi duymeni sixin");
                    goto l1;
                case Menu.AuthorGetByID:
                    if (!GetAllAuthors(true))
                    {
                        goto case Menu.AuthorAdd;
                    }
                    selectedID = Helper.ReadUInt16("Muellif ID-i secin siayhidan");
                    selectedAuthor= authors.GetById(selectedID);
                    Helper.ChangeLineColor($"{selectedID}. {selectedAuthor.Name} {selectedAuthor.Surename} \n", Console.ForegroundColor, ConsoleColor.Magenta);
                    ComeToWhere("Menuya qayitmaq ucun Her hansi duymeni sixin");
                    goto l1;
                case Menu.AuthorGetByName:
                    if (!GetAllAuthors(true))
                    {
                        goto case Menu.AuthorAdd;
                    }
                    selectedName = Helper.ReadString("Muellifin adini secin siayhidan");
                    Author[] selectedAuthors = authors.GetAll(a => a.Name==selectedName);
                    foreach (var author in selectedAuthors)
                    {
                        Helper.ChangeLineColor($"{author.ID}. {author.Name} {author.Surename} \n", Console.ForegroundColor, ConsoleColor.Cyan);
                    }
                    ComeToWhere("Menuya qayitmaq ucun Her hansi duymeni sixin");
                    goto l1;
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