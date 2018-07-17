using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
