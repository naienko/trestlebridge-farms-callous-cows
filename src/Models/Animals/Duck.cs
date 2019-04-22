using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Duck : IResource {

        private Guid _id = Guid.NewGuid();

        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public string Type { get; } = "Duck";

        // Methods

        public override string ToString () {
            return $"Duck {this._shortId}. Quack!";
        }
    }
}