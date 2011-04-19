﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.MicroKernel.Registration;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Web.Windsor
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
			return AllTypes.FromAssemblyContaining<Musica>()
				.BasedOn<IRepositorio<Musica>>()
				.BasedOn<IRepositorio<Usuario>>();
		}
	}
}