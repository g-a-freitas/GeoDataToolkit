using GeoDataToolkit.Accessors;
using GeoDataToolkit.Geometries;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Esri.FileGDB;

namespace GeoDataToolkit.FGDB.Accessors
{
	internal class FgdbDatasetRows : IDatasetRows
	{
		private readonly Table _table;

		public FgdbDatasetRows(Table table)
		{
			_table = table;
			SpatialReference = GetSpatialReference(table.Definition);
		}

		public ISpatialReference SpatialReference { get; internal set; }

		public IEnumerable<IDatasetRow> GetFeatures()
		{
			var rows = _table.Search("*", "", RowInstance.Recycle);
			foreach (var row in rows)
			{
				yield return row.ToFeatureRow(SpatialReference);
			}
		}

		private static ISpatialReference GetSpatialReference(string tableDefinitionXml)
		{
			var elements = XElement.Parse(tableDefinitionXml);
			var spatialReference = elements.Elements().FirstOrDefault(x => x.Name == "SpatialReference");
			if (spatialReference == null)
			{
				return null;
			}

			var wkidNode = spatialReference.Elements().FirstOrDefault(x => x.Name == "WKID");
			if (wkidNode == null)
			{
				return null;
			}

			int wkid;
			if (int.TryParse(wkidNode.Value, NumberStyles.Integer, null, out wkid))
			{
				return new SpatialReference(wkid);
			}
			return null;
		}
	}
}
