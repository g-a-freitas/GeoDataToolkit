using System.Collections.Generic;

namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// multiParts
	/// </summary>
	public interface IMultiParts : IGeometry
	{
		/// <summary>
		/// Linear rings
		/// </summary>
		IList<ILineString> Parts { get; }
	}
}
