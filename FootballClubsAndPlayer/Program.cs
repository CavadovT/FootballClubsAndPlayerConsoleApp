using FootballClubsAndPlayer.Controllers;
using System;
using Utilities.Helper;

namespace FootballClubsAndPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FootballPlayerController playercontrol = new FootballPlayerController();
            CountryController countrycontroller = new CountryController();
            ClubController clubcontroller = new ClubController();
            do
            {
            /*
               $"1-Creat Country\n" +
            $"2-Get ALl Country\n" +
            $"3-Update Countr\n" +
            $"4-Delete Country\n" +
            $"5-Creat Club\n" +
            $"6-Add Club To Country\n" +
            $"7-Delete Club\n" +
            $"8-Update Club\n" +
            $"9-Get All Clubs\n" +
            $"10-Creat Player\n" +
            $"11-Get All Players\n" +
            $"12-Add Player To Club\n" +
            $"13-Transfer Player To Any Club\n" +
            $"14-Update Player\n" +
            $"15-Delete Player\n" +
            $"0-Exit is Program\n");
             */
            E1:
                Menus.Menu();
                int input = Chek.NumTryPars();
                if (input >= 0 || input <= 15)
                {

                    switch (input)
                    {
                        case (int)Enums.Menu.Quit:
                            return;

                        case (int)Enums.Menu.CretaCountry:
                            Console.Clear();
                            countrycontroller.CreatCountry();
                            break;

                        case (int)Enums.Menu.GetAllCountry:
                            Console.Clear();
                            countrycontroller.GetCountry();
                            break;

                        case (int)Enums.Menu.UpdateCountr:
                            Console.Clear();
                            countrycontroller.

                        case (int)Enums.Menu.CreatClub:
                            Console.Clear();
                            clubcontroller.CreatClub();
                            break;

                        case (int)Enums.Menu.GetClubs:
                            Console.Clear();
                            clubcontroller.GetClubs();
                            break;

                        case (int)Enums.Menu.AddClubToCountry:
                            Console.Clear();
                            countrycontroller.AddClubToCountry();
                            break ;
                    }
                }
                else
                {
                    Notifications.Print(ConsoleColor.Red, "Change the correctly at menyu");
                    goto E1;
                }

            } while (true);

        }
    }
}
