using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<Chicken>, IMeatProcess<Chicken>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _animals = new List<Chicken>();

        public string Type { get; } = "Chicken House";

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public List<Chicken> Animals {
            get {
                return _animals;
            }
        }

        public void AddResource (Farm farm, Chicken bird)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(bird);
            } else {
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                ChooseChickenHouse.CollectInput(farm, bird);
            }
        }

      public void AddResource (List<Chicken> birds)
        {
            if (_animals.Count + birds.Count <= _capacity) {
                _animals.AddRange(birds);
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

            output.Append($"Chicken house {shortId} has {this._animals.Count} chickens\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}