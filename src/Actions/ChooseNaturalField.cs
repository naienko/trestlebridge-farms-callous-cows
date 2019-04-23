using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.HashBox;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        public static void CollectInput (Farm farm, ICompostProducing plant) {
           foreach (NaturalField field in farm.NaturalFields)
            {
                if (field.Plants.Count < field.Capacity) {
                    StringBuilder output = new StringBuilder();
                    output.Append($"{farm.NaturalFields.IndexOf(field)+1}. Natural Field (");
                    if (field.Plants.Count == 0) {
                        output.Append("0");
                    } else {
                        //group by
                        List<TypeCounter> plantCount = (
                            from flower in field.Plants
                            group flower by flower.Type into PlantGroup
                            select new TypeCounter {
                                Type = PlantGroup.Key,
                                Count = PlantGroup.Count()
                            }
                        ).ToList();
                        foreach (TypeCounter entry in plantCount) {
                            // TODO: remove trailing comma
                            output.Append($"{entry.Count} {entry.Type},");
                        }
                    }
                    output.Append($" of {field.Capacity} rows)");
                    Console.WriteLine(output);
                    //Console.WriteLine ($"{farm.NaturalFields.IndexOf(field)+1}. Natural Field ({field.Plants.Count} of {field.Capacity} rows)");
                }
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