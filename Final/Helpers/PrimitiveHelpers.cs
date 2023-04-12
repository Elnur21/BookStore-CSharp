namespace Final.Helpers
{
    public static partial class Helper
    {
        public static void ChangeLineColor(string caption,ConsoleColor lastColor, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(caption);
            Console.ForegroundColor = lastColor;
        }
        public static int ReadInt(string caption)
        {
            int value;
            var color = Console.ForegroundColor;

        l1:
            ChangeLineColor(caption, color, ConsoleColor.Green);


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
            ChangeLineColor(caption, color, ConsoleColor.Green);


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
            ChangeLineColor(caption, color, ConsoleColor.Green);


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
            ChangeLineColor(caption,color, ConsoleColor.Green);

            value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                goto l1;
            }

            return value;
        }



    }
}
