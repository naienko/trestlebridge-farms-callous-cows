using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Processors
{
	public class Material<T>
	{
		public IResource<T> Resource { get; set; }
		public double Count { get; set; }

		public string Facility { get; set; }

	}
}