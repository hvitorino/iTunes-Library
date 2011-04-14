using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

using Restfulie.Server;
using Restfulie.Server.Results;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Web.Controllers
{
	[ActAsRestfulie]
	[HandleError]
	public class MusicaController : CrudController<Musica>
	{
		private static Usuario usuario;

		private static List<Musica> musicas;

		static MusicaController()
		{
			usuario = new Usuario
			{
				Id = 1,
				Nome = "hvitorino"
			};

			musicas = new List<Musica>
			{
				new Musica 
				{
					Id = 1,
					Nome = "Fire",
					Artista = "Jimi Hendrix",
					PublicadoPor = usuario
				},
				new Musica 
				{
					Id = 2,
					Nome = "Hey Joe",
					Artista = "Jimi Hendrix",
					PublicadoPor = usuario
				},
				new Musica 
				{
					Id = 3,
					Nome = "All Along The Watchtower",
					Artista = "Jimi Hendrix",
					PublicadoPor = usuario
				},
				new Musica 
				{
					Id = 4,
					Nome = "Iron Maiden",
					Artista = "Iron Maiden",
					PublicadoPor = usuario
				},
				new Musica 
				{
					Id = 5,
					Nome = "Hallowed Be Thy Name",
					Artista = "Iron Maiden",
					PublicadoPor = usuario
				}
			};
		}

		[HttpPost]
		public override ActionResult Inclui(Musica musica)
		{
			var novoid = musicas.Max(m => m.Id) + 1;

			musica.Id = novoid;
			musica.PublicadoPor = usuario;

			musicas.Add(musica);

			return new Created(new Models.Musica
			{
				Id = musica.Id,
				Nome = musica.Nome,
				Artista = musica.Artista,
				PublicadoPor = new Models.Usuario
				{
					Id = musica.PublicadoPor.Id,
					Nome = musica.PublicadoPor.Nome
				}
			});
		}

		[HttpPut]
		public override ActionResult Altera(Musica musica)
		{
			var musicaAlterada = musicas.Where(m => m.Id == musica.Id).SingleOrDefault();

			musicaAlterada.Nome = musica.Nome;
			musicaAlterada.Artista = musica.Artista;

			return new OK(new Models.Musica
			{
				Id = musicaAlterada.Id,
				Nome = musicaAlterada.Nome,
				Artista = musicaAlterada.Artista,
				PublicadoPor = new Models.Usuario
				{
					Id = musicaAlterada.PublicadoPor.Id,
					Nome = musicaAlterada.PublicadoPor.Nome
				}
			});
		}

		[HttpDelete]
		public override ActionResult Exclui(int id)
		{
			var musicaExcluida = musicas.Where(m => m.Id == id).SingleOrDefault();

			musicas.Remove(musicaExcluida);

			return new OK(new Models.Musica
			{
				Id = musicaExcluida.Id,
				Nome = musicaExcluida.Nome,
				Artista = musicaExcluida.Artista,
				PublicadoPor = new Models.Usuario
				{
					Id = musicaExcluida.PublicadoPor.Id,
					Nome = musicaExcluida.PublicadoPor.Nome
				}
			});
		}

		[HttpGet]
		public override ActionResult Lista()
		{
			var usuario = new Models.Usuario
			{
				Id = 1,
				Nome = "hvitorino"
			};

			var musicasDTO = new List<Models.Musica>();

			musicas.ForEach(
				musica =>
					musicasDTO.Add(
						new Models.Musica
						{
							Id = musica.Id,
							Artista = musica.Artista,
							Nome = musica.Nome,
							PublicadoPor = usuario
						}
					)
			);

			return new OK(musicasDTO);
		}

		[HttpGet]
		public override ActionResult Exibe(int id)
		{
			var musicaRecuperada = musicas.Where(m => m.Id == id).SingleOrDefault();

			if (musicaRecuperada != null)
			{
				return new OK(new Models.Musica
				{
					Id = musicaRecuperada.Id,
					Nome = musicaRecuperada.Nome,
					Artista = musicaRecuperada.Artista,
					PublicadoPor = new Models.Usuario
					{
						Id = musicaRecuperada.PublicadoPor.Id,
						Nome = musicaRecuperada.PublicadoPor.Nome
					}
				});
			}
			else
				return new NotFound();
		}
	}
}
