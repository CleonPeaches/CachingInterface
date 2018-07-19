using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Defines attributes for all wrapper subclasses to inherit.
 * 
 * @details Every wrapper will inherit these six attributes,
 * along with the six methods defined in IEssentialBehavior.
 * Additional attributes specific to a cache will be
 * defined by the subclasses.
 * 
 * @author Drew Engberson
 * 
 * @date 7/18/2018
 * 
 * TODO Determine which commands are ubiquitous across all
 * caches, and move the rest to the wrapper subclasses.
 * 
 */

namespace CachingExercise
{
    abstract class GenericBackend
    {
        public string getter;
        public string setter;
        public string deleter;
        public string renamer;
        public string getterOfKeys;
        public string deleterOfKeys;
        public string openServerText;
        public string openClientText;

    }
}
