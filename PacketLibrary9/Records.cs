namespace Packt.Shared
{
    // Init-only properties
    public class ImmutablePerson
    {
        public string FirstName {get; init;}
        public string LastName {get;init;}
    }
    // Records
    public record ImmutableVehicle
    {
        public int Wheels {get; init;}
        public string Color {get; init;}
        public string Brand {get;init;}
    }

    // Positional records
    // public record ImmutableAnimal
    // {
    //     string Name;
    //     string Species; 
    //     public ImmutableAnimal(string name,string species)
    //     {
    //         Name =name;
    //         Species= species;
    //     }
    //     public void Deconstructor (out string name, out string species)
    //     {
    //         name = Name;
    //         species = Species;
    //     }
        
    // }
    public record ImmutableAnimal(string Name,string Species);
        
}
