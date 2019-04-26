using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Processors;
using Trestlebridge.Interfaces;
using Trestlebridge.HashBox;

namespace Trestlebridge.Actions.Producers
{
	public class ChooseCompostType
	{
		public static void CollectInput(Farm farm, CompostProcessor equipment, ICompostFacility<ICompostProducing> chosenFacility)
		{
			Console.Clear();
			//create hashtable of plants by type with count
			List<TypeCounter> compostCount = (
				from resource in chosenFacility.CompostResource
				group resource by resource.Type into compostGroup
				select new TypeCounter
				{
					Type = compostGroup.Key,
					Count = compostGroup.Count()
				}
			).ToList();
			List<TypeCounter> alreadyLoaded = (
				from material in equipment.Materials
				group material by material.Resource.Type into howMany
				select new TypeCounter
				{
					Type = howMany.Key,
					Count = howMany.Count()
				}
			).ToList();

			//loop list all the plant objects in the list of plant objects in the chosen field
			foreach (TypeCounter group in compostCount)
			{
				{
					if (alreadyLoaded.Count > 0)
					{
						for (int j = 0; j < alreadyLoaded.Count; j++)
						{
							if (alreadyLoaded[j].Type == group.Type)
							{
								Console.WriteLine($"{compostCount.IndexOf(group) + 1}. {group.Count - alreadyLoaded[j].Count} {group.Type}");
							}
						}
					}
					else
					{
						Console.WriteLine($"{compostCount.IndexOf(group) + 1}. {group.Count} {group.Type}");
					}
				}
			}
			Console.WriteLine();
			//ask for input
			Console.WriteLine("Which resource should be processed?");
			Console.Write("> ");

			//acquire input
			int resourceChoice = Int32.Parse(Console.ReadLine());

			//use input to fill chosen plant type variable by getting the first object from the list of plant objects in the chosen field that matches the chosen type in the hashset
			IResource<CompostProcessor> chosenResource = chosenFacility.CompostResource.First(n => n.Type == compostCount[resourceChoice - 1].Type);
			//ask for input
			Console.WriteLine($"How many {chosenResource.Type} should be processed?");
			Console.Write("> ");
			//break out to new file?
			//acquire input
			int resourceCount = Int32.Parse(Console.ReadLine());

			double materialsInEquipment = 0;
			foreach (Material<CompostProcessor> entry in equipment.Materials)
			{
				materialsInEquipment = materialsInEquipment + entry.Count;
			}

			if (materialsInEquipment + resourceCount <= equipment.Capacity) //change this check to account for all equipment.Materials
			{
				//create new Material object with chosen plant type and number of plants to process
				Material<CompostProcessor> _material = new Material<CompostProcessor>()
				{
					Resource = chosenResource,
					Count = resourceCount,
					Facility = chosenFacility.shortId
				};
				//add Material object to List in machine object
				equipment.Materials.Add(_material);

				Console.Clear();
				//ask for input
				Console.WriteLine("Ready to process? (Y/n)");
				Console.Write("> ");
				//acquire input
				string processGo = Console.ReadLine();
				//use input to determine path
				if (processGo == "y")
				{
					//loop through machine object Materials list
					foreach (Material<CompostProcessor> material in equipment.Materials)
					{
						//loop through the list of plant objects in the chosen field object and remove #resourceCount objects from that list iff they match the chosen plant type
						if (material.Resource.Type != "Goat")
						{
							int j = 0;
							IEnumerable<NaturalField> findFacility =
								from field in farm.NaturalFields
								where field.shortId == material.Facility
								select field;
							var currentFacility = (NaturalField)findFacility;
							for (int i = 0; i < currentFacility.CompostResource.Count; i++)
							{
								if (j < material.Count)
								{
									while (j < material.Count && currentFacility.CompostResource[i].Type == material.Resource.Type)
									{
										currentFacility.CompostResource.RemoveAt(i);
										j++;
									}
								}
							}
							int k = 0;
							for (int i = 0; i < currentFacility.Plants.Count; i++)
							{
								if (k < material.Count)
								{
									while (k < material.Count && currentFacility.Plants[i].Type == material.Resource.Type)
									{
										currentFacility.Plants.RemoveAt(i);
										j++;
									}
								}
							}
						}
						Console.WriteLine($"processing {material.Count} {material.Resource.Type}");
						//loop bounded by how many of given plant type
						for (int i = 0; i < material.Count; i++)
						{
							//create new Material object to hold given plant type and results of processing one of that plant type
							Material<CompostProcessor> _output = new Material<CompostProcessor>()
							{
								Resource = material.Resource,
								Count = material.Resource.Process(equipment)
							};
							//Add Material to List property containing all results
							equipment.Output.Add(_output);
						}
					}
					// generate hashtable by type with sum
					List<TypeCounter> totalCompostByType = (
						from entry in equipment.Output
						group entry by entry.Resource.Type into TypeGroup
						select new TypeCounter
						{
							Type = TypeGroup.Key,
							Count = TypeGroup.Sum(e => e.Count)
						}
					).ToList();

					//loop through the output hashtable
					foreach (TypeCounter entry in totalCompostByType)
					{
						Console.WriteLine($"{entry.Count}kg of {entry.Type} compost was produced");
					}
					//pause console for reading
					Console.WriteLine("Press any key to go back to main menu.");
					Console.ReadLine();
				}
				else if (processGo == "n")
				{
					ChooseCompostProducer.CollectInput(farm, equipment);
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
				Console.WriteLine("The Composter cannot hold that many at once! Please choose fewer rows.");
				Console.ReadLine();
				CollectInput(farm, equipment, chosenFacility);
			}
		}
	}
}