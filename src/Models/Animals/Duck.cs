using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Duck : IResource, IEggProducing, IFeatherProducing {

        private Guid _id = Guid.NewGuid();

        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        private int _eggsProduced = 6;
        private double _feathersProduced = 0.75;

        public string Type { get; } = "Duck";

        // Methods
        public int Retrieve () {
            return _eggsProduced;
        }
        public double Pluck () {
            return _feathersProduced;
        }

        public override string ToString () {
            return $"Duck {this._shortId}. Quack!";
        }
    }
}