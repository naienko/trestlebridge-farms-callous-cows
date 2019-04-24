using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : ICompostProducing
    {
		private double _compostProduced = 30.3;
        public string Type { get; } = "Wildflower";

		public double Process (CompostProcessor equipment) {
            return _compostProduced;
        }

        public override string ToString () {
            return $"Wildflower. Beautiful!";
        }
    }
}