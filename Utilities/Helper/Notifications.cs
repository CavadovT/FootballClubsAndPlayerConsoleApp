using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public  class Notifications
    {
        public static void Print( ConsoleColor color,string message) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();

        }
    }
}
