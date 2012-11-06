using System.Collections.Generic;

namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Linestring
	/// </summary>
	public interface ILineString : IGeometry
	{
		/// <summary>
		/// Points
		/// </summary>
		IList<IMapPoint> Vertices { get; }
	}
}
