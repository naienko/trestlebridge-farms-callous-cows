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

        private List<Chicken> _animals {
            get {
                List<Chicken> castMeat = _meatAnimals.Cast<Chicken>().ToList();
                // List<Chicken> _group = new List<Chicken>();
                // _group.AddRange(castMeat);
                // return _group;
                return castMeat;
            }
        }
        private List<IMeatProducing> _meatAnimals = new List<IMeatProducing>();

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
        public List<IMeatProducing> MeatAnimals {
            get {
                return _meatAnimals;
            }
        }

        public void AddResource (Farm farm, Chicken bird)
        {
            if (_animals.Count < _capacity) {
                //_meatAnimals.Add(bird);
                _meatAnimals.Add(bird as IMeatProducing);
            } else {
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                ChooseChickenHouse.CollectInput(farm, bird);
            }
        }

      public void AddResource (List<Chicken> birds)
        {
            if (_meatAnimals.Count + birds.Count <= _capacity) {
                _meatAnimals.AddRange(birds);
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

            output.Append($"Chicken house {shortId} has {this._meatAnimals.Count} chickens\n");
            this._meatAnimals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}