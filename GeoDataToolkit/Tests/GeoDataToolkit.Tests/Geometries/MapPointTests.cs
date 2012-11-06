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
	public class MapPointTests
	{
		[Test]
		public void MapPointConstructorTest()
		{
			var point = new MapPoint();
			point.X.Should().Be(0);
			point.Y.Should().Be(0);
			point.SpatialReference.Should().Be.Null();
		}

		[Test]
		public void MapPointTest()
		{
			var point = new MapPoint(10,20);
			point.SpatialReference = new SpatialReference(102100);

			//Asserts
			point.GeometryType.Should().Be(GeometryTypes.Point);
			point.SpatialReference.Wkid.Should().Be(102100);
			point.X.Should().Be(10);
			point.Y.Should().Be(20);			
			point.Envelope.MaxX.Should().Be(10);
			point.Envelope.MaxY.Should().Be(20);
			point.Envelope.MinX.Should().Be(10);
			point.Envelope.MinY.Should().Be(20);			
		}
	}
}
