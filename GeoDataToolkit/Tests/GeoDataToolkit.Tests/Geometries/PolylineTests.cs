using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDataToolkit.Geometries;
using NUnit.Framework;
using SharpTestsEx;

namespace GeoDataToolkit.Tests.Geometries
{
	[TestFixture]
	class PolygonTests
	{
		[Test]
		public void TestSimplePolygon()
		{
			var polygon = new Polygon();
			
			var lineString = new LineString();
			lineString.Vertices.Add(new MapPoint(10,20));
			lineString.Vertices.Add(new MapPoint(20,30));
			lineString.Vertices.Add(new MapPoint(30,40));
			polygon.Parts.Add(lineString);
			polygon.SpatialReference = new SpatialReference(102100);

			//Asserts
			polygon.GeometryType.Should().Be(GeometryTypes.Polygon);
			polygon.Parts.Count.Should().Be(1);
			polygon.Parts[0].Vertices.Count.Should().Be(3);
			polygon.SpatialReference.Wkid.Should().Be(102100);
			polygon.Envelope.MaxX.Should().Be(30);
			polygon.Envelope.MaxY.Should().Be(40);
			polygon.Envelope.MinX.Should().Be(10);
			polygon.Envelope.MinY.Should().Be(20);
		}

		[Test]
		public void TestMultiPartPolygon()
		{
			var polygon = new Polygon();

			var lineString1 = new LineString();
			lineString1.Vertices.Add(new MapPoint(10, 20));
			lineString1.Vertices.Add(new MapPoint(20, 30));
			lineString1.Vertices.Add(new MapPoint(30, 40));
			lineString1.Vertices.Add(new MapPoint(40, 50));
			polygon.Parts.Add(lineString1);

			var lineString2 = new LineString();
			lineString2.Vertices.Add(new MapPoint(110, 120));
			lineString2.Vertices.Add(new MapPoint(120, 130));
			lineString2.Vertices.Add(new MapPoint(130, 140));
			polygon.Parts.Add(lineString2);
			polygon.SpatialReference = new SpatialReference(102100);

			//Asserts
			polygon.GeometryType.Should().Be(GeometryTypes.Polygon);
			polygon.Parts.Count.Should().Be(2);
			polygon.Parts[0].Vertices.Count.Should().Be(4);
			polygon.SpatialReference.Wkid.Should().Be(102100);
			polygon.Envelope.MaxX.Should().Be(130);
			polygon.Envelope.MaxY.Should().Be(140);
			polygon.Envelope.MinX.Should().Be(10);
			polygon.Envelope.MinY.Should().Be(20);
		}
	}
}
