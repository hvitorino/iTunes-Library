using Restfulie.Server;

using iTunesLibrary.Web.Controllers;

namespace iTunesLibrary.Web.Models
{
	public class Usuario : IBehaveAsResource
	{
		public int Id { get; set; }
		public string Nome { get; set; }

		public void SetRelations(Relations relations)
		{
			relations.Named("self")
				.Uses<UsuarioController>()
				.Exibe(Id);

			relations.Named("musicas")
				.Uses<MusicaController>()
				.Lista();
		}
	}
}