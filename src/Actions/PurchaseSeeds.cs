using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
	public class PurchaseSeeds
	{
		public static void CollectInput(Farm farm)
		{
			Console.WriteLine("1. Sesame");
			Console.WriteLine("2. Sunflower");
			Console.WriteLine("3. Wildflower");

			Console.WriteLine();
			Console.WriteLine("What are you buying today?");

			Console.Write("> ");

			try
			{
				int choice = Int32.Parse(Console.ReadLine());
				Console.Clear();
				switch (choice)
				{
					case 1:
						if (farm.PlowedFields.Count != 0) {
							ChoosePlowedField.CollectInput(farm, new Sesame());
						} else {
							Console.WriteLine("You don't have any facilities for this plant!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					case 2:
						Console.Clear();
						Console.WriteLine("1. Seeds");
						Console.WriteLine("2. Compost");
						Console.WriteLine();
						Console.WriteLine("What resource do you want from Sunflowers?");
						Console.Write("> ");
						int resourceChoice = Int32.Parse(Console.ReadLine());
						if (resourceChoice == 1)
						{
							if (farm.PlowedFields.Count != 0) {
								ChoosePlowedField.CollectInput(farm, new Sunflower());
							} else {
							Console.WriteLine("You don't have any facilities for this plant!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
							}
						}
						else if (resourceChoice == 2)
						{
							if (farm.NaturalFields.Count != 0) {
								ChooseNaturalField.CollectInput(farm, new Sunflower());
							} else {
							Console.WriteLine("You don't have any facilities for this plant!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
							}
						}
						else
						{
							Console.WriteLine($"Invalid option: {resourceChoice}");
							Console.WriteLine("Press any key to go back to main menu.");
							Console.ReadLine();
						}
						break;
					case 3:
						if (farm.NaturalFields.Count != 0) {
							ChooseNaturalField.CollectInput(farm, new Wildflower());
						} else {
							Console.WriteLine("You don't have any facilities for this plant!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					default:
                        Console.WriteLine($"Invalid option: {choice}");
						Console.WriteLine("Press any key to go back to the menu.");
						Console.ReadLine();
                        Console.Clear();
                        CollectInput(farm);
						break;
				}
			}
			catch (FormatException)
			{
                Console.WriteLine($"Invalid option");
				Console.WriteLine("Press any key to go back to the menu.");
				Console.ReadLine();
                Console.Clear();
                CollectInput(farm);
			}
		}
	}
}