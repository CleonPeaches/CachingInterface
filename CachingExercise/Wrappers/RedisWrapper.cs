using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingExercise
{
    class RedisWrapper : GenericBackend, IEssentialBehavior
    {
        public string openServerText = "/C redis-server";
        public string openClientText = "/C redis-cli";

        //Initializes wrapper object with Redis-specific syntax
        public RedisWrapper() {

            this.getter = "get";
            this.setter = "set";
            this.deleter = "del";
            this.renamer = "rename";
            this.getterOfKeys = "keys";
            this.deleterOfKeys = "flushall";

        }

        public string SetKey()
        {
            string key, value;

            key = Console.ReadLine();
            value = Console.ReadLine();

            return key + " " + value;
        }

        public string GetValue()
        {
            string key;

            key = Console.ReadLine();

            return this.getter + key;
        }      

        public string DeleteKey()
        {
            string key;

            key = Console.ReadLine();

            return this.deleter + key;
        }

        public string RenameKey()
        {
            string oldKey, newKey;

            oldKey = Console.ReadLine();
            newKey = Console.ReadLine();

            return this.renamer + oldKey + newKey;

        }

        public string GetKeys()
        {
            string pattern;
            pattern = Console.ReadLine();

            return this.getterOfKeys + pattern;
        }

        public string DeleteAllKeys()
        {
            return this.deleterOfKeys;
        }

    }
}
