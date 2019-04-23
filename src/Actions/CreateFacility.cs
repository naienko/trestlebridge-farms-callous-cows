using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
	public class CreateFacility
	{
		public static void CollectInput(Farm farm)
		{
			Console.WriteLine("1. Grazing field");
			Console.WriteLine("2. Plowed field");
			Console.WriteLine("3. Natural field");
			Console.WriteLine("4. Chicken house");
			Console.WriteLine("5. Duck house");

			Console.WriteLine();
			Console.WriteLine("Choose what you want to create");

			Console.Write("> ");
			
			try
			{
				int choice = Int32.Parse(Console.ReadLine());
				switch (choice)
				{
					case 1:
						farm.AddGrazingField(new GrazingField());
						break;
					case 2:
						farm.AddPlowedField(new PlowedField());
						break;
					case 3:
						farm.AddNaturalField(new NaturalField());
						break;
					case 4:
						farm.AddChickenHouse(new ChickenHouse());
						break;
					case 5:
						farm.AddDuckHouse(new DuckHouse());
						break;
					default:
						Console.WriteLine($"Invalid option: {choice}");
						Console.WriteLine("Press any key to go back to the menu.");
						Console.ReadLine();
                        Console.Clear();
                        CreateFacility.CollectInput(farm);
						break;
				}
			}
			catch (FormatException)
			{
                Console.WriteLine($"Invalid option");
                Console.WriteLine("Press any key to go back to the menu.");
                Console.ReadLine();
                Console.Clear();
                CreateFacility.CollectInput(farm);
			}
		}
	}
}