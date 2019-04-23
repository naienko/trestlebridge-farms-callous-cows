using System.Collections.Generic;

namespace Trestlebridge.Interfaces {
	public interface IMeatProcess<T>
	{
		string Type { get; }
		List<T> Animals { get; }
	}
}