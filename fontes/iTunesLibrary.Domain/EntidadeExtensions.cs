using NHibernate.Validator.Engine;
using System.Collections.Generic;

namespace iTunesLibrary.Domain
{
	public static class EntidadeExtensions
	{
		public static bool Valido(this Entidade entidade)
		{
			ValidatorEngine engine = new ValidatorEngine();

			return engine.IsValid(entidade);
		}

		public static List<string> ItensInvalidos(this Entidade entidade)
		{
			var engine = new ValidatorEngine();
			var mensagens = new List<string>();

			foreach (var item in engine.Validate(entidade))
				mensagens.Add(item.PropertyName + ": " + item.Message);

			return mensagens;
		}
	}
}
