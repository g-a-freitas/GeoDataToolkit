namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// multiParts
	/// </summary>
	internal class Polyline : MultiParts
	{
		#region Properties

		/// <summary>
		/// Geometry Type
		/// </summary>
		public override GeometryTypes GeometryType
		{
			get { return GeometryTypes.Polyline; }
		}

		#endregion
	}
}
