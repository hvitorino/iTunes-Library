using System.Web.Mvc;

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;

using iTunesLibrary.Web;
using iTunesLibrary.Web.Controllers;

namespace iTunesLibrary.Web.Windsor
{
	public class WindsorControllersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(FindControllers().Configure(ConfigureControllers()));
		}

		private ConfigureDelegate ConfigureControllers()
		{
			return c => c.LifeStyle.Transient;
		}

		private BasedOnDescriptor FindControllers()
		{
			return AllTypes.FromThisAssembly()
				.BasedOn<Controller>();
		}
	}
}