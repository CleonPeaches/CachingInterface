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

        public string SetKey()
        {
            string key, value, finalOutput;

            Console.WriteLine("Enter the name of your new key: ");
            key = Console.ReadLine();

            Console.WriteLine("Enter your new value: ");
            value = Console.ReadLine();

            finalOutput = (string)(this.setter + " " + key + " " + value);

            return finalOutput;
        }

        public string GetValue()
        {
            string key, finalOutput;

            Console.WriteLine("Enter the name of a key to get: ");
            key = Console.ReadLine();
            finalOutput = (string)(this.getter + " " + key);

            return finalOutput;
        }      

        public string DeleteKey()
        {
            string key, finalOutput;

            Console.WriteLine("Enter the name of a key to delete: ");
            key = Console.ReadLine();
            finalOutput = (string)(this.deleter + " " + key);

            return finalOutput;
        }

        public string RenameKey()
        {
            string oldKey, newKey, finalOutput;

            Console.WriteLine("Enter the name of the key you wish to change: ");
            oldKey = Console.ReadLine();

            Console.WriteLine("Enter the new name of the key: ");
            newKey = Console.ReadLine();
            finalOutput = (string)(this.renamer + " " + oldKey + " " + newKey);

            return finalOutput;

        }

        public string GetKeys()
        {
            string pattern, finalOutput;

            Console.WriteLine("Enter the pattern of keys you wish to view: ");
            pattern = Console.ReadLine();
            finalOutput = (string)(this.getterOfKeys + " " + pattern);

            return finalOutput;
        }

        public string DeleteAllKeys()
        {
            return this.deleterOfKeys;
        }

    }
}
