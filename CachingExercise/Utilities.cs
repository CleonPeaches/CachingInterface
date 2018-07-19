using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/**
 * Holds static methods used in Main.
 * 
 * @details 
 * 
 * @author Drew Engberson
 * 
 * @date 7/17/2018
 * 
 * @TODO Refactor SelectCache to accommodate additional back ends.
 * 
 */

namespace CachingExercise
{
    static class Utilities
    {

        public static void PrintIntro()
        {
            Console.WriteLine("REDIS WRAPPER\n\nThis is a simple interface for using Redis" +
                              " without worrying about syntax. \n\nPress [Enter] to continue");

            Console.ReadLine();

        }

        public static void MainMenu()
        {
            
            string selection;
            string[] validSelections = new string[] { "1", "2",};

            do
            {
                Console.WriteLine("Make a selection: [1] Redis\t[2] Exit");
                selection = Console.ReadLine();
            } while (!validSelections.Contains(selection));

            if(selection == "2")
            {
                Environment.Exit(0);
            }
            
        }
        //This method must be refactored to accommodate additional backends.
        public static void RedisLoop()
        {
            RedisWrapper redWrap = new RedisWrapper();
            System.Diagnostics.Process server = new System.Diagnostics.Process();
            System.Diagnostics.Process client = new System.Diagnostics.Process();

            server.StartInfo.Verb = "runas";
            server.StartInfo.FileName = "CMD.exe";
            server.StartInfo.Arguments = redWrap.openServerText;
            server.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            
            client.StartInfo.FileName = "CMD.exe";
            client.StartInfo.Arguments = redWrap.openClientText;
            client.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            client.StartInfo.RedirectStandardInput = true;
            client.StartInfo.RedirectStandardOutput = true;
            client.StartInfo.UseShellExecute = false;

            Console.WriteLine("\nOpening Redis server...\n");

            server.Start();
            /*
            try
            {
                server.Start();
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("No such file! Terminating...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            */
            client.Start();
            
            while (true)
            {
                string[] validSelections = new string[] { "1", "2", "3", "4", "5", "6", "7" };
                string selection, command, result;

                do
                {
                    Console.WriteLine("\nSelect an operation: \n\n[1] Set a key\n" +
                        "[2] Get a Value\n[3] Delete a Key\n[4] Rename a Key\n" +
                        "[5] Get all keys that match a pattern\n[6] Delete all keys\n" +
                        "[7] Exit to main menu\n");

                    selection = Console.ReadLine();

                } while (!validSelections.Contains(selection));

                switch (selection)
                {
                    case "1":
                        command = redWrap.SetKey();
                        client.StandardInput.WriteLine(command);
                        result = client.StandardOutput.ReadLine();
                        Console.WriteLine(result);
                        break;

                    default:
                        Console.WriteLine("poo");
                        break;
                }

            }

        }
                
    }
}
