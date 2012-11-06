using GeoDataToolkit.Geometries;
using System;
using Esri.FileGDB;

namespace GeoDataToolkit.FGDB.Accessors.Converter
{
	internal static class FgdbGeometryConverterExtensions
	{
		public static IGeometry ToGeneralGeometry(this ShapeBuffer fgdbGeometry, ISpatialReference spatialReference)
		{
			var geometryType = ShapeBuffer.GetGeometryType(fgdbGeometry.shapeType);

			IGeometry geometry;
			if (geometryType.ToString() == GeometryType.Point.ToString())
			{
				geometry = ToGeneralPoint(fgdbGeometry);
			}
			else if (geometryType.ToString() == GeometryType.Polygon.ToString())
			{
				geometry = ToGeneralMultiPart(fgdbGeometry, GeometryType.Polygon);
			}
			else if (geometryType.ToString() == GeometryType.Polyline.ToString())
			{
				geometry = ToGeneralMultiPart(fgdbGeometry, GeometryType.Polyline);
			}
			else if (geometryType.ToString() == GeometryType.Multipoint.ToString())
			{
				geometry = ToGeneralMultiPoint(fgdbGeometry);
			}
			else
			{
				throw new NotSupportedException(String.Format("The geometry type {0} cannot be read", geometryType));
			}

			geometry.SpatialReference = spatialReference;
			return geometry;
		}

		private static IMapPoint ToGeneralPoint(PointShapeBuffer point)
		{
			var pointGeo = new GeometryFactory().CreatePoint(point.point.x, point.point.y);
			return pointGeo;
		}

		private static ILineString ToGeneralMultiPoint(MultiPointShapeBuffer multiPoint)
		{
			var lineExtent = new GeometryFactory().CreateEnvelope(multiPoint.Extent.xMax, multiPoint.Extent.yMax, multiPoint.Extent.xMin, multiPoint.Extent.yMin);

			var lineGeo = new GeometryFactory().CreateLineString();
			lineGeo.Envelope = lineExtent;
			var vertices = lineGeo.Vertices;
			for (var i = 0; i < multiPoint.NumPoints; i++)
			{
				var mapPoint = new GeometryFactory().CreatePoint(multiPoint.Points[i].x, multiPoint.Points[i].y);
				vertices.Add(mapPoint);
			}

			return lineGeo;
		}

		private static IMultiParts ToGeneralMultiPart(MultiPartShapeBuffer multiPart, GeometryType geometryType)
		{
			IMultiParts multiParts;
			if (geometryType == GeometryType.Polyline)
			{
				multiParts = new GeometryFactory().CreatePolyline();
			}
			else
			{
				multiParts = new GeometryFactory().CreatePolygon();
			}

			var rings = multiParts.Parts;
			for (var i = 0; i < multiPart.NumParts; i++)
			{

				var partStart = multiPart.Parts[i];

				int partEnd;
				if (i + 1 < multiPart.NumParts)
				{
					partEnd = multiPart.Parts[i + 1];
				}
				else
				{
					partEnd = multiPart.NumPoints - 1;
				}

				var linearRing = new GeometryFactory().CreateLineString();
				var points = linearRing.Vertices;
				for (var j = partStart; j <= partEnd; j++)
				{
					var mapPoint = new GeometryFactory().CreatePoint(multiPart.Points[i].x, multiPart.Points[i].y);

					points.Add(mapPoint);
				}

				rings.Add(linearRing);
			}
			return multiParts;
		}
	}
}
