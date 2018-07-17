using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingExercise
{
    interface IEssentialBehavior<T>
    {
     
        string setKey();

        string getValue();

        string deleteKey();

        string renameKey();

        string getKeys();

        string deleteAllKeys();

    }
}
