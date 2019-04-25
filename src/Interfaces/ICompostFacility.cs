using System.Collections.Generic;

namespace Trestlebridge.Interfaces {
	public interface ICompostFacility<T>
	{
		string Type { get; }
		List<T> CompostResource { get; }
	}
}