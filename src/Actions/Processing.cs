using System;
using System.Collections.Generic;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Actions {
	public class Processing {
		public static void CollectInput (Farm farm) {
			Console.Clear();
			Console.WriteLine ("1. Seed Harvester");
			Console.WriteLine ("2. Meat Processor");
			Console.WriteLine ("3. Egg Gatherer");
			Console.WriteLine ("4. Composter");
			Console.WriteLine ("5. Feather Harvester");

			Console.WriteLine ();
			Console.WriteLine ("Choose equipment to use.");
			Console.Write ("> ");
			
			string choice = Console.ReadLine ();
            Console.Clear();
            switch (Int32.Parse(choice))
			{
				case 1:
					Console.WriteLine("Not available yet");
					CollectInput(farm);
					break;
				case 2:
					//list all of all types of facilities
					foreach (GrazingField field in farm.GrazingFields)
					{
						Console.WriteLine($"{farm.GrazingFields.IndexOf(field)+1}. Grazing Field ({field.Animals.Count} animals)");
					}
					foreach (ChickenHouse house in farm.ChickenHouses)
					{
						Console.WriteLine($"{farm.ChickenHouses.IndexOf(house)+1+farm.GrazingFields.Count}. Chicken House ({house.Chickens.Count} chickens)");
					}
					foreach (DuckHouse house in farm.DuckHouses)
					{
						Console.WriteLine($"{farm.DuckHouses.IndexOf(house)+1+farm.GrazingFields.Count+farm.ChickenHouses.Count}. Duck House ({house.Ducks.Count} ducks)");
					}
					Console.Write ("> ");
					Console.ReadLine();
					//then jump to list 'type and count of animals' in chosen facility (hashset)
					//at what point do I break out into a different file?
					break;
				case 3:
					Console.WriteLine("Not available yet");
					CollectInput(farm);
					break;
				case 4:
					Console.WriteLine("Not available yet");
					CollectInput(farm);
					break;
				case 5:
					Console.WriteLine("Not available yet");
					CollectInput(farm);
					break;
				default:
					break;
			}
		}
	}
}