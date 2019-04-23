using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<Duck>, IMeatFacility
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _ducks = new List<Duck>();

        public string Type { get; } = "Duck house";

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public List<Duck> Ducks {
            get {
                return _ducks;
            }
        }

        public void AddResource (Farm farm, Duck bird)
        {
            if (_ducks.Count < _capacity) {
                _ducks.Add(bird);
            } else {
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                ChooseDuckHouse.CollectInput(farm, bird);
            }
        }

      public void AddResource (List<Duck> birds)
        {
            if (_ducks.Count + birds.Count <= _capacity) {
                _ducks.AddRange(birds);
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

            output.Append($"Duck house {shortId} has {this._ducks.Count} ducks\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}