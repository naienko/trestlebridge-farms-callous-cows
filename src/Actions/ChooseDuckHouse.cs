using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseDuckHouse {
        public static void CollectInput (Farm farm, Duck animal) {
            foreach (DuckHouse field in farm.DuckHouses)
            {
                if (field.Ducks.Count < field.Capacity) {
                    Console.WriteLine ($"{farm.DuckHouses.IndexOf(field)+1}. Plowed Field ({field.Ducks.Count} of {field.Capacity} ducks)");
                }
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the duck where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            try {
                farm.DuckHouses[choice-1].AddResource(farm, animal);
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine($"Invalid option: {choice}");
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadLine();
            }
        }
    }
}