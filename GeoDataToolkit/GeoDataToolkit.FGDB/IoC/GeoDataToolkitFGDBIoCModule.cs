using GeoDataToolkit.Accessors;
using GeoDataToolkit.FGDB.Accessors;
using Ninject.Modules;

namespace GeoDataToolkit.FGDB.IoC
{
	/// <summary>
	/// Classe de inicialização de depedências para o ImportadorDashboardSondagem
	/// </summary>
	public class GeoDataToolkitFGDBIoCModule : NinjectModule
	{
		/// <summary>
		/// Inicialização do Módulo de IoC.
		/// </summary>
		public override void Load()
		{
			this.Bind<IDatasetReader>().To<FgdbDatasetReader>();
		}
	}
}