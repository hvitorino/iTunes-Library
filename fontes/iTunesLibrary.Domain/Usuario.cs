using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public class Usuario : iTunesLibrary.Domain.IUsuario
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public Biblioteca Biblioteca { get; set; }
		public Musica UltimaMusicaAdicionada { get; set; }

		public static Usuario novoUsuario(Guid idUsuario)
		{
			return new Usuario { Id = idUsuario };
		}

		public Musica adicionaMusica()
		{
			var musica = new Musica();

			if (Biblioteca == null)
				Biblioteca = new Domain.Biblioteca { Nome = this.Nome };

			Biblioteca.adicionaMusica(musica);
			UltimaMusicaAdicionada = musica;

			return musica;
		}

		public Musica pesquisaMusica(string nome)
		{
			if (Biblioteca != null)
				return Biblioteca
						.Where(musica => musica.Nome.Equals(nome))
						.SingleOrDefault();
			else
				return null;
		}

		//public Lista criaLista(string nome)
		//{
		//    if (Biblioteca == null)
		//        Biblioteca = new Biblioteca { Nome = this.Nome };

		//    return Biblioteca.adicionaLista(nome);
		//}

		public IEnumerable<Musica> listaMusicas()
		{
			return Biblioteca;
		}
	}
}
