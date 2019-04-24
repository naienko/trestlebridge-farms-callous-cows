using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : IResource, ISeedProducing
    {
        private int _seedsProduced = 520;
        public string Type { get; } = "Sesame";

        public double Process (SeedProcessor equipment) {
            return _seedsProduced;
        }

        public override string ToString () {
            return $"Sesame. Yum!";
        }
    }
}