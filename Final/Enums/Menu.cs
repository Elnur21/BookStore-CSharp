using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Enums
{
    public enum Menu: byte
    {
        AuthorAdd = 1,
        AuthorEdit,
        AuthorDelete,
        AuthorGetAll,
        AuthorGetByID,
        AuthorGetByName,

        BookAdd,
        BookEdit,
        BookDelete,
        BookGetAll,
        BookGetByID,
        BookGetByName,


        SaveAndExit
    }
}
