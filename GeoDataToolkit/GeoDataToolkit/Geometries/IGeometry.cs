namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Geometry
	/// </summary>
	public interface IGeometry
	{
		/// <summary>
		/// Spatial Reference
		/// </summary>
		ISpatialReference SpatialReference { get; set; }

		/// <summary>
		/// Envelope
		/// </summary>
		IEnvelope Envelope { get; set; }

		/// <summary>
		/// Geometry Type
		/// </summary>
		GeometryTypes GeometryType { get; }
	}
}
