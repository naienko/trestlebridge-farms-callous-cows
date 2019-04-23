using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {
        public static void CollectInput (Farm farm, IGrazing animal) {
            foreach (GrazingField field in farm.GrazingFields)
            {
                if (field.Animals.Count < field.Capacity) {
                    Console.WriteLine ($"{farm.GrazingFields.IndexOf(field)+1}. Plowed Field ({field.Animals.Count} of {field.Capacity} animals)");
                }
            }
            // STRETCH: realign numbers for facility listing when it skips full ones
            // put available fields in a new temporary List<>? then foreach the list?

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Place the animal where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            try {
                farm.GrazingFields[choice-1].AddResource(farm, animal);
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine($"Invalid option: {choice}");
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadLine();
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}