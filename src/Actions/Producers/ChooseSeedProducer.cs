using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Processors;
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
				Console.WriteLine($"{farm.PlowedFields.IndexOf(field) + 1}. Plowed Field ({field.Plants.Count} rows)");
			}

			Console.WriteLine();
			Console.WriteLine("Which facility has the plants you want to process?");

			Console.Write("> ");
			int choice = Int32.Parse(Console.ReadLine());

			//then jump to list 'type and count of animals' in chosen facility (hashset)
			PlowedField chosenField = farm.PlowedFields[choice - 1];
			Console.Clear();
			List<TypeCounter> plantCount = (
				from flower in chosenField.Plants
				group flower by flower.Type into PlantGroup
				select new TypeCounter
				{
					Type = PlantGroup.Key,
					Count = PlantGroup.Count()
				}
			).ToList();
			foreach (TypeCounter entry in plantCount)
			{
				Console.WriteLine($"{plantCount.IndexOf(entry) + 1}. {entry.Count} {entry.Type}");
			}
			Console.WriteLine();

			Console.WriteLine("Which resource should be processed?");
			Console.Write("> ");

			int resourceChoice = Int32.Parse(Console.ReadLine());
			IResource chosenSeed = chosenField.Plants[resourceChoice - 1];
			Console.WriteLine($"How many {chosenSeed.Type} should be processed?");
			Console.Write("> ");
			//break out to new file?
			int resourceCount = Int32.Parse(Console.ReadLine());
			SeedProcessor _seedProcessor = new SeedProcessor();
			if (resourceCount <= _seedProcessor.Capacity) //change this check to account for all _seedProcessor.Materials
			{
				Console.WriteLine("Ready to process? (Y/n)");
				Console.Write("> ");
				string processGo = Console.ReadLine();
				if (processGo == "y")
				{
					Dictionary<int, IResource> _material = new Dictionary<int, IResource>();
					_material.Add(resourceCount, chosenSeed);
					_seedProcessor.Materials.Add(_material);

					//remove resourceCount from chosenField
					//run Process loop on Materials
				}
				else if (processGo == "n")
				{
					CollectInput(farm);
				}
				else
				{
					Console.WriteLine($"Invalid option: {processGo}");
					Console.WriteLine("Press any key to go back to main menu.");
					Console.ReadLine();
				}
			}
			else
			{
				Console.WriteLine("The Seed Processor cannot hold that many at once! Please choose fewer rows.");
				Console.ReadLine();
			}

		}
	}
}