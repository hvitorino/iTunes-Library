using System.Web.Mvc;

namespace iTunesLibrary.Web.Controllers
{
	public abstract class RestfulController<TRecurso> : Controller
	{
		//protected ICadastro<TRecurso> cadastro;

		/// <summary>
		/// Cria um novo recurso. Ex:
		///  (1) Cadastro de empregado
		///
		/// POST: /TRecurso/Inclui
		/// </summary>
		/// <param name="recurso">Recurso a ser criado</param>
		/// <returns>Resposta no formato Json</returns>
		public abstract ActionResult Inclui(TRecurso recurso);
		
		/// <summary>
		/// Cria um novo recurso. Ex:
		///  (1) Cadastro de empregado
		///
		/// PUT: /TRecurso/Inclui
		/// </summary>
		/// <param name="recurso">Recurso a ser criado</param>
		/// <returns>Resposta no formato Json</returns>
		public abstract ActionResult Altera(TRecurso recurso);
		

		/// <summary>
		/// Exclui um recurso. Ex:
		///        (1) Exclui um empregado
		/// </summary>
		/// <param name="id">Identificador do recurso a ser excluído</param>
		/// <returns>Resposta no formato Json</returns>
		public abstract ActionResult Exclui(int id);
		
		/// <summary>
		/// Realiza buscas com paginação
		/// </summary>
		/// <param name="start">Número da página a buscar, iniciando em 0</param>
		/// <param name="limit">Tamanho da página</param>
		/// <returns>Resposta no formato Json</returns>
		public abstract ActionResult Lista();

		/// <summary>
		/// Recupera um recurso através do id
		/// </summary>
		/// <param name="id">Id do objeto a ser exibido</param>
		/// <returns>Resposta no formato solicitado na requisição</returns>
		public abstract ActionResult Exibe(int id);
	}
}