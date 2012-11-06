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
	public class GeometryFactoryTests
	{
		private GeometryFactory _geometryFactory; 

		[SetUp]
		public void SetUp()
		{
			_geometryFactory = new GeometryFactory();
		}

		[Test]
		public void TestCreatePoint()
		{
			var point = _geometryFactory.CreatePoint(10, 20);
			point.X.Should().Be(10);
			point.Y.Should().Be(20);
			point.SpatialReference.Should().Be.Null();
		}

		[Test]
		public void TestCreatePointSpatialRef()
		{
			var point = _geometryFactory.CreatePoint(10, 20, 102100);
			point.X.Should().Be(10);
			point.Y.Should().Be(20);
			point.SpatialReference.Wkid.Should().Be(102100);
		}

		[Test]
		public void CreatePolyline()
		{
			var polyline = _geometryFactory.CreatePolyline(3126);
			polyline.SpatialReference.Wkid.Should().Be(3126);
		}

		[Test]
		public void CreatePolygon()
		{
			var polyline = _geometryFactory.CreatePolygon(3126);
			polyline.SpatialReference.Wkid.Should().Be(3126);
		}

		[Test]
		public void CreateEnvelope()
		{
			var envelope = _geometryFactory.CreateEnvelope(10, 20, 30, 40);
			envelope.MaxX.Should().Be(10);
			envelope.MaxY.Should().Be(20);
			envelope.MinX.Should().Be(30);
			envelope.MinY.Should().Be(40);
		}
	}
}
