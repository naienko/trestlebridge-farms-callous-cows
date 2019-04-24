using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
	public class PurchaseStock
	{
		public static void CollectInput(Farm farm)
		{
			Console.WriteLine("1. Chicken");
			Console.WriteLine("2. Cow");
			Console.WriteLine("3. Duck");
			Console.WriteLine("4. Goat");
			Console.WriteLine("5. Ostrich");
			Console.WriteLine("6. Pig");
			Console.WriteLine("7. Sheep");

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
						if (farm.ChickenHouses.Count != 0) {
							ChooseChickenHouse.CollectInput(farm, new Chicken());
						} else {
							Console.WriteLine("You don't have any facilities for this animal!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					case 2:
						if (farm.GrazingFields.Count != 0) {
							ChooseGrazingField.CollectInput(farm, new Cow());
						} else {
							Console.WriteLine("You don't have any facilities for this animal!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					case 3:
						if (farm.DuckHouses.Count != 0) {
							ChooseDuckHouse.CollectInput(farm, new Duck());
						} else {
							Console.WriteLine("You don't have any facilities for this animal!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					case 4:
						if (farm.GrazingFields.Count != 0) {
							ChooseGrazingField.CollectInput(farm, new Goat());
						} else {
							Console.WriteLine("You don't have any facilities for this animal!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					case 5:
						if (farm.GrazingFields.Count != 0) {
							ChooseGrazingField.CollectInput(farm, new Ostrich());
						} else {
							Console.WriteLine("You don't have any facilities for this animal!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					case 6:
						if (farm.GrazingFields.Count != 0) {
							ChooseGrazingField.CollectInput(farm, new Pig());
						} else {
							Console.WriteLine("You don't have any facilities for this animal!");
							Console.WriteLine("Press any key to go to the Create Facility menu");
							Console.ReadLine();
							CreateFacility.CollectInput(farm);
						}
						break;
					case 7:
						if (farm.GrazingFields.Count != 0) {
							ChooseGrazingField.CollectInput(farm, new Sheep());
						} else {
							Console.WriteLine("You don't have any facilities for this animal!");
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