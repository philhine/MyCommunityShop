namespace MyCommunityShop.App.Utility
{
    using System;
    using System.Linq;

    public static class ConsoleWriter
    {
        private const string Title = "Welcome to My Community Shop";

        public static void WriteLine(string content, bool addPreceedingLine = true)
        {
            if (addPreceedingLine)
            {
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine(content);
        }

        public static void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{error}");
#if DEBUG
            Console.WriteLine("Debug mode is on! Please check the api is running.");
#endif
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press press enter to continue");

            Console.ReadKey();
        }

        public static void WriteWarning(string warning)
        {
            Console.WriteLine(warning, ConsoleColor.Yellow);
        }

        public static void Reset()
        {
            var seperationLine = string.Concat(Enumerable.Repeat("=", 30));

            Console.Clear();
            Console.WriteLine(seperationLine);
            Console.WriteLine(Title);
            Console.WriteLine(seperationLine);
        }

        public static void WriteTitle(string title)
        {
            WriteLine(title);
            Console.Write(System.Environment.NewLine);
        }

        public static void WriteSeperationLine()
        {
            var seperationLine = string.Concat(Enumerable.Repeat("=", 30));
            Console.WriteLine(seperationLine);
        }

        public static void WriteCurrencyField(string fieldName, decimal fieldValue, int fieldNamePadding)
        {
            var tag = $"{fieldName}:";
            var line = $"{tag.PadRight(fieldNamePadding)} {fieldValue:C}";

            Console.WriteLine(line);
        }

    }
}
