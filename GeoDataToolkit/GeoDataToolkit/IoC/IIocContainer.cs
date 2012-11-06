using System;
using System.Collections.Generic;

namespace GeoDataToolkit.IoC
{
	/// <summary>
	/// Contrato do Container de IoC.
	/// </summary>
	public interface IIocContainer
	{
		/// <summary>
		/// Resolve a dependencia retornando a instancia do objeto.
		/// </summary>
		/// <typeparam name="T">Tipo do objeto usado como Id.</typeparam>
		/// <returns>Instancia do objeto.</returns>
		T Resolve<T>();

		/// <summary>
		/// Resolve a dependencia retornando a instancia do objeto.
		/// </summary>
		/// <param name="type">Tipo do objeto usado como Id.</param>
		/// <returns>Instancia do objeto.</returns>
		object Resolve(Type type);

		/// <summary>
		/// Registra novas dependencias.
		/// </summary>
		/// <param name="dependecies">Dicionario com as dependencias e suas resolucoes.</param>
		void RegisterDependencies(IDictionary<Type, object> dependecies);

		/// <summary>
		/// Registra novas dependencias.
		/// </summary>
		/// <param name="dependecies">Objeto específico do container de IoC.</param>
		void RegisterDependencies(object dependecies);
	}
}