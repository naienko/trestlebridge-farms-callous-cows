using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Animals {
    public class Sheep : IGrazing, IMeatProducing {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 5;

        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double GrassPerDay { get; set; } = 5.4;
        public string Type { get; } = "Sheep";

        // Methods
        public void Graze () {
            Console.WriteLine($"Sheep {this._shortId} just ate {this.GrassPerDay}kg of grass");
        }

        public double Process (MeatProcessor equipment) {
            return _meatProduced;
        }

        public override string ToString () {
            return $"Sheep {this._shortId}. Baaa!";
        }
    }
}