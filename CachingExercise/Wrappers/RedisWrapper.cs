using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * RedisWrapper defines syntax and functionality specific to Redis.
 * 
 * @details The constructor sets the instance variables to their 
 * proper values for Redis commands. Each method returns a string,
 * which will be used as  command line argument in Utilites.
 * 
 * @author Drew Engberson
 * 
 * @date 7/18/2018
 * 
 */

namespace CachingExercise
{
    class RedisWrapper : GenericBackend, IEssentialBehavior
    {
        //Initializes wrapper object with Redis-specific syntax
        public RedisWrapper() {

            this.getter = "get";
            this.setter = "set";
            this.deleter = "del";
            this.renamer = "rename";
            this.getterOfKeys = "keys";
            this.deleterOfKeys = "flushall";
            this.openServerText = "/K redis-server C:\\Users\\drewe\\Downloads\\redis\\redis.windows.conf";
            this.openClientText = "/K redis-cli";
        }

        public string SetKey(string key, string value)
        {
            string finalOutput;

            

            finalOutput = (string)(this.setter + " " + key + " " + value);

            return finalOutput;
        }

        public string GetValue(string key)
        {
            string finalOutput;

            finalOutput = (string)(this.getter + " " + key);

            return finalOutput;
        }      

        public string DeleteKey(string key)
        {
            string finalOutput;

            finalOutput = (string)(this.deleter + " " + key);

            return finalOutput;
        }

        public string RenameKey(string oldKey, string newKey)
        {
            string finalOutput;
                        
            finalOutput = (string)(this.renamer + " " + oldKey + " " + newKey);

            return finalOutput;

        }

        public string GetKeys(string pattern)
        {
            string finalOutput;
            
            finalOutput = (string)(this.getterOfKeys + " " + pattern);

            return finalOutput;
        }

        public string DeleteAllKeys()
        {
            return this.deleterOfKeys;
        }

    }
}
