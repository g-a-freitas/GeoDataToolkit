Introduction
===========

**GeoDataToolkit** is a toolkit library developed by Imagem to manipulate data in ESRI geographic datasets, based on filesystem.
Its design intends to abstract the ESRI APIs details and references, supplying general interfaces for operations like reading and writing data in a database.
The project is based on Dependency Injection, currently using NInject.

Example
-----------

```c#
var datasetReader = _container.Resolve<IDatasetReader>();
datasetReader.SetSetting("GDB_PATH", "Resources/FileGDB/FileGeoDBTests.gdb");
datasetReader.Initialize();
var featureSet = datasetReader.ReadFeatureSet("\\TableSample");

foreach (var row in featureSet.GetFeatures())
{
  var stringField = row.GetString("EMPRESA");
	var polygon = (IMultiParts) row.GetGeometry();
	var verticesCount = polygon.Parts[0].Vertices.Count;
}

var projectionWKID = featureSet.SpatialReference.Wkid;
```


Roadmap
-----------
Currently the GeoDataToolkit supports reading Filegeodatabases datasets like Tables and Feature Classes (Point, Polyline and Polygon).

There are a list of opened [issues](/imagem/GeoDataToolkit/issues) of improvement for the project. In our vision, the next main steps are:

* FileGeodatabase Writer
* Shapefile Reader
* Shapefile Writer

The project is open for new ideas - fell free to suggest!

Environment
-----------
This is the current development environment we are using:

*  Visual Studio 2010
* .NET Framework 4.0

Resources
---------
*	[ESRI FileGeodatabase API](http://resources.arcgis.com/content/geodatabases/10.0/file-gdb-api)
* Post about [Filegeodatabase API and the GeoDataTookit] (http://www.gis4dev.com.br/?p=536) (in Portuguese)