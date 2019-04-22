using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;


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

        public void AddResource (Chicken bird)
        {
            if (_chickens.Count < _capacity) {
                _chickens.Add(bird);
            }
        }

      public void AddResource (List<Chicken> birds)  // TODO: Take out this method for boilerplate
        {
            if (_chickens.Count + birds.Count <= _capacity) {
                _chickens.AddRange(birds);
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