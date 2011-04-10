using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public class Usuario
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public Biblioteca Biblioteca { get; set; }
		public Musica UltimaMusicaAdicionada { get; set; }

		public static Usuario novoUsuario( Guid idUsuario )
		{
			return new Usuario { Id = idUsuario };
		}

		public Musica adicionaMusica()
		{
			var musica = new Musica();

			if ( Biblioteca == null )
				Biblioteca = new Domain.Biblioteca { Nome = this.Nome };

			Biblioteca.adicionaMusica( musica );
			UltimaMusicaAdicionada = musica;

			return musica;
		}


	}
}
