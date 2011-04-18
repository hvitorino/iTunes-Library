using System.Collections;
using System.Collections.Generic;

namespace iTunesLibrary.Domain
{
	public class Biblioteca : IEnumerable<Musica>
	{
		public IList<Musica> musicas;
		public string Nome { get; set; }

		public Musica adicionaMusica(Musica musica)
		{
			if (musicas == null)
				musicas = new List<Musica>();

			musicas.Add(musica);

			return musica;
		}

		public IEnumerator<Musica> GetEnumerator()
		{
			return musicas.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return musicas.GetEnumerator();
		}
	}
}
