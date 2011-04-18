﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Infra.Persistencia
{
	public class MusicaRepositorio : IRepositorio<Musica>
	{
		private static int contador = 1;
		private static List<Musica> biblioteca = new List<Musica>();

		public long Total
		{
			get { return biblioteca.Count; }
		}

		public IEnumerable<Musica> Lista(int indiceInicial, int quantidade)
		{
			return biblioteca.Take(quantidade).Skip(indiceInicial);
		}

		public IEnumerable<Musica> Lista()
		{
			return biblioteca;
		}

		public Musica Carrega(long id)
		{
			return biblioteca
					.Where(m => m.Id.Equals(id))
					.SingleOrDefault();
		}

		public Musica Altera(Musica entidade)
		{
			var musica = Carrega(entidade.Id);

			musica.Nome = entidade.Nome;
			musica.Artista = entidade.Artista;

			return musica;
		}

		public Musica Salva(Musica entidade)
		{
			entidade.Id = ++contador;

			biblioteca.Add(entidade);

			return entidade;
		}

		public Musica Exclui(long id)
		{
			var musica = Carrega(id);

			biblioteca.Remove(musica);

			return musica;
		}
	}
}