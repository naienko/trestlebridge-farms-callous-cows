using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Processors {
	public class EggProcessor {
		public List<Dictionary<int, IResource<EggProcessor>>> Materials { get; set; } = new List<Dictionary<int,IResource<EggProcessor>>>();
		public int Capacity { get; } = 5;
		public List<Dictionary<IResource<EggProcessor>, double>> Output { get; set; } = new List<Dictionary<IResource<EggProcessor>, double>>();
	}
}