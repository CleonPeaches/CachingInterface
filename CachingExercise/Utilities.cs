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
                string selection, key, value, pattern, oldKey, newKey = "";

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
                        Console.WriteLine("Enter name of new key: ");
                        key = Console.ReadLine();

                        Console.WriteLine("Enter new value: ");
                        value = Console.ReadLine();

                        CommandTransmitter(redWrap.SetKey(key, value), client);

                        break;

                    case "2":
                        Console.WriteLine("Enter the name of a key to get: ");
                        key = Console.ReadLine();

                        CommandTransmitter(redWrap.GetValue(key), client);

                        break;

                    case "3":
                        Console.WriteLine("Enter the name of a key to delete: ");
                        key = Console.ReadLine();

                        CommandTransmitter(redWrap.DeleteKey(key), client);

                        break;

                    case "4":
                        Console.WriteLine("Enter the name of the key you wish to change: ");
                        oldKey = Console.ReadLine();

                        Console.WriteLine("Enter the new name of the key: ");
                        newKey = Console.ReadLine();

                        CommandTransmitter(redWrap.RenameKey(oldKey, newKey), client);

                        break;

                    case "5":

                        Console.WriteLine("Enter the pattern of keys you wish to view: ");
                        pattern = Console.ReadLine();

                        CommandTransmitter(redWrap.GetKeys(pattern), client);

                        break;

                    case "6":
                        CommandTransmitter(redWrap.DeleteAllKeys(), client);
                        Console.WriteLine("All keys deleted.");
                        break;

                    default:
                        MainMenu();
                        break;
                }

            }

        }

        public static void CommandTransmitter(string command, System.Diagnostics.Process client)
        {
            client.StandardInput.WriteLine(command);
            Console.WriteLine("\n" + client.StandardOutput.ReadLine());

        }

    }

}
