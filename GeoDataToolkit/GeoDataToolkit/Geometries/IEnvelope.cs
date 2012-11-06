namespace GeoDataToolkit.Geometries
{
	/// <summary>
	/// Envelope
	/// </summary>
	public interface IEnvelope
	{
		/// <summary>
		/// Max X value
		/// </summary>
		double MaxX { get; }

		/// <summary>
		/// Max Y value
		/// </summary>
		double MaxY { get; }

		/// <summary>
		/// Min X value
		/// </summary>
		double MinX { get; }

		/// <summary>
		/// Min Y value
		/// </summary>
		double MinY { get; }
	}
}
