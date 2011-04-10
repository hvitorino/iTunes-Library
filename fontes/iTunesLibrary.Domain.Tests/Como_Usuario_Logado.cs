using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace iTunesLibrary.Domain.Tests
{
	[TestFixture]
	public class Como_Usuario_Logado
	{
		private Usuario usuario;

		[SetUp]
		public void Premissas()
		{
			usuario = Usuario.novoUsuario( Guid.NewGuid() );
		}

		[TestCase]
		public void Posso_Adicionar_Musicas_A_Biblioteca()
		{
			var musica = usuario.adicionaMusica()
							.ComNome( "Fire" )
							.DoArtista( "Jimi Hendrix" );

			Assert.AreEqual( musica, usuario.UltimaMusicaAdicionada );
			Assert.AreEqual( "Fire", usuario.UltimaMusicaAdicionada.Nome );
			Assert.AreEqual( "Jimi Hendrix", usuario.UltimaMusicaAdicionada.Artista );
		}

		[TestCase]
		public void Posso_Pesquisar_Musicas_Na_Biblioteca()
		{

		}

		[TestCase]
		public void Posso_Criar_Listas_De_Musicas()
		{

		}
	}
}
