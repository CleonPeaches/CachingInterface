using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/**
 * MainMethod consists only of function calls for clarity.
 * 
 * @author Drew Engberson
 * 
 * @date 7/17/2018
 * 
 */

namespace CachingExercise
{
    class MainMethod
    {     
        static void Main(string[] args)
        {
            Utilities.PrintIntro();

            Utilities.MainMenu();

            Utilities.RedisLoop();

        }
    }
}
