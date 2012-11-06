namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Polygon
	/// </summary>
	internal class Polygon : MultiParts
	{
		#region Properties

		/// <summary>
		/// Geometry Type
		/// </summary>
		public override GeometryTypes GeometryType
		{
			get { return GeometryTypes.Polygon; }
		}

		#endregion
	}
}
