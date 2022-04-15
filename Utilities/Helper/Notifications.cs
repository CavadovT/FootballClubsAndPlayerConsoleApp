using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public  class Notifications
    {
        public void Print(ConsoleColor color1, ConsoleColor color,string message) 
        {
            Console.BackgroundColor = color1;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();

        }
    }
}
