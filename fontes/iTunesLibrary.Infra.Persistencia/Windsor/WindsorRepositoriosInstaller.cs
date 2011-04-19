using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.MicroKernel.Registration;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Infra.Persistencia.Windsor
{
	public class WindsorRepositoriosInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(FindRepositorios().Configure(ConfigureRepositorios()));
		}

		private ConfigureDelegate ConfigureRepositorios()
		{
			return c => c.LifeStyle.Singleton;
		}

		private BasedOnDescriptor FindRepositorios()
		{
			return AllTypes.FromThisAssembly()
				.BasedOn(typeof(IRepositorio<>)).WithService.Base();
		}
	}
}