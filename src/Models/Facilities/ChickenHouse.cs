using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<Chicken>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _chickens = new List<Chicken>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public List<Chicken> Chickens {
            get {
                return _chickens;
            }
        }

        public void AddResource (Farm farm, Chicken bird)
        {
            if (_chickens.Count < _capacity) {
                _chickens.Add(bird);
            } else {
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                ChooseChickenHouse.CollectInput(farm, bird);
            }
        }

      public void AddResource (List<Chicken> birds)
        {
            if (_chickens.Count + birds.Count <= _capacity) {
                _chickens.AddRange(birds);
            } else {
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadLine();
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken house {shortId} has {this._chickens.Count} chickens\n");
            this._chickens.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}