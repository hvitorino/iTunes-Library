using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public class Musica
	{
		public Musica()
		{
			//Id = Guid.NewGuid();
		}

		//public Guid Id { get; set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Artista { get; set; }

		public Musica ComNome( string nome )
		{
			Nome = nome;

			return this;
		}

		public Musica DoArtista( string artista )
		{
			Artista = artista;

			return this;
		}
	}
}
