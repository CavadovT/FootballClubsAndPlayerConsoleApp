using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public class Chek
    {
        public static int NumTryPars() 
        {
            ERROR1:
            string str =Console.ReadLine();
            int num;
           bool IsNum=int.TryParse(str, out num);
            if (IsNum) 
            {
            return num=int.Parse(str);
            }
            else
            {
                Notifications.Print(ConsoleColor.Red, "Error: Enter the correctly");
                goto ERROR1;
            }
         
        }
        public static string StrNull() 
        {
            ERROR2:
            string str = Console.ReadLine();
            if (!string.IsNullOrEmpty(str)) 
            {
                return str;

            }
            else
            {
                Notifications.Print(ConsoleColor.Red, "Error: Doesn't Null or Empty!!! Please enter the correctly");
                goto ERROR2;
            }
        }

    }
}
