using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;

namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<Chicken>, IMeatFacility<IMeatProducing>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _animals = new List<Chicken>();
        private List<IMeatProducing> _meats = new List<IMeatProducing>();

        public string Type { get; } = "Chicken House";
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

        public List<Chicken> Animals {
            get {
                return _animals;
            }
        }
        public List<IMeatProducing> MeatResource {
            get {
                return _meats;
            }
        }

        public void AddResource (Farm farm, Chicken bird)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(bird);
                _meats.Add(bird as IMeatProducing);
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

            output.Append($"Chicken house {shortId} has {this._animals.Count} chickens\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}