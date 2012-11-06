namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Point
	/// </summary>
	public interface IMapPoint : IGeometry
	{
		/// <summary>
		/// X part of coordinate
		/// </summary>
		double X { get; set; }

		/// <summary>
		/// Y part of coordinate
		/// </summary>
		double Y { get; set; }
	}
}
