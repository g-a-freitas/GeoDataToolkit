using GeoDataToolkit.Geometries;
using Ninject.Modules;

namespace GeoDataToolkit.IoC
{
	/// <summary>
	/// Classe de inicialização do injetor de depedências
	/// </summary>
	public class GeoDataToolkitIoCModule : NinjectModule
	{
		/// <summary>
		/// Inicialização do Módulo de IoC.
		/// </summary>
		public override void Load()
		{
			this.Bind<IGeometryFactory>().To<GeometryFactory>();
		}
	}
}