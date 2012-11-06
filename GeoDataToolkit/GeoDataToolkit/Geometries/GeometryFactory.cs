namespace GeoDataToolkit.Geometries
{
	internal class GeometryFactory : IGeometryFactory
	{
		public IMapPoint CreatePoint(double x, double y)
		{
			return new MapPoint(x, y);
		}

		public IMapPoint CreatePoint(double x, double y, int spatialReferenceWkid)
		{
			return new MapPoint(x, y) { SpatialReference = new SpatialReference(spatialReferenceWkid) };
		}

		public IMultiParts CreatePolyline()
		{
			return new Polyline();
		}

		public IMultiParts CreatePolyline(int spatialReferenceWkid)
		{
			return new Polyline { SpatialReference = new SpatialReference(spatialReferenceWkid) };
		}

		public IMultiParts CreatePolygon()
		{
			return new Polygon();
		}

		public IMultiParts CreatePolygon(int spatialReferenceWkid)
		{
			return new Polygon { SpatialReference = new SpatialReference(spatialReferenceWkid) };
		}

		public ILineString CreateLineString()
		{
			return new LineString();
		}

		public IEnvelope CreateEnvelope(double maxX, double maxY, double minX, double minY)
		{
			return new Envelope(maxX, maxY, minX, minY);
		}
	}
}
