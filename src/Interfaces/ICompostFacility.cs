using System.Collections.Generic;

namespace Trestlebridge.Interfaces {
	public interface ICompostFacility<T>
	{
		string Type { get; }
		string shortId { get; }
		List<T> CompostResource { get; }
	}
}