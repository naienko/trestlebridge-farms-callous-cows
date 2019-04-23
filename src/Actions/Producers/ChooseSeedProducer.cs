using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Interfaces;
using Trestlebridge.HashBox;

namespace Trestlebridge.Actions.Producers
{
	public class ChooseSeedProducer
	{
		public static void CollectInput(Farm farm)
		{
			foreach (PlowedField field in farm.PlowedFields)
			{
				Console.WriteLine ($"{farm.PlowedFields.IndexOf(field) + 1}. Natural Field ({field.Plants.Count} rows)");
			}

			Console.WriteLine ();
			Console.WriteLine("Which facility has the plants you want to process?");
			
			Console.Write ("> ");
			int choice = Int32.Parse(Console.ReadLine ());
			
			//then jump to list 'type and count of animals' in chosen facility (hashset)
			PlowedField chosenField = farm.PlowedFields[choice-1];
			Console.Clear();
			List<TypeCounter> plantCount = (
                from flower in chosenField.Plants
                group flower by flower.Type into PlantGroup
                select new TypeCounter {
                    Type = PlantGroup.Key,
                    Count = PlantGroup.Count()
                }
            ).ToList();
            foreach (TypeCounter entry in plantCount) {
                Console.WriteLine ($"{plantCount.IndexOf(entry) + 1}. {entry.Count} {entry.Type}");
			}
			Console.WriteLine ();
			Console.WriteLine ("Which resource should be processed?");
			Console.Write ("> ");
			Console.ReadLine();
		}
	}
}