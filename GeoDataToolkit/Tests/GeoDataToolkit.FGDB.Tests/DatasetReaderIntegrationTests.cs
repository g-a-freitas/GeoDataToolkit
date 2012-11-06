using System.Linq;
using GeoDataToolkit.Accessors;
using GeoDataToolkit.FGDB.Accessors;
using GeoDataToolkit.FGDB.Tests.IoC;
using GeoDataToolkit.Geometries;
using System;
using GeoDataToolkit.IoC;
using NUnit.Framework;
using SharpTestsEx;

namespace GeoDataToolkit.FGDB.Tests
{
	[TestFixture]
	public class DatasetReaderIntegrationTests
	{
		private IDatasetReader _datasetReader;
		private IIocContainer _container;
		
		[TestFixtureSetUp]
		public void TestFixtureSetup()
		{
			_container = IocHelper.GetIocContainer();
		}

		[SetUp]
		public void TestSetup()
		{
			_datasetReader = _container.Resolve<IDatasetReader>();
			_datasetReader.SetSetting("GDB_PATH", "Resources/FileGDB/FileGeoDBTests.gdb");
			_datasetReader.Initialize();
		}

		[TearDown]
		public void TestTearDown()
		{
			_datasetReader.Release();
		}

		[Test]
		public void TestInitializeFailed()
		{
			var reader = new FgdbDatasetReader();
			reader.SetSetting("GDB_PATH", "Path that does not exists");
			(new Action(reader.Initialize)).Should().Throw();
		}

		[Test]
		public void TestLoadDataWithoutInitializing()
		{
			var reader = new FgdbDatasetReader();
			(new Action(() => reader.ReadFeatureSet("\\GeoSource\\PolygonSample").GetFeatures().Count())).Should().Throw();
		}

		[Test]
		public void TestReadFeatureAttributes()
		{
			var featureSet = _datasetReader.ReadFeatureSet("\\GeoSource\\PolygonSample");

			var hasRows = false;
			foreach (var row in featureSet.GetFeatures())
			{
				hasRows = true;
				row.GetShort("CODIGO").Should().Be.GreaterThan(0);
				row.IsNull("DESCRICAO").Should().Be.False();
				row.GetString("DESCRICAO").Should().Not.Be.NullOrEmpty();
			}
			hasRows.Should().Be.True();
		}

		[Test]
		public void TestReadSpatialReferenceSad96()
		{
			var featureSet = _datasetReader.ReadFeatureSet("\\GeoSource\\PointSample");
			featureSet.SpatialReference.Wkid.Should().Be.EqualTo(4618); //SAD69
		}

		[Test]
		public void TestReadSpatialReferenceWgs84()
		{
			var featureSet = _datasetReader.ReadFeatureSet("\\PointWGS84");
			featureSet.SpatialReference.Wkid.Should().Be.EqualTo(4326); //WGS84
		}

		[Test]
		public void TestReadPointGeometryFeatures()
		{
			var featureSet = _datasetReader.ReadFeatureSet("\\GeoSource\\PointSample");

			foreach (var row in featureSet.GetFeatures())
			{
				var geometry = row.GetGeometry();
				geometry.Should().Not.Be.Null();
				geometry.GeometryType.Should().Be.EqualTo(GeometryTypes.Point);
				var point = ((IMapPoint)geometry);
				point.X.Should().Not.Be.EqualTo(0);
				point.Y.Should().Not.Be.EqualTo(0);
			}
		}


		[Test]
		public void TestReadLineGeometryFeatures()
		{
			var featureSet = _datasetReader.ReadFeatureSet("\\GeoSource\\LineSample");

			foreach (var row in featureSet.GetFeatures())
			{
				var geometry = row.GetGeometry();
				geometry.Should().Not.Be.Null();
				geometry.GeometryType.Should().Be.EqualTo(GeometryTypes.Polyline);
				var polyParts = ((IMultiParts)geometry);
				polyParts.Parts.Count.Should().Be.GreaterThanOrEqualTo(1);
				polyParts.Parts[0].Vertices.Count.Should().Be.GreaterThanOrEqualTo(2);
			}
		}

		[Test]
		public void TestReadPolygonGeometryFeatures()
		{
			var featureSet = _datasetReader.ReadFeatureSet("\\GeoSource\\PolygonSample");

			foreach (var row in featureSet.GetFeatures())
			{
				var geometry = row.GetGeometry();
				geometry.Should().Not.Be.Null();
				geometry.GeometryType.Should().Be.EqualTo(GeometryTypes.Polygon);
				var rings = ((IMultiParts)geometry).Parts;
				rings.Count.Should().Be.GreaterThan(0);
				rings[0].Vertices.Count.Should().Be.GreaterThan(2);
			}
		}

		[Test]
		public void TestLoadingTable()
		{
			var featureSet = _datasetReader.ReadFeatureSet("\\TableSample");

			var hasRows = false;
			foreach (var row in featureSet.GetFeatures())
			{
				hasRows = true;
				row.IsNull("EMPRESA").Should().Be.False();
				row.GetString("EMPRESA").Should().Not.Be.NullOrEmpty();
			}
			hasRows.Should().Be.True();
		}
	}
}
