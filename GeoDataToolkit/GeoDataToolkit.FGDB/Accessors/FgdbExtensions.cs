using GeoDataToolkit.Accessors;
using GeoDataToolkit.Geometries;
using Esri.FileGDB;

namespace GeoDataToolkit.FGDB.Accessors
{
	internal static class FgdbExtensions
	{
		public static IDatasetRow ToFeatureRow(this Row row, ISpatialReference spatialReference)
		{
			return new FgdbDatasetRow(row, spatialReference);
		}
	}
}
