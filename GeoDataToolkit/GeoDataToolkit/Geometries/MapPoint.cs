namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// MapPoint
	/// </summary>
	internal class MapPoint : Geometry, IMapPoint
	{
		#region Fields

		/// <summary>
		/// Envelope
		/// </summary>
		private IEnvelope _envelope;

		#endregion

		#region Properties

		/// <summary>
		/// X part of coordinate
		/// </summary>
		public double X { get; set; }

		/// <summary>
		/// Y part of coordinate
		/// </summary>
		public double Y { get; set; }

		/// <summary>
		/// Envelope
		/// </summary>
		public override IEnvelope Envelope
		{
			get
			{
				return _envelope ?? (_envelope = new Envelope(X, Y, X, Y));
			}
			set { _envelope = value; }
		}

		/// <summary>
		/// Geometry Type
		/// </summary>
		public override GeometryTypes GeometryType
		{
			get { return GeometryTypes.Point; }
		}

		#endregion

		#region Constructor

		public MapPoint()
		{

		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		public MapPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		#endregion
	}
}
