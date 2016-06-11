using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class TicTacToeEngine
    {
        public GameStatus Status { get; private set; }
        //Game state
        public enum GameStatus { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }

        public string[] spelbord = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        //String representatie van het bord
        public String Board()
        {
            String line = "-------------\n";
            return line + "| " + spelbord[0] + " | " + spelbord[1] + " | " + spelbord[2] + "|\n"
                + line + "| " + spelbord[3] + " | " + spelbord[4] + " | " + spelbord[5] + "|\n"
                + line + "| " + spelbord[6] + " | " + spelbord[7] + " | " + spelbord[8] + "|\n" + line;
        }

        //Welk hokje wordt gekozen
        public Boolean ChooseCell(int x)
        {
            x = x - 1;
            Boolean result = false;
            if (!Chosen(x))
            {
                if (Status == GameStatus.PlayerOPlays)
                {
                    spelbord[x] = "O";
                    if (!allChosen(spelbord))
                    {
                        if (!checkWin())
                        {
                            Status = GameStatus.PlayerXPlays;
                            result = true;
                        }
                    }
                    else
                    {
                        if (!checkWin())
                        {
                            Status = GameStatus.Equal;
                        }
                    }
                }
                else
                {
                    spelbord[x] = "X";
                    if (!allChosen(spelbord))
                    {
                        if (!checkWin())
                        {
                            Status = GameStatus.PlayerOPlays;
                            result = true;
                        }
                    }
                    else
                    {
                        if (!checkWin())
                        {
                            Status = GameStatus.Equal;
                        }
                    }
                }
            }
            else
            {
                if (!checkWin())
                {

                }
            }
            return result;
        }


        public Boolean Chosen(int x)
        {
            if (spelbord[x] == "X" || spelbord[x] == "O")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean allChosen(string[] array)
        {
            Boolean result = true;
            foreach (string s in spelbord)
            {
                if (!(s == "X" || s == "O"))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public Boolean checkWin()
        {
            if (checkWinner(0, 1, 2) ||
            checkWinner(3, 4, 5) ||
            checkWinner(6, 7, 8) ||
            checkWinner(0, 3, 6) ||
            checkWinner(1, 4, 7) ||
            checkWinner(2, 5, 8) ||
            checkWinner(0, 4, 8) ||
            checkWinner(2, 4, 6))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean checkWinner(int a, int b, int c)
        {
            Boolean result = false;
            if (spelbord[a] == spelbord[b] && spelbord[a] == spelbord[c])
            {
                if (spelbord[a] == "X")
                {
                    Status = GameStatus.PlayerXWins;
                    result = true;
                }
                else if (spelbord[a] == "O")
                {
                    Status = GameStatus.PlayerOWins;
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        //Reset
        public void Reset()
        {
            Status = GameStatus.PlayerOPlays;
            spelbord = new String[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        }
    }
}
