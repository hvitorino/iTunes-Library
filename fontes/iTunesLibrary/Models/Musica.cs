using Restfulie.Server;

using iTunesLibrary.Web.Controllers;

namespace iTunesLibrary.Web.Models
{
	public class Musica : IBehaveAsResource
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Artista { get; set; }
		
		public void SetRelations(Relations relations)
		{
			relations.Named("self")
				.Uses<MusicaController>()
				.Exibe(Id);
		}
	}
}