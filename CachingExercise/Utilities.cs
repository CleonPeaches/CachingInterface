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
 * @date 7/18/2018
 * 
 * @TODO Refactor RedisLoop to accommodate additional back ends.
 * 
 */

namespace CachingExercise
{
    static class Utilities
    {

        public static void PrintIntro()
        {
            Console.WriteLine("REDIS WRAPPER\n\nThis is a simple interface for using Redis\n" +
                              "without needing to know proper command syntax. \n\nPress [Enter] to continue");

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
            client.Start();
            
            while (true)
            {
                string[] validSelections = new string[] { "1", "2", "3", "4", "5", "6", "7" };
                string selection, command, result;

                do
                {
                    Console.WriteLine("\nSelect an operation: \n\n[1] Set a key\n" +
                        "[2] Get a value\n[3] Delete a key\n[4] Rename a key\n" +
                        "[5] Get keys that match specified pattern\n[6] Delete all keys\n" +
                        "[7] Exit to main menu\n");

                    selection = Console.ReadLine();

                } while (!validSelections.Contains(selection));
                
                switch (selection)
                {
                    case "1":
                        CommandTransmitter(redWrap.SetKey(), client);
                        break;

                    case "2":
                        CommandTransmitter(redWrap.GetValue(), client);
                        break;

                    case "3":
                        CommandTransmitter(redWrap.DeleteKey(), client);
                        break;

                    case "4":
                        CommandTransmitter(redWrap.RenameKey(), client);
                        break;

                    case "5":
                        CommandTransmitter(redWrap.GetKeys(), client);
                        break;

                    case "6":
                        CommandTransmitter(redWrap.DeleteAllKeys(), client);
                        break;

                    default:
                        MainMenu();
                        break;
                }

            }

        }

        public static void CommandTransmitter(string command, System.Diagnostics.Process client)
        {
            string result;

            client.StandardInput.WriteLine(command);
            result = client.StandardOutput.ReadLine();
            Console.WriteLine("\n" + result);

        }

    }

}
