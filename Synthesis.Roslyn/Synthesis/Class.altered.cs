namespace Playground
{
    using System;
    using static System.Console;
    
    [Obsolete("Use Klasa instead")]    
    public static class klasa
    {
        public static string Upper(string s)
        {
            string aux = s.ToUpper();
            return aux;
        }

        public static int Count(string s)
        {
            int length = s.Length;
            return length;
        }

        public static void Main()
        {
            string upper = Upper(@"Mierzejewski, Krzysztof");
            Write($"{upper} = {Count(upper)}");
        }

        private static void Log(string str)
        {
            ConsoleColor aux = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine(str);
            ForegroundColor = aux;
        }
    }

    [Obsolete("Use Testowa instead")]
    class testowa
    {

    }
    
    [Obsolete("Use Nowa instead")]    
    class nowa
    {

    }
}

