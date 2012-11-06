using GeoDataToolkit.FGDB.IoC;
using GeoDataToolkit.IoC;
using Ninject;

namespace GeoDataToolkit.FGDB.Tests.IoC
{
	internal static class IocHelper
	{
		public static IIocContainer GetIocContainer()
		{
			var standardKernel = new StandardKernel(
									new GeoDataToolkitIoCModule(),
									new GeoDataToolkitFGDBIoCModule());
			var kernel = new NinjectKernel(standardKernel);
			return kernel;
		}
	}
}
