using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<Duck>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _animals = new List<Duck>();

        public string Type { get; } = "Duck House";
        public string shortId { 
            get {
                return $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
            }
        }

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public List<Duck> Animals {
            get {
                return _animals;
            }
        }

        public void AddResource (Farm farm, Duck bird)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(bird);
            } else {
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                ChooseDuckHouse.CollectInput(farm, bird);
            }
        }

      public void AddResource (List<Duck> birds)
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

            output.Append($"Duck house {shortId} has {this._animals.Count} ducks\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}