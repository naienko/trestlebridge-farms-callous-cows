using System;
using System.Collections.Generic;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions.Producers;

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
					ChooseMeatProducer.CollectInput(farm);
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