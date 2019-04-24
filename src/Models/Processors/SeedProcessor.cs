using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Processors {
	public class SeedProcessor {
		public List<Dictionary<int, IResource>> Materials { get; set; } = new List<Dictionary<int,IResource>>();
		public int Capacity { get; } = 5;
	}
}