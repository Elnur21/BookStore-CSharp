using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Helpers
{
    public static partial class Helper
    {
        public static int ReadInt(string caption)
        {
            int value;
            var color = Console.ForegroundColor;

        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = color;


            if (!int.TryParse(Console.ReadLine(), out value))
            {
                goto l1;
            }

            return value;
        }

        public static decimal ReadDecimal(string caption)
        {
            decimal value;
            var color = Console.ForegroundColor;

        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = color;


            if (!decimal.TryParse(Console.ReadLine(), out value))
            {
                goto l1;
            }

            return value;
        }

        public static ushort ReadUInt16(string caption)
        {
            ushort value;
            var color = Console.ForegroundColor;

        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = color;


            if (!ushort.TryParse(Console.ReadLine(), out value))
            {
                goto l1;
            }

            return value;
        }

        public static string ReadString(string caption)
        {
            string value;
            var color = Console.ForegroundColor;

        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = color;

            value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                goto l1;
            }

            return value;
        }



    }
}
