using System.Collections.Generic;

namespace Trestlebridge.Interfaces {
	public interface IMeatFacility<T>
	{
		string Type { get; }
		List<T> Animals { get; }
	}
}