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
				Console.WriteLine($"{farm.ChickenHouses.IndexOf(house) + 1}. Chicken House ({house.Animals.Count} chickens)");
			}
			//TODO: only show grazing fields with meat animals in
			foreach (GrazingField field in farm.GrazingFields)
			{
				Console.WriteLine($"{farm.GrazingFields.IndexOf(field) + 1 + farm.ChickenHouses.Count}. Grazing Field ({field.Animals.Count} animals)");	
			}
			
			Console.WriteLine();
			Console.WriteLine("Which facility has the animals you want to process?");
			//ask for input
			Console.Write("> ");
			//acquire input
			try
			{
				int choice = Int32.Parse(Console.ReadLine());
				//IMeatFacility<IMeatProducing> chosenFacility = null;
				//use input to fill chosen field object variable 
				if (farm.ChickenHouses.Count == 0 && farm.GrazingFields.Count > 0) {
					IMeatFacility<IMeatProducing> chosenFacility = farm.GrazingFields[choice-1] as IMeatFacility<IMeatProducing>;
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
				} else if (farm.ChickenHouses.Count > 0 && farm.GrazingFields.Count == 0) {
					
					ChickenHouse _facility = farm.ChickenHouses[choice-1];
					
					IMeatFacility<IMeatProducing> chosenFacility = (IMeatFacility<IMeatProducing>) _facility;
					
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
				
				} else if (choice >= farm.ChickenHouses.Count) {
					IMeatFacility<IMeatProducing> chosenFacility = farm.GrazingFields[choice-1-farm.ChickenHouses.Count] as IMeatFacility<IMeatProducing>;
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
				} else if (choice < farm.ChickenHouses.Count) {
					IMeatFacility<IMeatProducing> chosenFacility = farm.ChickenHouses[choice-1] as IMeatFacility<IMeatProducing>;
					ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
				}

				//ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
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