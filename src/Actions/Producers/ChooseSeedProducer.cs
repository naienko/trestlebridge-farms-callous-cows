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
			//loop list all the field objects in the list of field objects that might produce the seed resource
			foreach (PlowedField field in farm.PlowedFields)
			{
				Console.WriteLine($"{farm.PlowedFields.IndexOf(field) + 1}. Plowed Field ({field.Plants.Count} rows)");
			}

			Console.WriteLine();
			Console.WriteLine("Which facility has the plants you want to process?");
//ask for input
			Console.Write("> ");
			//acquire input
			int choice = Int32.Parse(Console.ReadLine());
//use input to fill chosen field object variable 
			PlowedField chosenField = farm.PlowedFields[choice - 1];
			Console.Clear();
			//create hashset of plants by type with count
			List<TypeCounter> plantCount = (
				from flower in chosenField.Plants
				group flower by flower.Type into PlantGroup
				select new TypeCounter
				{
					Type = PlantGroup.Key,
					Count = PlantGroup.Count()
				}
			).ToList();
			//loop list all the plant objects in the list of plant objects in the chosen field
			foreach (TypeCounter entry in plantCount)
			{
				Console.WriteLine($"{plantCount.IndexOf(entry) + 1}. {entry.Count} {entry.Type}");
			}
			Console.WriteLine();
//ask for input
			Console.WriteLine("Which resource should be processed?");
			Console.Write("> ");
			//acquire input
			int resourceChoice = Int32.Parse(Console.ReadLine());
			// this doesn't work, because of the way the hashset works
			//IResource<SeedProcessor> chosenSeed = chosenField.Plants[resourceChoice - 1];
			//
			//use input to fill chosen plant type variable by getting the first object from the list of plant objects in the chosen field that matches the chosen type in the hashset
			IResource<SeedProcessor> chosenSeed = chosenField.Plants.First(n => n.Type == plantCount[resourceChoice - 1].Type);
//ask for input
			Console.WriteLine($"How many {chosenSeed.Type} should be processed?");
			Console.Write("> ");
			//break out to new file?
			//acquire input
			int resourceCount = Int32.Parse(Console.ReadLine());
			//create new SeedProcessor machine object
			SeedProcessor _seedProcessor = new SeedProcessor();
			if (resourceCount <= _seedProcessor.Capacity) //change this check to account for all _seedProcessor.Materials
														  //use reduce to find out how many total rows are in _seedProcessor.Materials
			{
				//create new Material object with chosen plant type and number of plants to process
				Material<SeedProcessor> _material = new Material<SeedProcessor>()
				{
					Resource = chosenSeed,
					Count = resourceCount
				};
				//add Material object to List in machine object
				_seedProcessor.Materials.Add(_material);
				//loop through the list of plant objects in the chosen field object and remove resourceCount objects from that list iff they match the chosen plant type
				for (int i = 0; i <= resourceCount; i++)
				{
					if (chosenField.Plants[i] == chosenSeed)
					{
						chosenField.Plants.RemoveAt(i);
					}
				}
				//ask for input
				Console.WriteLine("Ready to process? (Y/n)");
				Console.Write("> ");
				//acquire input
				string processGo = Console.ReadLine();
				//use input to determine path
				if (processGo == "y")
				{
					//loop through machine object Materials list
					foreach (Material<SeedProcessor> material in _seedProcessor.Materials)
					{
						//loop bounded by how many of given plant type
						for (int i = 0; i < material.Count; i++)
						{
							//create new Dictionary to hold given plant type and results of processing one of that plant type
							Dictionary<IResource<SeedProcessor>, double> _output = new Dictionary<IResource<SeedProcessor>, double>();
							//fill Dictionary
							_output.Add(material.Resource, material.Resource.Process(_seedProcessor));
							//Add Dictionary to List property containing all results
							_seedProcessor.Output.Add(_output);
						}
					}
//loop through the list of output Dictionaries
					foreach (Dictionary<IResource<SeedProcessor>, double> output in _seedProcessor.Output)
					{
						//iterate each keyvaluepair in chosen Dictionary
						foreach (KeyValuePair<IResource<SeedProcessor>, double> entry in output)
						{
							//display keys and values
							Console.WriteLine($"{entry.Value} {entry.Key.Type} seeds were produced");
							// hashset group by seed type, add values together
						}
					}
					//pause console for reading
					Console.ReadLine();
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