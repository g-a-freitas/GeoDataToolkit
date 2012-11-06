using System.Collections.Generic;
using System.Linq;

namespace GeoDataToolkit.Geometries
{
	internal abstract class MultiParts : Geometry, IMultiParts
	{
		/// <summary>
		/// Envelope
		/// </summary>
		private IEnvelope _envelope;

		/// <summary>
		/// Constructor
		/// </summary>
		public MultiParts()
		{
			Parts = new List<ILineString>();
		}

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
		/// Parts
		/// </summary>
		public IList<ILineString> Parts { get; private set; }

		/// <summary>
		/// Create the envelope
		/// </summary>
		/// <returns></returns>
		private IEnvelope CreateEnvelope()
		{
			var points = new List<IMapPoint>();

			foreach (var linearRing in Parts)
			{
				points.AddRange(linearRing.Vertices);
			}

			var maxX = points.Select(x => x.X).Max();
			var maxY = points.Select(x => x.Y).Max();

			var minX = points.Select(x => x.X).Min();
			var minY = points.Select(x => x.Y).Min();

			var envelope = new Envelope(maxX, maxY, minX, minY);

			return envelope;
		}
	}
}