using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public partial class Person : object
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

        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }
        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}"; 
        }
        //Tuple

        public (string,int) GetFruit()
        {
            return ("Apples",5);
        }
        
        public (string Name,int Number) GetNamedFruit()
        {
            return (Name:"Apples",Number:5);
        }
         // Defining and passing parameters to method
        public string SayHello()
        {
            return $"{Name} say 'Hello!'";
        }
        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }
        public string OptionalParameters(
            string command ="Run!",
            double number = 0.0,
            bool active = true
        )
        {
            return string.Format(
                format:"command is {0}, number is {1}, active is {2}",
                arg0:command,
                arg1:number,
                arg2:active
            );
        }

        // Controlling how parameters are passed
        public void PassingParameters (int x ,ref int y, out int z)
        {
            //out parameters cannot have a default
            //And must be initialized inside the method
            z =99;
            // increment each parameter
            x++;
            y++;
            z++;
        }

        /* 
        New Chapter - Implementing Interfaces and Inheriting Classes 
        */

        // Static method to "multiply"
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }
        // Instant method to "multiply"
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }
        // Operator to "multiply"
        public static Person operator *(Person p1,Person p2)
        {
            return Person.Procreate(p1,p2);
        }
        
    }
}
