namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Geometry
	/// </summary>
	internal abstract class Geometry : IGeometry
	{
		/// <summary>
		/// Spatial Reference
		/// </summary>
		public ISpatialReference SpatialReference { get; set; }

		/// <summary>
		/// Envelope
		/// </summary>
		public abstract IEnvelope Envelope { get; set; }

		/// <summary>
		/// Geometry Type
		/// </summary>
		public abstract GeometryTypes GeometryType { get; }
	}
}
