using System;
using System.Collections.Generic;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Actions {
	public class Processing {
		public static void CollectInput (Farm farm) {
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
					List<IMeatFacility> wheresTheMeat = new List<IMeatFacility>();
					foreach (GrazingField field in farm.GrazingFields)
					{
						wheresTheMeat.Add(field);
					}
					foreach (ChickenHouse house in farm.ChickenHouses)
					{
						wheresTheMeat.Add(house);
					}
					foreach (DuckHouse house in farm.DuckHouses)
					{
						wheresTheMeat.Add(house);
					}
					foreach (IMeatFacility facility in wheresTheMeat)
					{
						Console.WriteLine($"{wheresTheMeat.IndexOf(facility)+1}. {facility.Type} ({facility.} animals)");
					}
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