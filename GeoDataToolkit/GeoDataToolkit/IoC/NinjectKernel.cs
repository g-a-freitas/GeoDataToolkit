using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Modules;

namespace GeoDataToolkit.IoC
{
	/// <summary>
	/// Classe de controle central de IoC.
	/// </summary>
	public class NinjectKernel : IIocContainer
	{
		#region Fields and Constants

		private readonly IKernel _kernel;

		#endregion

		#region Constructor

		/// <summary>
		/// Construtor do IocKernelContainer.
		/// </summary>
		public NinjectKernel(StandardKernel standardKernel)
		{
			this._kernel = standardKernel;
		}

		#endregion

		#region IoCContainer Implementation

		/// <summary>
		/// Gets Obtém o kernel do IoC.
		/// </summary>
		public object Kernel
		{
			get { return this._kernel; }
		}

		/// <summary>
		/// Resolve a dependência retornando a instância do objeto.
		/// </summary>
		/// <typeparam name="T">Tipo do objeto.</typeparam>
		/// <returns>Instância do objeto.</returns>
		public T Resolve<T>()
		{
			return this._kernel.Get<T>();
		}

		/// <summary>
		/// Resolve a dependência retornando a instância do objeto.
		/// </summary>
		/// <param name="type">Tipo do objeto.</param>
		/// <returns>Instância do objeto.</returns>
		public object Resolve(Type type)
		{
			return this._kernel.Get(type);
		}

		/// <summary>
		/// Registra novas dependências.
		/// </summary>
		/// <param name="dependecies">Dicionário com as dependências e suas resoluções.</param>
		public void RegisterDependencies(IDictionary<Type, object> dependecies)
		{
			foreach (var item in dependecies)
			{
				this._kernel.Bind(item.Key).ToConstant(item.Value);
			}
		}

		/// <summary>
		/// Registra novas dependências.
		/// </summary>
		/// <param name="dependecies">Objeto do tipo INinjectModule.</param>
		public void RegisterDependencies(object dependecies)
		{
			if (dependecies.GetType() is INinjectModule)
			{
				throw new ArgumentException("O objeto de dependencias deve ser um INinjectModule");
			}

			var ninjModule = (INinjectModule)dependecies;
			this._kernel.Load(ninjModule);
		}

		#endregion
	}
}