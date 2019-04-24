using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Processors {
	public class SeedProcessor {
		public List<Dictionary<int, IResource<SeedProcessor>>> Materials { get; set; } = new List<Dictionary<int,IResource<SeedProcessor>>>();
		public int Capacity { get; } = 5;
		public List<Dictionary<IResource<SeedProcessor>, double>> Output { get; set; } = new List<Dictionary<IResource<SeedProcessor>, double>>();
	}
}