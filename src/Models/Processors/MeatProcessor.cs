using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Processors {
	public class MeatProcessor {
		public List<Material<MeatProcessor>> Materials { get; set; } = new List<Material<MeatProcessor>>();
		public int Capacity { get; } = 5;
		public List<Material<MeatProcessor>> Output { get; set; } = new List<Material<MeatProcessor>>();
	}
}