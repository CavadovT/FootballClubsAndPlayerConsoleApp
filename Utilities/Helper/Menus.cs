using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public class Menus
    {
        public static void Menu() 
        {
            Notifications.Print(ConsoleColor.Green,
                $"\n1-Creat Country\n" +
                $"2-Get ALl Country\n" +
                $"3-Update Countr\n" +
                $"4-Delete Country\n" +
                $"5-Add Club To Country\n" +
                $"\n" +

                $"+++++++++++++++++++++++\n" +
                $"\n" +

                $"6-Creat Club\n" +
                $"7-Get All Clubs\n" +
                $"8-Update Club\n" +
                $"9-Delete Club\n" +
                $"\n" +

                $"++++++++++++++++++++++\n" +
                $"\n" +

                $"10-Creat Player\n" +
                $"11-Get All Players\n" +
                $"12-Update Player\n" +
                $"13-Delete Player\n" +
                $"\n" +

                $"+++++++++++++++++++" +
                $"\n" +

           
                $"14-Add Player To Club\n" +
                $"15-Transfer Player To Any Club\n" +
                $"0-Exit is Program\n");
        }
    }
}
