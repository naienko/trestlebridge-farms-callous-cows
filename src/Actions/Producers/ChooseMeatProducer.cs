using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Interfaces;
using Trestlebridge.HashBox;

namespace Trestlebridge.Actions.Producers
{
	public class ChooseMeatProducer
	{
		public static void CollectInput(Farm farm)
		{
			List<IMeatProcess<someTypeHere>> wheresTheMeat = new List<IMeatProcess<someTypeHere>>();
			// type constraints?
			foreach (GrazingField field in farm.GrazingFields)
			{
				// Console.WriteLine($"{farm.GrazingFields.IndexOf(field) + 1}. Grazing Field ({field.Animals.Count} animals)");

				wheresTheMeat.Add(field);
			}
			foreach (IMeatProcess<someTypeHere> house in farm.ChickenHouses)
			{
				// Console.WriteLine($"{farm.ChickenHouses.IndexOf(house) + 1 + farm.GrazingFields.Count}. Chicken House ({house.Chickens.Count} chickens)");
				wheresTheMeat.Add(house);
			}
			foreach (IMeatProcess<someTypeHere> house in farm.DuckHouses)
			{
				// Console.WriteLine($"{farm.DuckHouses.IndexOf(house) + 1 + farm.GrazingFields.Count + farm.ChickenHouses.Count}. Duck House ({house.Ducks.Count} ducks)");
				wheresTheMeat.Add(house);
			}

			foreach (IMeatProcess<someTypeHere> facility in wheresTheMeat)
			{
				Console.WriteLine($"{wheresTheMeat.IndexOf(facility) + 1}. {facility.Type} ({facility.Animals.Count} animals)");
			}
			Console.WriteLine();
			Console.WriteLine("Which facility has the animals you want to process?");
			
			Console.Write("> ");
			//int choice = Int32.Parse(Console.ReadLine ());
			Console.ReadLine();
			//then jump to list 'type and count of animals' in chosen facility (hashset)
			

		}
	}
}