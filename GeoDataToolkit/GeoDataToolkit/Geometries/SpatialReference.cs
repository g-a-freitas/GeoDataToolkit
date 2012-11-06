namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Spatial Reference
	/// </summary>
	public class SpatialReference : ISpatialReference
	{
		#region Properties

		/// <summary>
		/// Spatial reference ID
		/// </summary>
		public int Wkid { get; set; }

		#endregion

		#region Constructor


		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="wkid">Spatial reference ID</param>
		public SpatialReference(int wkid)
		{
			this.Wkid = wkid;
		}

		#endregion
	}
}
