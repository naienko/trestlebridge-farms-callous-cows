using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseChickenHouse {
        public static void CollectInput (Farm farm, Chicken animal) {
            Console.Clear();

            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Chicken House");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the chicken where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            farm.ChickenHouses[choice-1].AddResource(animal);
        }
    }
}