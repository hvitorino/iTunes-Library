using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using iTunesLibrary.Domain;
using iTunesLibrary.Web.Models;

namespace iTunesLibrary.Web.Mapas
{
	public static class MapaUsuarioExtensions
	{
		public static Models.Usuario ConverteParaModel(this Domain.Usuario musica)
		{ 
			var model = new Models.Usuario();

			if (Mapper.FindTypeMapFor<Domain.Usuario, Models.Usuario>() == null)
				Mapper.CreateMap<Domain.Usuario, Models.Usuario>();

			return Mapper.Map<Domain.Usuario, Models.Usuario>(musica);
		}

		public static IList<Models.Usuario> ConverteParaModel(this IEnumerable<Domain.Usuario> musicas)
		{
			var lista = new List<Models.Usuario>();

			if (Mapper.FindTypeMapFor<Domain.Usuario, Models.Usuario>() == null)
				Mapper.CreateMap<Domain.Usuario, Models.Usuario>();

			foreach (var m in musicas)
				lista.Add(Mapper.Map<Domain.Usuario, Models.Usuario>(m));

			return lista;
		}
	}
}