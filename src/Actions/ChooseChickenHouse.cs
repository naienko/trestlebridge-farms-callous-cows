using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseChickenHouse {
        public static void CollectInput (Farm farm, Chicken animal) {
            Console.Clear();

            foreach (ChickenHouse field in farm.ChickenHouses)
            {
                Console.WriteLine ($"{farm.ChickenHouses.IndexOf(field)+1}. Plowed Field ({field.Chickens.Count} of {field.Capacity} chickens)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the chicken where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            try {
                farm.ChickenHouses[choice-1].AddResource(animal);
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine($"Invalid option: {choice}");
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadLine();
            }
        }
    }
}