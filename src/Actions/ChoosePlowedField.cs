using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChoosePlowedField {
        public static void CollectInput (Farm farm, ISeedProducing plant) {
            Console.Clear();

            // for (int i = 0; i < farm.PlowedFields.Count; i++)
            // {
            //     Console.WriteLine ($"{i + 1}. Plowed Field");
            // }

            foreach (PlowedField field in farm.PlowedFields)
            {
                Console.WriteLine ($"{farm.PlowedFields.IndexOf(field)+1}. Plowed Field ({field.Plants.Count} of {field.Capacity} rows)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Plant the seeds where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            try {
                farm.PlowedFields[choice-1].AddResource(plant);
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine($"Invalid option: {choice}");
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadLine();
            }
        }
    }
}