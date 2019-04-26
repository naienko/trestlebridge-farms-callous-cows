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
	public class ChooseCompostProducer
	{
		public static void CollectInput(Farm farm, CompostProcessor equipment)
		{
			foreach (NaturalField house in farm.NaturalFields)
			{
				List<Material<CompostProcessor>> inThisFacility = equipment.Materials.Where(m => m.Facility == house.shortId).ToList();
				double SunflowerCount = 0;
				double WildflowerCount = 0;
				foreach (var material in inThisFacility) {
					if (material.Resource.Type == "Sunflower") {
						SunflowerCount = material.Count;
					} else if (material.Resource.Type == "Wildflower") {
						WildflowerCount = material.Count;
					}
				}
				Console.WriteLine($"{farm.NaturalFields.IndexOf(house) + 1}. Natural Field {house.shortId} ({house.Plants.Count - SunflowerCount - WildflowerCount} rows)");
			}
			//TODO: only show grazing fields with goats in
			foreach (GrazingField field in farm.GrazingFields)
			{
				List<Material<CompostProcessor>> inThisFacility = equipment.Materials.Where(m => m.Facility == field.shortId).ToList();
				double GoatCount = 0;
				foreach (var material in inThisFacility) {
					if (material.Resource.Type == "Goat") {
						GoatCount = material.Count;
					}
				}
				Console.WriteLine($"{farm.GrazingFields.IndexOf(field) + 1 + farm.NaturalFields.Count}. Grazing Field {field.shortId} ({field.Animals.Count - GoatCount} animals)");
			}

			Console.WriteLine();
			Console.WriteLine("Which facility has the resources you want to process?");
			//ask for input
			Console.Write("> ");
			//acquire input
			try
			{
				int choice = Int32.Parse(Console.ReadLine());
				//use input to fill chosen field object variable 
				if (farm.NaturalFields.Count == 0 && farm.GrazingFields.Count > 0)
				{
					ICompostFacility<ICompostProducing> chosenFacility = farm.GrazingFields[choice - 1] as ICompostFacility<ICompostProducing>;
					ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
				}
				else if (farm.NaturalFields.Count > 0 && farm.GrazingFields.Count == 0)
				{
					ICompostFacility<ICompostProducing> chosenFacility = farm.NaturalFields[choice - 1] as ICompostFacility<ICompostProducing>;
					ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
				}
				else if (choice > farm.NaturalFields.Count)
				{
					ICompostFacility<ICompostProducing> chosenFacility = farm.GrazingFields[choice - 1 - farm.NaturalFields.Count] as ICompostFacility<ICompostProducing>;
					ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
				}
				else if (choice <= farm.NaturalFields.Count)
				{
					ICompostFacility<ICompostProducing> chosenFacility = farm.NaturalFields[choice - 1] as ICompostFacility<ICompostProducing>;
					ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine($"Invalid option");
				Console.WriteLine("Press any key to go back to main menu.");
				Console.ReadLine();
			}
		}
	}
}