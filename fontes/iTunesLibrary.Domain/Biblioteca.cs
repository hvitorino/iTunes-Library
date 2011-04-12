using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public class Biblioteca
	{
		public Biblioteca()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }
		public string Nome { get; set; }
		public Usuario Autor { get; set; }
		public IList<Lista> Listas { get; set; }
		public IList<Musica> Musicas { get; set; }

		public Musica adicionaMusica(Musica musica)
		{
			if (Musicas == null)
				Musicas = new List<Musica>() { musica };

			return musica;
		}

		public Lista adicionaLista(string nome)
		{
			var novaLista = new Lista { Id = Guid.NewGuid(), Biblioteca = this, Nome = nome };

			if (Listas == null)
				Listas = new List<Lista>() { novaLista };

			return novaLista;
		}
	}
}
