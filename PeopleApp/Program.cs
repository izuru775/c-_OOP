using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine(
                format: "{0} was born on {1:dddd, d MMMM yyyy}",
                arg0: bob.Name,
                arg1: bob.DateOfBirth);

            WriteLine();
            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine(
                format: "{0} was born on {1:dd MMM yy}",
                arg0: alice.Name,
                arg1: alice.DateOfBirth);

            WriteLine();
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine(
                format: "{0}'s favorite wonder is {1}. Its integer is {2}",
                arg0: bob.Name,
                arg1: bob.FavoriteAncientWonder,
                arg2: (int)bob.FavoriteAncientWonder
            );

            WriteLine();
            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
            | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            WriteLine();
            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe" });
            WriteLine($"{bob.Name} has {bob.Children.Count} children:");

            foreach (var child in bob.Children)
            {
                WriteLine($"{child.Name}");
            }

            WriteLine();
            BankAccount.InterestRate = 0.012M; // Store a shared value

            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs.Jones";
            jonesAccount.Balance = 2400;
            WriteLine(
                format: "{0} earned {1:C} interest.",
                arg0: jonesAccount.AccountName,
                arg1: jonesAccount.Balance * BankAccount.InterestRate
            );

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms.Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine(
                format: "{0} earned {1:C} interest.",
                arg0: gerrierAccount.AccountName,
                arg1: gerrierAccount.Balance * BankAccount.InterestRate
            );

            WriteLine();
            WriteLine($"{bob.Name} is a {Person.Species}");

            WriteLine();
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            WriteLine();
            var blankPerson = new Person();
            WriteLine(
                format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
                arg0: blankPerson.Name,
                arg1: blankPerson.HomePlanet,
                arg2: blankPerson.Instantiated);

            WriteLine();
            var gunny = new Person("Gunny", "Mars");
            WriteLine(
                format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
                arg0: gunny.Name,
                arg1: gunny.HomePlanet,
                arg2: gunny.Instantiated
            );

            WriteLine();
            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            WriteLine();
            // Tuple calling
            (string,int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1},{fruit.Item2} there are");
            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}");

            WriteLine();
            // Tuple name inference
            var thing1 = ("Neville",4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children");
            var thing2 = (bob.Name,bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children");

            WriteLine();
            // Deconstructing Tuples
            (string fruitName,int fruitNumber)= bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

            WriteLine();
            // Defining and passing parameters to method
            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Emily"));

            WriteLine();
            // Passing optional parameters
            WriteLine(bob.OptionalParameters());
            WriteLine(bob.OptionalParameters("Jump!",98.5));
            WriteLine(bob.OptionalParameters(number:52.7,command:"Hide!"));
            WriteLine(bob.OptionalParameters("Poke!",active:false));

            WriteLine();
            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");

            bob.PassingParameters(a,ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            WriteLine();
            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet! ");
            bob.PassingParameters(d,ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}");

            WriteLine();
            // Controlling access with properties and indexers
            var sam = new Person{
                Name = "Sam",
                DateOfBirth = new DateTime(1991,4,7)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            WriteLine();
            // Defining settable property 
            sam.FavoriteIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favorite ice-cream flavour is {sam.FavoriteIceCream}.");
            sam.FavoritePrimaryColor ="Red";
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");

            WriteLine();
            // Indexers
            sam.Children.Add(new Person {Name = "Charlie"});
            sam.Children.Add(new Person {Name = "Ella"});
            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");
            WriteLine($"Sam's second child is {sam[1].Name}");


            WriteLine();
             WriteLine();
              WriteLine();

            // Pattern Matching with objects
            object[] passengers ={
                new FirstClassPassenger {AirMiles = 1_419},
                new FirstClassPassenger {AirMiles = 16_562},
                new BusinessClassPassenger(),
                new CoachClassPassenger{CarryOnKG = 25.7},
                new CoachClassPassenger {CarryOnKG = 0},
            };
            foreach (object passenger in passengers)
            {
                Decimal flightCost = passenger switch 
                {
                    /* FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
                    FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
                    FirstClassPassenger  => 2000M, */
                    FirstClassPassenger p => p.AirMiles switch
                    {
                      > 35000 => 1500M,
                      > 15000 => 1720M,
                      _ => 2000M  
                        
                    },
                    BusinessClassPassenger _ => 1000M,
                    CoachClassPassenger p when p.CarryOnKG <10.0 => 500M,
                    CoachClassPassenger _ => 650M,
                    _ => 800M
                };
                WriteLine($"Flight cost {flightCost:C} for {passenger}");
            }
        }
    }
}
