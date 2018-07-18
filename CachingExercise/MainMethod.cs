using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/**
 * MainMethod consists only of function calls for clarity.
 * 
 * @details
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

            System.Diagnostics.Process.Start("CMD.exe", "/C redis-server");
        }
    }
}
