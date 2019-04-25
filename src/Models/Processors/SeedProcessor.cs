using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Processors {
	public class SeedProcessor {
		public List<Material<SeedProcessor>> Materials { get; set; } = new List<Material<SeedProcessor>>();
		public int Capacity { get; } = 5;
		public List<Material<SeedProcessor>> Output { get; set; } = new List<Material<SeedProcessor>>();
	}
}