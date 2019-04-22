using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class PurchaseStock {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Chicken");
            Console.WriteLine ("2. Cow");
            Console.WriteLine ("3. Duck");
            Console.WriteLine ("4. Goat");
            Console.WriteLine ("5. Ostrich");
            Console.WriteLine ("6. Pig");
            Console.WriteLine ("7. Sheep");

            Console.WriteLine ();
            Console.WriteLine ("What are you buying today?");

            Console.Write ("> ");
            string choice = Console.ReadLine ();

            switch (Int32.Parse(choice))
            {
                case 2:
                    ChooseGrazingField.CollectInput(farm, new Cow());
                    break;
                default:
                    break;
            }
        }
    }
}