using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public interface IRepositorio<TEntidade>
	{
		long Total { get; }

		IEnumerable<TEntidade> Lista(int indiceInicial, int quantidade);
		IEnumerable<TEntidade> Lista();

		TEntidade Carrega(long id);
		TEntidade Altera(TEntidade entidade);
		TEntidade Salva(TEntidade entidade);
		TEntidade Exclui(long id);
	}
}
