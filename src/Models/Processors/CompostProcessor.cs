using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Processors {
	public class CompostProcessor {
		public List<Dictionary<int, IResource<CompostProcessor>>> Materials { get; set; } = new List<Dictionary<int,IResource<CompostProcessor>>>();
		public int Capacity { get; } = 5;
		public List<Dictionary<IResource<CompostProcessor>, double>> Output { get; set; } = new List<Dictionary<IResource<CompostProcessor>, double>>();
	}
}