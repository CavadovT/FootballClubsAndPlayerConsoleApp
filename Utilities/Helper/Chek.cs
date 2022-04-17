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
            if (!IsNum) 
            {
                Notifications.Print(ConsoleColor.Red, "Error: Enter the correctly");
                goto ERROR1;  
            }
            else 
            {
                num = int.Parse(str);
                if (num <0) 
                {
                    Notifications.Print(ConsoleColor.Red, "Error: doesn't minus ");
                    goto ERROR1;
                }
                return num; 
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
