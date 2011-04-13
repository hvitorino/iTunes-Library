using System;
using System.Collections.Generic;

namespace iTunesLibrary.Domain
{
	public interface IUsuario
	{
		Musica adicionaMusica();
		Musica pesquisaMusica( string nome );

		//Lista criaLista( string nome );
		IEnumerable<Musica> listaMusicas();
	}
}
