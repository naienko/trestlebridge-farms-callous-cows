using System.Collections.Generic;

namespace Trestlebridge.Interfaces {
	public interface IMeatFacility<T>
	{
		string Type { get; }
		string shortId { get; }
		List<T> MeatResource { get; }
	}
}