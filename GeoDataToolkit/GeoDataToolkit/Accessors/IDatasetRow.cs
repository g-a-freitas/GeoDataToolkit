using System;
using GeoDataToolkit.Geometries;

namespace GeoDataToolkit.Accessors
{
	public interface IDatasetRow
	{
		bool IsNull(string fieldName);
		string GetString(string fieldName);
		short GetShort(string fieldName);
		int GetInteger(string fieldName);
		DateTime GetDate(string fieldName);
		double GetDouble(string fieldName);
		float GetFloat(string fieldName);
		int GetOid(string fieldName);
		IGeometry GetGeometry();
	}
}