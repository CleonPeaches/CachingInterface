using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingExercise
{
    static class Utilities
    {

        public static void PrintIntro()
        {
            Console.WriteLine("This program provides a simple interface to interact with either Redis or " +
                              "Memcache. Press [Enter] to continue");
            Console.ReadLine();

        }

        public static void MainMenu()
        {
            while (true)
            {
                string selection;
                string[] validSelections = new string[] { "1", "2", "3" };

                do
                {
                    Console.WriteLine("Select a backend to use: [1] Redis\t[2] Memcached\t[3] Exit");
                    selection = Console.ReadLine();
                } while (!validSelections.Contains(selection));

            }

        }
                
    }
}
