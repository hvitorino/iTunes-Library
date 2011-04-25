using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Validator.Constraints;

namespace iTunesLibrary.Domain
{
	public class Musica : Entidade
	{
		public Musica()
		{
		}

		public int Id { get; set; }

		[NotNullNotEmpty(Message = "Não pode ser nulo ou vazio")]
		public string Nome { get; set; }

		[NotNullNotEmpty(Message = "Não pode ser nulo ou vazio")]
		public string Artista { get; set; }

		public Usuario PublicadoPor { get; set; }

		public Musica ComNome(string nome)
		{
			Nome = nome;

			return this;
		}

		public Musica DoArtista(string artista)
		{
			Artista = artista;

			return this;
		}
	}
}
