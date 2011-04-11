using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Restfulie.Server.Results;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuario usuario = new Usuario
		{
			Id         = Guid.NewGuid(),
			Nome       = "hvitorino",
			Biblioteca = new Biblioteca
			{
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
		};

		//
		// GET: /Usuarios/

		public ActionResult Index()
		{
			return View();
		}

		//
		// GET: /Usuarios/Codigo/Musicas/

		public ActionResult Musicas(string idUsuario)
		{
			return new OK(usuario.listaMusicas());
		}
    }
}
