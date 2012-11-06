using GeoDataToolkit.Accessors;
using GeoDataToolkit.FGDB.Accessors.Converter;
using GeoDataToolkit.Geometries;
using System;
using Esri.FileGDB;

namespace GeoDataToolkit.FGDB.Accessors
{
	internal class FgdbDatasetRow : IDatasetRow
	{
		private readonly Row _row;
		private readonly ISpatialReference _spatialReference;

		public FgdbDatasetRow(Row row, ISpatialReference spatialReference)
		{
			_row = row;
			_spatialReference = spatialReference;
		}

		public bool IsNull(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.IsNull(fieldName);
		}

		public string GetString(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.GetString(fieldName);
		}

		public short GetShort(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.GetShort(fieldName);
		}

		public int GetInteger(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.GetInteger(fieldName);
		}

		public DateTime GetDate(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.GetDate(fieldName);
		}

		public double GetDouble(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.GetDouble(fieldName);
		}

		public float GetFloat(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.GetFloat(fieldName);
		}

		public int GetOid(string fieldName)
		{
			ThrowIfRowNotInitialized();

			return _row.GetOID();
		}

		public IGeometry GetGeometry()
		{
			ThrowIfRowNotInitialized();

			var geometry = _row.GetGeometry().ToGeneralGeometry(_spatialReference);
			return geometry;
		}

		private void ThrowIfRowNotInitialized()
		{
			if (_row == null)
			{
				throw new NullReferenceException("Row was not initialized");
			}
		}
	}
}
