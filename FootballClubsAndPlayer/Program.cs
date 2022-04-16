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
