using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public class Biblioteca : List<Musica>
	{
		public string Nome { get; set; }

		public Musica adicionaMusica(Musica musica)
		{
			this.Add(musica);

			return musica;
		}
	}
}
