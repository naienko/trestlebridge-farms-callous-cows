using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;

namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing>, IMeatFacility<IMeatProducing>, ICompostFacility<ICompostProducing>
    {
        private int _capacity = 2;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals {
            get {
                List<IGrazing> castMeat = _meatAnimals.Cast<IGrazing>().ToList();
                List<IGrazing> castCompost = _compostAnimals.Cast<IGrazing>().ToList();
                List<IGrazing> _group = new List<IGrazing>();
                _group.AddRange(castCompost);
                _group.AddRange(castMeat);
                return _group;
            }
        }

        private List<IMeatProducing> _meatAnimals = new List<IMeatProducing>();
        private List<ICompostProducing> _compostAnimals = new List<ICompostProducing>();

        public string Type { get; } = "Grazing Field";

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public List<IGrazing> Animals {
            get {
                return _animals;
            }
        }
        public List<IMeatProducing> MeatAnimals {
            get {
                return _meatAnimals;
            }
        }
        public List<ICompostProducing> CompostResource {
            get {
                return _compostAnimals;
            }
        }

		public void AddResource (Farm farm, IGrazing animal)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
                if (animal.Type == "Goat") {
                    _compostAnimals.Add(animal as ICompostProducing);
                } else {
                    _meatAnimals.Add(animal as IMeatProducing);
                }
            } else {
                Console.Clear();
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                Console.WriteLine();
                ChooseGrazingField.CollectInput(farm, animal);
            }
        }

        public void AddResource (List<IGrazing> animals)
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
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

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}