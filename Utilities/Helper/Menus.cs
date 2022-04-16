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
                $"\n" +

                $"+++++++++++++++++++++++\n" +
                $"\n" +

                $"5-Creat Club\n" +
                $"6-Get All Clubs\n" +
                $"7-Update Club\n" +
                $"8-Delete Club\n" +
                $"\n" +

                $"++++++++++++++++++++++\n" +
                $"\n" +

                $"9-Creat Player\n" +
                $"10-Get All Players\n" +
                $"11-Update Player\n" +
                $"12-Delete Player\n" +
                $"\n" +

                $"+++++++++++++++++++" +
                $"\n" +

                $"13-Add Club To Country\n" +
                $"14-Add Player To Club\n" +
                $"15-Transfer Player To Any Club\n" +
                $"0-Exit is Program\n");
        }
    }
}
