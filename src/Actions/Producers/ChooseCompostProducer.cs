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
				Console.WriteLine($"{farm.NaturalFields.IndexOf(house) + 1}. Natural Field ({house.Plants.Count} rows)");
			}
			//TODO: only show grazing fields with goats in
			foreach (GrazingField field in farm.GrazingFields)
			{
				Console.WriteLine($"{farm.GrazingFields.IndexOf(field) + 1 + farm.NaturalFields.Count}. Grazing Field ({field.Animals.Count} animals)");	
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
				if (farm.NaturalFields.Count == 0 && farm.GrazingFields.Count > 0) {
					ICompostFacility<ICompostProducing> chosenFacility = farm.GrazingFields[choice-1] as ICompostFacility<ICompostProducing>;
					ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
				} else if (farm.NaturalFields.Count > 0 && farm.GrazingFields.Count == 0) {
					ICompostFacility<ICompostProducing> chosenFacility = farm.NaturalFields[choice-1] as ICompostFacility<ICompostProducing>;
					ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
				} else if (choice > farm.NaturalFields.Count) {
					ICompostFacility<ICompostProducing> chosenFacility = farm.GrazingFields[choice - 1 - farm.NaturalFields.Count] as ICompostFacility<ICompostProducing>;
					ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
				} else if (choice <= farm.NaturalFields.Count) {
					ICompostFacility<ICompostProducing> chosenFacility = farm.NaturalFields[choice-1] as ICompostFacility<ICompostProducing>;
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