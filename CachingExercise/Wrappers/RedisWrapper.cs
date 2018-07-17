using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingExercise
{
    class RedisWrapper : GenericBackend, IEssentialBehavior<RedisWrapper>
    {
       
        //Initializes wrapper object with Redis-specific syntax
        public RedisWrapper() {

            this.getter = "get";
            this.setter = "set";
            this.deleter = "del";
            this.renamer = "rename";
            this.getterOfKeys = "keys";
            this.deleterOfKeys = "flushall";

        }

        public string setKey()
        {
            string key, value;

            key = Console.ReadLine();
            value = Console.ReadLine();

            return key + " " + value;
        }

        public string getValue()
        {
            string key;

            key = Console.ReadLine();

            return this.getter + key;
        }      

        public string deleteKey()
        {
            string key;

            key = Console.ReadLine();

            return this.deleter + key;
        }

        public string renameKey()
        {
            string oldKey, newKey;

            oldKey = Console.ReadLine();
            newKey = Console.ReadLine();

            return this.renamer + oldKey + newKey;

        }

        public string getKeys()
        {
            string pattern;
            pattern = Console.ReadLine();

            return this.getterOfKeys + pattern;
        }

        public string deleteAllKeys()
        {
            return this.deleterOfKeys;
        }

    }
}
