using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt0
{
    class Program
    {
        
        static void Main(string[] args)
        {
            RunGame();

            //string whatyoutyped;

            // Console.WriteLine("You are at the default cursor spot");
            // whatyoutyped = Console.ReadLine();
            //Console.WriteLine(whatyoutyped);

            //Console.Write("Cursor at position 0 , 0");
            //Console.ReadKey();

            //Console.SetCursorPosition(0, 40);
            //Console.Write("Cursor at position 0 , 40");
            //Console.ReadKey();
            //Console.SetCursorPosition (10, 20);
            //Console.Write("Cursor at position 10 , 20");
            //Console.ReadKey();

        }
        
        static void RunGame()
        {
            Game game = new Game();
            game.SystemResponse += new EventHandler (game_SystemResponse);

            string currentresponse;

            do
            {
                game.UserCommand(Console.ReadLine());
                currentresponse = game.Response();
                //Console.WriteLine(currentresponse);

            } while (currentresponse != "Quit");
        }

        static void game_SystemResponse(object sender, EventArgs e)
        {
           // if (e is ReponseEventArgs )
           // {
                ResponseEventArgs responseEventArgs = e as ResponseEventArgs ;
                if (responseEventArgs.Response != null)
                {         
                    Console.WriteLine(responseEventArgs.Response);
                }
            //}
        }
    }
}