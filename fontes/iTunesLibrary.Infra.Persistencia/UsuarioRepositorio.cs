using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Infra.Persistencia
{
	class UsuarioRepositorio
	{
		private static int contador = 1;
		private static List<Usuario> cadastro = new List<Usuario>();

		public long Total
		{
			get { return cadastro.Count; }
		}

		public IEnumerable<Usuario> Lista(int indiceInicial, int quantidade)
		{
			return cadastro.Take(quantidade).Skip(indiceInicial);
		}

		public IEnumerable<Usuario> Lista()
		{
			return cadastro;
		}

		public Usuario Carrega(long id)
		{
			return cadastro
					.Where(m => m.Id.Equals(id))
					.SingleOrDefault();
		}

		public Usuario Altera(Usuario entidade)
		{
			var Usuario = Carrega(entidade.Id);

			Usuario.Nome = entidade.Nome;
			
			return Usuario;
		}

		public Usuario Salva(Usuario entidade)
		{
			entidade.Id = ++contador;

			cadastro.Add(entidade);

			return entidade;
		}

		public Usuario Exclui(long id)
		{
			var Usuario = Carrega(id);

			cadastro.Remove(Usuario);

			return Usuario;
		}
	}
}
