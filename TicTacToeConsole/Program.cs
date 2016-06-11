using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    class Program
    {


        static void Display(TicTacToeEngine t)
        {
            Console.WriteLine("Type a number from 1-9, new or quit\n");
            Console.WriteLine("Status :" + t.Status + "\n");
            Console.WriteLine(t.Board());
        }
        
        private static Boolean IsInt(string value)
        {
            foreach (char c in value)
            {
                int i = (int)c;
                if((i > 57) || (i < 49))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            TicTacToeEngine t = new TicTacToeEngine();
            
            while (true)
            {
                if (!(t.Status == TicTacToeEngine.GameStatus.Equal || t.Status == TicTacToeEngine.GameStatus.PlayerOWins || t.Status == TicTacToeEngine.GameStatus.PlayerXWins))
                {
                    Display(t);
                    string input = Console.ReadLine();

                    if (input == "new")
                    {
                        t.Reset();
                        Console.Clear();
                    }
                    else if (IsInt(input))
                    {
                        t.ChooseCell(int.Parse(input));
                    }
                    else if (input == "quit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input\nType a number from 1-9, new or quit\n");
                    }
                }
                else
                {
                    if(t.Status == TicTacToeEngine.GameStatus.Equal)
                    {
                        Console.WriteLine("Nobody wins.\nPress enter to play again");
                    }
                    else if (t.Status == TicTacToeEngine.GameStatus.PlayerOWins)
                    {
                        Console.WriteLine("Player O wins. Congratulations\nPress enter to play again");
                    }
                    else if (t.Status == TicTacToeEngine.GameStatus.PlayerXWins)
                    {
                        Console.WriteLine("Player X wins. Congratulations\nPress enter to play again");
                    }
                    Console.ReadLine();
                    Console.Clear();
                    t.Reset();
                }
            }
            
        }
    }
}
