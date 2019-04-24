using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, ICompostProducing
    {
        private int _seedsProduced = 650;
		private double _compostProduced = 21.6;
        public string Type { get; } = "Sunflower";

        public double Process (SeedProcessor equipment) {
            return _seedsProduced;
        }
		public double Glean () {
			return _compostProduced;
		}

        public override string ToString () {
            return $"Sunflower. Double-Yum!";
        }
    }
}