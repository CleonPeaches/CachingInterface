using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Defines essential behavior of a cache.
 * 
 * @details Every wrapper subclass will inherit from this interface,
 * along with GenericBackend, and be compelled to implement these six methods.
 * 
 * @author Drew Engberson
 * 
 * @date 7/18/2018
 * 
 * @TODO Determine which of these methods is ubiquitous across all
 * caches. All other methods will be defined in the subclasses.
 * 
 */

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
