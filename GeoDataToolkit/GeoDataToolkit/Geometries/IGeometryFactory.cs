namespace GeoDataToolkit.Geometries
{
	public interface IGeometryFactory
	{
		IMapPoint CreatePoint(double x, double y);
		IMapPoint CreatePoint(double x, double y, int spatialReferenceWkid);
		IMultiParts CreatePolyline();
		IMultiParts CreatePolyline(int spatialReferenceWkid);
		IMultiParts CreatePolygon();
		IMultiParts CreatePolygon(int spatialReferenceWkid);
		ILineString CreateLineString();
		IEnvelope CreateEnvelope(double maxX, double maxY, double minX, double minY);
	}
}