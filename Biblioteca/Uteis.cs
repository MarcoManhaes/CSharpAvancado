using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Biblioteca
{
    public static class Uteis
    {
        static int contador = 0;
        public static void ProcessaAguarde()
        {
            
            contador++;
            switch (contador % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Thread.Sleep(30);
        }
    }
}
