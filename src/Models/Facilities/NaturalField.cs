using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<ICompostProducing>, ICompostFacility<ICompostProducing>
    {
        private int _capacity = 10;
        private Guid _id = Guid.NewGuid();

        private List<ICompostProducing> _plants = new List<ICompostProducing>();

        public string Type { get; } = "Natural Field";

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public List<ICompostProducing> Plants {
            get {
                return _plants;
            }
        }
        public List<ICompostProducing> CompostResource {
            get {
                return _plants;
            }
        }

        public void AddResource (Farm farm, ICompostProducing plant)
        {
            if (_plants.Count < _capacity) {
                _plants.Add(plant);
            } else {
                Console.WriteLine("**** That facility is not large enough ****");
                Console.WriteLine("****     Please choose another one     ****");
                ChooseNaturalField.CollectInput(farm, plant);
            }
        }

      public void AddResource (List<ICompostProducing> plants)  // TODO: Take out this method for boilerplate
        {
            if (_plants.Count + plants.Count <= _capacity) {
                _plants.AddRange(plants);
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

            output.Append($"Natural field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}