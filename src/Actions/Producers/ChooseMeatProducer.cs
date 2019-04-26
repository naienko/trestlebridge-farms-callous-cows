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
	public class ChooseMeatProducer
	{
		public static void CollectInput(Farm farm, MeatProcessor equipment)
		{
			foreach (ChickenHouse house in farm.ChickenHouses)
			{
				List<Material<MeatProcessor>> inThisFacility = equipment.Materials.Where(m => m.Facility == house.shortId).ToList();
				double ChickenCount = 0;
				foreach (var material in inThisFacility) {
					if (material.Resource.Type == "Chicken") {
						ChickenCount = material.Count;
					} 
				}
				Console.WriteLine($"{farm.ChickenHouses.IndexOf(house) + 1}. Chicken House ({house.Animals.Count - ChickenCount} chickens)");
			}
			//TODO: only show grazing fields with meat animals in
			foreach (GrazingField field in farm.GrazingFields)
			{
				List<Material<MeatProcessor>> inThisFacility = equipment.Materials.Where(m => m.Facility == field.shortId).ToList();
				double CowCount = 0;
				double OstrichCount = 0;
				double PigCount = 0;
				double SheepCount = 0;
				foreach (var material in inThisFacility) {
					if (material.Resource.Type == "Cow") {
						CowCount = material.Count;
					} else if (material.Resource.Type == "Ostrich") {
						OstrichCount = material.Count;
					} else if (material.Resource.Type == "Pig") {
						PigCount = material.Count;
					} else if (material.Resource.Type == "Sheep") {
						SheepCount = material.Count;
					}
				}
				Console.WriteLine($"{farm.GrazingFields.IndexOf(field) + 1 + farm.ChickenHouses.Count}. Grazing Field ({field.Animals.Count - CowCount - OstrichCount - PigCount - SheepCount} animals)");	
			}
			
			Console.WriteLine();
			Console.WriteLine("Which facility has the animals you want to process?");
			//ask for input
			Console.Write("> ");
			//acquire input
			try
			{
				int choice = Int32.Parse(Console.ReadLine());
				//use input to fill chosen field object variable 
				if (farm.ChickenHouses.Count == 0 && farm.GrazingFields.Count > 0) {
					GrazingField _facility = farm.GrazingFields[choice-1];
					IMeatFacility<IMeatProducing> chosenFacility = (IMeatFacility<IMeatProducing>) _facility;
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
				} else if (farm.ChickenHouses.Count > 0 && farm.GrazingFields.Count == 0) {
					ChickenHouse _facility = farm.ChickenHouses[choice-1];
					IMeatFacility<IMeatProducing> chosenFacility = (IMeatFacility<IMeatProducing>) _facility;
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
				} else if (choice > farm.ChickenHouses.Count) {
					GrazingField _facility = farm.GrazingFields[choice - 1 - farm.ChickenHouses.Count];
					IMeatFacility<IMeatProducing> chosenFacility = (IMeatFacility<IMeatProducing>) _facility;
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
				} else if (choice <= farm.ChickenHouses.Count) {
					ChickenHouse _facility = farm.ChickenHouses[choice-1];
					IMeatFacility<IMeatProducing> chosenFacility = (IMeatFacility<IMeatProducing>) _facility;
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
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