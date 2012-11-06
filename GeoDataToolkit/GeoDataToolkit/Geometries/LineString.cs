using System.Collections.Generic;
using System.Linq;

namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Line string
	/// </summary>
	internal class LineString : Geometry, ILineString
	{
		#region Fields

		/// <summary>
		/// Envelope
		/// </summary>
		private IEnvelope _envelope;

		#endregion

		#region Properties

		/// <summary>
		/// Envelope
		/// </summary>
		public override IEnvelope Envelope
		{
			get
			{
				return _envelope ?? (_envelope = CreateEnvelope());
			}
			set { _envelope = value; }
		}

		/// <summary>
		/// Geometry Type
		/// </summary>
		public override GeometryTypes GeometryType
		{
			get { return GeometryTypes.LineString; }
		}

		/// <summary>
		/// Points
		/// </summary>
		public IList<IMapPoint> Vertices { get; private set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		public LineString()
		{
			Vertices = new List<IMapPoint>();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Create the envelope
		/// </summary>
		/// <returns></returns>
		private IEnvelope CreateEnvelope()
		{
			var maxX = Vertices.Select(x => x.X).Max();
			var maxY = Vertices.Select(x => x.Y).Max();

			var minX = Vertices.Select(x => x.X).Min();
			var minY = Vertices.Select(x => x.Y).Min();

			var envelope = new Envelope(maxX, maxY, minX, minY);

			return envelope;
		}

		#endregion
	}
}
