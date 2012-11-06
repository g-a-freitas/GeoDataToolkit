namespace GeoDataToolkit.Accessors
{
	public interface IDatasetReader
	{
		void Initialize();
		IDatasetRows ReadFeatureSet(string path);
		void Release();
		void SetSetting(string key, string value);
		string GetSetting(string key);
	}
}