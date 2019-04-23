using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.HashBox;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {
        public static void CollectInput (Farm farm, IGrazing animal) {
            foreach (GrazingField field in farm.GrazingFields)
            {
                if (field.Animals.Count < field.Capacity) {
                    StringBuilder output = new StringBuilder();
                    output.Append($"{farm.GrazingFields.IndexOf(field)+1}. Grazing Field (");
                    if (field.Animals.Count == 0) {
                        output.Append("0");
                    } else {
                        //group by
                        List<CountAnimals> animalCount = (
                            from ruminant in field.Animals
                            group ruminant by ruminant.Type into AnimalGroup
                            select new CountAnimals {
                                Type = AnimalGroup.Key,
                                Count = AnimalGroup.Count()
                            }
                        ).ToList();
                        foreach (CountAnimals entry in animalCount) {
                            // TODO: remove trailing comma
                            output.Append($"{entry.Count} {entry.Type},");
                        }
                    }
                    output.Append($" of {field.Capacity} animals)");
                    Console.WriteLine(output);
                }
            }
            // STRETCH: realign numbers for facility listing when it skips full ones
            // put available fields in a new temporary List<>? then foreach the list?
            // use linq directives to pull available fields?

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