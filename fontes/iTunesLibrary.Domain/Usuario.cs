using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunesLibrary.Domain
{
	public class Usuario : Entidade
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public Musica UltimaMusicaAdicionada { get; set; }
	}
}
