using GeoDataToolkit.Accessors;
using System;
using System.Collections.Generic;
using System.Configuration;
using Esri.FileGDB;

namespace GeoDataToolkit.FGDB.Accessors
{
	internal class FgdbDatasetReader : IDatasetReader, IDisposable
	{
		private bool _openedGeoDb;
		private Geodatabase _geodatabase;
		private readonly List<Table> _openedTables;

		private readonly Dictionary<string, string> _settings;

		public FgdbDatasetReader()
		{
			_settings = new Dictionary<string, string>();
			_openedTables = new List<Table>();
			_geodatabase = null;
		}

		~FgdbDatasetReader()
		{
			Dispose();
		}

		public void Initialize()
		{
			OpenGeodatabase();
		}

		public void Dispose()
		{
			Release();
		}

		public IDatasetRows ReadFeatureSet(string path)
		{
			if (!_openedGeoDb)
			{
				throw new InvalidOperationException("FileGeodatabase was not open");
			}

			var table = _geodatabase.OpenTable(path);
			_openedTables.Add(table);

			var datasetRows = new FgdbDatasetRows(table);

			return datasetRows;
		}

		public void Release()
		{
			if (_geodatabase != null)
			{
				_openedTables.ForEach(table =>
				                      	{
											table.Close();
				                      		table.Dispose();
				                      	});
				_openedTables.Clear();
				_geodatabase.Close();
				_geodatabase = null;
				_openedGeoDb = false;
			}			
		}

		public void SetSetting(string key, string value)
		{
			if (!_settings.ContainsKey(key))
			{
				_settings.Add(key, value);
			}
			else
			{
				_settings[key] = value;
			}
		}

		public string GetSetting(string key)
		{
			return _settings.ContainsKey(key) ? _settings[key] : null;
		}

		private void OpenGeodatabase()
		{
			if (_openedGeoDb)
			{
				return;
			}

			var fgdbPath = GetSetting("GDB_PATH");
			if (fgdbPath == null)
			{
				throw new SettingsPropertyNotFoundException("The GDB_PATH setting was not found");
			}

			_geodatabase = Geodatabase.Open(fgdbPath);

			_openedGeoDb = true;
		}
	}
}
