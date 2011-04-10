using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public class Lista
	{
		public Guid Id { get; set; }
		public IList<Musica> Musicas { get; set; }
		public string Nome { get; set; }
		public Biblioteca Biblioteca { get; set; }
	}
}
