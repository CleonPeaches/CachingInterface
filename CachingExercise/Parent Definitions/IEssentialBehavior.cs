using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingExercise
{
    interface IEssentialBehavior
    {
     
        string SetKey();

        string GetValue();

        string DeleteKey();

        string RenameKey();

        string GetKeys();

        string DeleteAllKeys();

    }
}
