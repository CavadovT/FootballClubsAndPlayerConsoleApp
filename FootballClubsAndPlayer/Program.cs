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
            Notifications.Print(ConsoleColor.Blue, "===WELCOME===");
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

                        case (int)Enums.Menu.UpdateCountr:
                            Console.Clear();
                            countrycontroller.UpdateCountry();
                            break;

                        case (int)Enums.Menu.DeletCountry:
                            Console.Clear();
                            countrycontroller.DeleteCountry();
                            break;

                        case (int)Enums.Menu.CreatClub:
                            Console.Clear();
                            clubcontroller.CreatClub();
                            break;

                        case (int)Enums.Menu.AddClubToCountry:
                            Console.Clear();
                            countrycontroller.AddClubToCountry();
                            break;

                        case (int)Enums.Menu.GetClubs:
                            Console.Clear();
                            clubcontroller.GetClubs();
                            break;

                        case (int)Enums.Menu.UpdateClub:
                            Console.Clear();
                            clubcontroller.UpdateClub();
                            break;

                        case (int)Enums.Menu.DeleteClub:
                            Console.Clear();
                            clubcontroller.DeleteClub();
                            break;

                        case (int)Enums.Menu.AddPlayerToClub:
                            Console.Clear();
                            clubcontroller.AddPlayerToClub();
                            break;

                        case (int)Enums.Menu.TransferPlayerToAnyClub:
                            Console.Clear();
                            clubcontroller.TransferPlayerToAnyClub();
                            break;

                        case (int)Enums.Menu.CreatPlayer:
                            Console.Clear();
                            playercontrol.CreatPlayer();
                            break;

                        case (int)Enums.Menu.GetAllPlayers:
                            Console.Clear();
                            playercontrol.GetPlayer();
                            break;

                        case (int)Enums.Menu.UpdatePlayer:
                            Console.Clear();
                            playercontrol.UpdatePlayer();
                            break;

                        case (int)Enums.Menu.DeletePlayer:
                            Console.Clear();
                            playercontrol.DeletePlayer();
                            break;

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
