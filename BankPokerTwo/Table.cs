using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPokerTwo
{
    class Table
    {
        public static double Pot { get; set; } = 0;
        public static int Turns { get; set; } = 0;
        public static int TableSize { get; set; }
        public static int DealerPos { get; set; }   
        public static int SmallPos { get; set; }
        public static int BigPos { get; set; }

        public static int LastRaisePos { get; set; }


        public static int PlayersTurn { get; set; }    

        public static int SmallBlindSize { get; set; } = 10;
        public static int BigBlindSize { get; set; } = 20;
        public static double CurrentAmmountRaised { get; set; } = BigBlindSize;


        public static string FlopFirst { get; set; }
        public static string FlopSecond { get; set; }
        public static string FlopThird { get; set; }
        public static string Turn { get; set; }
        public static string River { get; set; }

        public static void PlaceMarkers()
        {
            int dealerPos = 0;
            int sbPos = 0;
            int bbPos = 0;

            for (int j = 0; j < Player.players.Length; j++)
            {
                if (Player.players[j].IsDealer == true)
                {
                    dealerPos = j;
                    sbPos = j - 1;
                    bbPos = j - 2;
                    if (sbPos == -1)
                    {
                        sbPos = Player.players.Length - 1;
                        bbPos = sbPos - 1;
                    }
                    else if (sbPos == 0)
                    {
                        bbPos = Player.players.Length - 1;
                    }
                }
            }

            DealerPos = dealerPos;
            SmallPos = sbPos;
            BigPos = bbPos;
            Turns++;
            

        }

        public static void StartingPlayer()
        {
            int pos = 0;
            for (int i = 0; i < Player.players.Length; i++)
            {
                if (Player.players[i].IsDealer == true)
                {
                    pos = i - 3;
                    if (pos == -1)
                    {
                        pos = Player.players.Length - 1;
                    }
                    else if (pos == -2)
                    {
                        pos = Player.players.Length - 2;
                    }
                    else if (pos == -3)
                    {
                        pos = Player.players.Length - 3;
                    }
                }
            }
            PlayersTurn = pos;

        }
    }
}
