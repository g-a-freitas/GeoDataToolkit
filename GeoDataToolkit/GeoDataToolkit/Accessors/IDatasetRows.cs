using System.Collections.Generic;
using GeoDataToolkit.Geometries;

namespace GeoDataToolkit.Accessors
{
	public interface IDatasetRows
	{
		ISpatialReference SpatialReference { get; }

		IEnumerable<IDatasetRow> GetFeatures();
	}
}