using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Models.Processors {
	public class CompostProcessor {
		public List<Material<CompostProcessor>> Materials { get; set; } = new List<Material<CompostProcessor>>();
		public int Capacity { get; } = 7;
		public List<Material<CompostProcessor>> Output { get; set; } = new List<Material<CompostProcessor>>();
	}
}