using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CachingExercise
{
    class CachingExercise
    {     
        static void printIntro()
        {
            Console.WriteLine("This program is a Redis wrpper that allows the " +
                               "user to interact with the database indirectly.");
        }

        static void Main(string[] args)
        {
            string openServerText = "/C redis-server";
            string openClientText = "/C redis-cli";
            System.Diagnostics.Process.Start("CMD.exe", "/C redis-server");
        }
    }
}
