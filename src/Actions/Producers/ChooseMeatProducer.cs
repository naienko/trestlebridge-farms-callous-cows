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
			List<IMeatFacility<IMeatProducing>> wheresTheMeat = new List<IMeatFacility<IMeatProducing>>();
			// type constraints?
			foreach (GrazingField field in farm.GrazingFields)
			{
				// Console.WriteLine($"{farm.GrazingFields.IndexOf(field) + 1}. Grazing Field ({field.Animals.Count} animals)");

				wheresTheMeat.Add(field);
			}
			foreach (IMeatFacility<IMeatProducing> house in farm.ChickenHouses)
			{
				// Console.WriteLine($"{farm.ChickenHouses.IndexOf(house) + 1 + farm.GrazingFields.Count}. Chicken House ({house.Chickens.Count} chickens)");
				wheresTheMeat.Add(house);
			}
		

			foreach (IMeatFacility<IMeatProducing> facility in wheresTheMeat)
			{
				Console.WriteLine($"{wheresTheMeat.IndexOf(facility) + 1}. {facility.Type} ({facility.MeatAnimals.Count} animals which provide meat)");
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
				IMeatFacility<IMeatProducing> chosenFacility = wheresTheMeat[choice - 1];
				ChooseMeatType.CollectInput(farm, equipment, chosenFacility);
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