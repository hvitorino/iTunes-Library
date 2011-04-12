using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Restfulie.Server;
using Restfulie.Server.Results;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Controllers
{
	[ActAsRestfulie]
	public class UsuarioController : RecursoController<Usuario>
	{
		private Usuario usuario = new Usuario
		{
			Id = Guid.NewGuid(),
			Nome = "hvitorino",
			Biblioteca = new Biblioteca
			{
				Listas = new List<Lista> 
				{
					new Lista
					{
						Nome = "Classic Rock",
						Musicas = new List<Musica> 
						{
							new Musica 
							{
								Nome = "Fire",
								Artista = "Jimi Hendrix"
							},
							new Musica 
							{
								Nome = "Hey Joe",
								Artista = "Jimi Hendrix"
							},
							new Musica 
							{
								Nome = "All Along The Watchtower",
								Artista = "Jimi Hendrix"
							},
							new Musica 
							{
								Nome = "Iron Maiden",
								Artista = "Iron Maiden"
							},
							new Musica 
							{
								Nome = "Hallowed Be Thy Name",
								Artista = "Iron Maiden"
							}
						}
					}
				}
			}
		};

		//
		// GET: /login-usuario/musicas/

		public ActionResult Biblioteca(string idUsuario)
		{
			ViewData[ "Biblioteca" ] = usuario.Biblioteca;

			return new OK();
		}
	}
}