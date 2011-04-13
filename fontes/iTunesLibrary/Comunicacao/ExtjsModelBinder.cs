using System.Web.Mvc;
using System.IO;
using System.Web;

using Newtonsoft.Json;

namespace iTunesLibrary.Web.Comunicacao
{
	public class ExtjsModelBinder : DefaultModelBinder
	{
		public ExtjsModelBinder()
			: this("Dados")
		{ }

		public ExtjsModelBinder(string extjsRoot)
		{
			this.extjsRoot = extjsRoot;
		}

		private string extjsRoot;

		public string RootJson
		{
			get { return "{\"" + extjsRoot + "\":"; }
		}

		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (!IsJSONRequest(controllerContext))
			{
				return base.BindModel(controllerContext, bindingContext);
			}

			var jsonData = ObtemDadosRequisicao(controllerContext.HttpContext);
			var config = new JsonSerializerSettings();
			var reader = new StringReader(jsonData);

			config.Converters.Add(new ConversorDeDatas());
			config.Converters.Add(new ConversorDeEnumeracoes());

			var serializador = JsonSerializer.Create(config);

			return serializador.Deserialize(reader, bindingContext.ModelMetadata.ModelType);
		}

		private string ObtemDadosRequisicao(HttpContextBase app)
		{
			var reader = new StreamReader(app.Request.InputStream, System.Text.Encoding.UTF8);
			var dados = reader.ReadToEnd();

			return RemoverRoot(dados);
		}

		private bool IsJSONRequest(ControllerContext controllerContext)
		{
			var contentType = controllerContext.HttpContext.Request.ContentType;

			return contentType.Contains("application/json");
		}

		private string RemoverRoot(string dados)
		{
			string dadosAlterados = dados;

			if (dadosAlterados.StartsWith(RootJson))
			{
				dadosAlterados = dadosAlterados.Replace(RootJson, "");
				dadosAlterados = dadosAlterados.Substring(0, dadosAlterados.Length - 1);
			}

			return dadosAlterados;
		}
	}
}