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
		public static void CollectInput(Farm farm, SeedProcessor equipment)
		{
			Console.Clear();
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
			try
			{
				int choice = Int32.Parse(Console.ReadLine());
				//use input to fill chosen field object variable 
				PlowedField chosenField = farm.PlowedFields[choice - 1];
				ChooseSeedType.CollectInput(farm, equipment, chosenField);
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