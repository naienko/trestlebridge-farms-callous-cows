using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseDuckHouse {
        public static void CollectInput (Farm farm, Duck animal) {
            Console.Clear();

            for (int i = 0; i < farm.DuckHouses.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Duck House");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the duck where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            farm.DuckHouses[choice-1].AddResource(animal);
        }
    }
}