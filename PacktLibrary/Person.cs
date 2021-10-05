using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Person : object
    {
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();
        public const string Species = "Homo Sapien";
        // Read only fields
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        // Constructor
        public Person()
        {
            // Set default values for fields, including read-only fields
            Name = "Unkown";
            Instantiated = DateTime.Now;
        }
        public Person(string initialName, string homePlanet)
        {
            // Set default values for fields, including read-only fields
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

    }
}
