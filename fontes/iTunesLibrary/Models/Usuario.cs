﻿using System;

using Restfulie.Server;

using iTunesLibrary.Web.Controllers;

namespace iTunesLibrary.Web.Models
{
	public class Usuario : IBehaveAsResource
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }

		public void SetRelations(Relations relations)
		{
			relations.Named("this")
				.Uses<UsuarioController>()
				.Inicio();
		}
	}
}