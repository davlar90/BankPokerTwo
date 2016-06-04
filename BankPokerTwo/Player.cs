using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPokerTwo
{
    class Player
    {
        public string FirstCard { get; set; }
        public string SecondCard { get; set; }

        public bool HaveFolded { get; set; }
        public bool IsPlayerTurn { get; set; }

        public int TablePosition { get; set; }
        public double Chips { get; set; } = 10000;

        public string UserName { get; set; }
        public int PlayerID { get; set; }

        public bool IsDealer { get; set; }
        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }

        public static Player[] players = new Player[0];
        

        public static void AddPlayers(string userName)
        {
            Player[] tempArray = new Player[players.Length + 1];
            for (int i = 0; i < players.Length; i++)
            {
                tempArray[i] = players[i];
            }

            Player p = new Player();
            p.UserName = userName;
            p.PlayerID = players.Length + 1;
            p.TablePosition = players.Length;
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] == null)
                {
                    tempArray[i] = p;
                    players = tempArray;

                }
                else if(players[i] != null)
                {
                    
                }
            }

        }

        public static void GiveTurnToNextPlayer()
        {
            players[Table.PlayersTurn].IsPlayerTurn = false;
            TurnMade();
            players[Table.PlayersTurn].IsPlayerTurn = true;

            int turn = Table.PlayersTurn + 1;
            if (turn == players.Length) turn = 0;
            if (Table.LastRaisePos == turn)
            {
                Dealer.DealFlop();
            }

        }

        public  static void PlayerMoveBet(int pos, double raiseAmmount)
        {
            if ((raiseAmmount >= Table.BigBlindSize) && (raiseAmmount <= Player.players[pos].Chips))
            {
                Table.Pot = Table.Pot + raiseAmmount;
                players[pos].Chips = players[pos].Chips - raiseAmmount;

                Table.CurrentAmmountRaised = raiseAmmount;
                GiveTurnToNextPlayer();

                Table.LastRaisePos = pos;
            }
            else System.Windows.Forms.MessageBox.Show("Invalid bet ammount.");



        }
        public static void TurnMade()
        {

            Table.PlayersTurn--;
            if (Table.PlayersTurn == -1) Table.PlayersTurn = Player.players.Length - 1;
        }

        public static void PlayerMoveFold(int pos)
        {
            players[pos].HaveFolded = true;

            GiveTurnToNextPlayer();
            
        }

        public static void PlayerMoveCall(int pos)
        {
            if (players[pos].Chips >= Table.CurrentAmmountRaised)
            {
                Table.Pot = Table.Pot + Table.CurrentAmmountRaised;
                players[pos].Chips = players[pos].Chips - Table.CurrentAmmountRaised;
            }
            GiveTurnToNextPlayer();
        }
        public static void PlayerMoveReRaise(int pos, double raiseAmmount)
        {
            raiseAmmount = raiseAmmount + Table.CurrentAmmountRaised;
            if (raiseAmmount <= players[pos].Chips)
            {
                Table.Pot = Table.Pot + raiseAmmount;
                players[pos].Chips = players[pos].Chips - raiseAmmount;
                Table.CurrentAmmountRaised = raiseAmmount;
            }
            GiveTurnToNextPlayer();
        }

        public static void SetPlayerBlinds()
        {
            players[Table.SmallPos].IsSmallBlind = true;
            players[Table.BigPos].IsBigBlind = true;
        }

        public static void PayBlinds()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].IsSmallBlind == true)
                {
                    int blind = Table.SmallBlindSize;
                    Table.Pot = Table.Pot + blind;
                    players[i].Chips = players[i].Chips - blind;
                }
                if (players[i].IsBigBlind == true)
                {
                    int blind = Table.BigBlindSize;
                    Table.Pot = Table.Pot + blind;
                    players[i].Chips = players[i].Chips - blind;
                }

            }
        }
        public static void PlayerMoveAllIn(int pos)
        {
            GiveTurnToNextPlayer();
        }

    }
}
