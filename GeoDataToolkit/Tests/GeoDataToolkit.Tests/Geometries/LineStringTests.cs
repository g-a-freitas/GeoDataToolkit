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
	public class LineStringTests
	{
		[Test]
		public void LineStringSimpleTest()
		{
			var lineString = new LineString();
			lineString.Vertices.Add(new MapPoint(10, 20));
			lineString.Vertices.Add(new MapPoint(20, 30));
			lineString.Vertices.Add(new MapPoint(30, 40));
			lineString.SpatialReference = new SpatialReference(102100);

			//Asserts
			lineString.GeometryType.Should().Be(GeometryTypes.LineString);		
			lineString.SpatialReference.Wkid.Should().Be(102100);
			lineString.Envelope.MaxX.Should().Be(30);
			lineString.Envelope.MaxY.Should().Be(40);
			lineString.Envelope.MinX.Should().Be(10);
			lineString.Envelope.MinY.Should().Be(20);			
		}
	}
}
