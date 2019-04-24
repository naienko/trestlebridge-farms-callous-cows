using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Animals {
    public class Chicken : IMeatProducing, IEggProducing, IFeatherProducing {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 1.7;
        private int _eggsProduced = 7;
        private double _feathersProduced = 0.5;

        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public string Type { get; } = "Chicken";

        // Methods

        public double Process (MeatProcessor equipment) {
            return _meatProduced;
        }
		
        public double Process (EggProcessor equipment) {
            return _eggsProduced;
        }
        public double Process (FeatherProcessor equipment) {
            return _feathersProduced;
        }

        public override string ToString () {
            return $"Chicken {this._shortId}. Cluck!";
        }

	}
}