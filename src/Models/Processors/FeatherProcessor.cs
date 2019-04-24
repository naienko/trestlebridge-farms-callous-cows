using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Processors {
	public class FeatherProcessor {
		public List<Dictionary<int, IResource<FeatherProcessor>>> Materials { get; set; } = new List<Dictionary<int,IResource<FeatherProcessor>>>();
		public int Capacity { get; } = 5;
		public List<Dictionary<IResource<FeatherProcessor>, double>> Output { get; set; } = new List<Dictionary<IResource<FeatherProcessor>, double>>();
	}
}