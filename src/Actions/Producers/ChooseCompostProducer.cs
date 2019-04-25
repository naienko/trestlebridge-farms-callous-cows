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
			List<ICompostFacility<ICompostProducing>> wheresTheCompost = new List<ICompostFacility<ICompostProducing>>();
			// type constraints?
			foreach (NaturalField field in farm.NaturalFields)
			{
				wheresTheCompost.Add(field);
			}
			foreach (GrazingField field in farm.GrazingFields)
			{
				wheresTheCompost.Add(field);
			}
		
			foreach (ICompostFacility<ICompostProducing> facility in wheresTheCompost)
			{
				Console.WriteLine($"{wheresTheCompost.IndexOf(facility) + 1}. {facility.Type} ({facility.CompostResource.Count} resources which provide compost)");
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
				ICompostFacility<ICompostProducing> chosenFacility = wheresTheCompost[choice - 1];
				ChooseCompostType.CollectInput(farm, equipment, chosenFacility);
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