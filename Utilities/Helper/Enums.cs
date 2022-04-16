using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public class Enums
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
        public enum Menu 
        {
            CretaCountry=1, GetAllCountry,UpdateCountr, DeletCountry,CreatClub,AddClubToCountry,DeleteClub,UpdateClub,GetClubs,CreatPlayer,
            GetAllPlayers,AddPlayerToClub,TransferPlayerToAnyClub,UpdatePlayer,DeletePlayer,Quit=0
        }
    }
}
