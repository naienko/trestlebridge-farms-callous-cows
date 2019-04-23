using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        public static void CollectInput (Farm farm, ICompostProducing plant) {
           foreach (NaturalField field in farm.NaturalFields)
            {
                Console.WriteLine ($"{farm.NaturalFields.IndexOf(field)+1}. Natural Field ({field.Plants.Count} of {field.Capacity} rows)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Plant the seeds where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            try {
                farm.NaturalFields[choice-1].AddResource(farm, plant);
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine($"Invalid option: {choice}");
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadLine();
            }
        }
    }
}