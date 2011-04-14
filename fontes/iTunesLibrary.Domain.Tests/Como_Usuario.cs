using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace iTunesLibrary.Domain.Tests
{
	[TestFixture]
	public class Como_Usuario
	{
		private Usuario usuario;

		[SetUp]
		public void Premissas()
		{
			usuario = Usuario.novoUsuario(1);
		}

		[TestCase]
		public void Posso_Adicionar_Musicas_A_Biblioteca()
		{
			var musica = usuario.adicionaMusica()
							.ComNome("Fire")
							.DoArtista("Jimi Hendrix");

			Assert.AreEqual(musica, usuario.UltimaMusicaAdicionada);
			Assert.AreEqual("Fire", usuario.UltimaMusicaAdicionada.Nome);
			Assert.AreEqual("Jimi Hendrix", usuario.UltimaMusicaAdicionada.Artista);
		}

		[TestCase]
		public void Posso_Pesquisar_Musicas_Na_Biblioteca()
		{
			var usuario = new Usuario
			{
				Nome = "hvitorino",
				Biblioteca = new Biblioteca
				{
					new Musica
					{
						Nome = "Fire",
						Artista = "Jimi Hendrix"
					} 
				}
			};

			var musica = usuario.pesquisaMusica("Fire");

			Assert.IsNotNull(musica);
			Assert.AreEqual("Fire", musica.Nome);
			Assert.AreEqual("Jimi Hendrix", musica.Artista);
		}

		[TestCase]
		public void Posso_Listar_Musicas_Da_Biblioteca()
		{
			var usuario = new Usuario
			{
				Nome = "hvitorino",
				Biblioteca = new Biblioteca
				{
					new Musica
					{
						Nome = "Fire",
						Artista = "Jimi Hendrix"
					} 
				}
			};

			var musicas = usuario.listaMusicas();

			Assert.IsInstanceOf<IEnumerable<Musica>>(musicas);
			Assert.AreEqual(1, musicas.Count());
		}

		//[TestCase]
		//public void Posso_Criar_Listas_De_Musicas()
		//{
		//    var lista = usuario.criaLista( "classic rock" );

		//    Assert.AreEqual( "classic rock", lista.Nome );
		//    Assert.AreEqual( usuario.Biblioteca, lista.Biblioteca );
		//}
	}
}
