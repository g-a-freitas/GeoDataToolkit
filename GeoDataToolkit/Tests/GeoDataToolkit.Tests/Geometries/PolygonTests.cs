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
	class PolylineTests
	{
		[Test]
		public void TestPolyline()
		{
			var polygon = new Polyline();
			
			var lineString = new LineString();
			lineString.Vertices.Add(new MapPoint(10,20));
			lineString.Vertices.Add(new MapPoint(20,30));
			lineString.Vertices.Add(new MapPoint(30,40));
			polygon.Parts.Add(lineString);
			polygon.SpatialReference = new SpatialReference(102100);

			//Asserts
			polygon.GeometryType.Should().Be(GeometryTypes.Polyline);
			polygon.Parts.Count.Should().Be(1);
			polygon.Parts[0].Vertices.Count.Should().Be(3);
			polygon.SpatialReference.Wkid.Should().Be(102100);
			polygon.Envelope.MaxX.Should().Be(30);
			polygon.Envelope.MaxY.Should().Be(40);
			polygon.Envelope.MinX.Should().Be(10);
			polygon.Envelope.MinY.Should().Be(20);
		}
	}
}
