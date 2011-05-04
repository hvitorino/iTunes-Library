using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Domain.Tests
{
	[TestFixture]
	public class Dada_Uma_Musica
	{
		[TestCase]
		public void Posso_Definir_Seu_Nome()
		{
			var musica = new Musica();

			musica.ComNome("Smells Like Teen Spirit");

			Assert.AreEqual("Smells Like Teen Spirit", musica.Nome);
		}

		[TestCase]
		public void Posso_Definir_Nome_Do_Artista()
		{
			var musica = new Musica();

			musica.DoArtista("Nirvana");

			Assert.AreEqual("Nirvana", musica.Artista);
		}
	}
}
