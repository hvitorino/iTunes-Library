using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using iTunesLibrary.Domain;
using iTunesLibrary.Web.Models;

namespace iTunesLibrary.Web.Mapas
{
	public static class MapaMusicaExtensions
	{
		public static Models.Musica ConverteParaModel(this Domain.Musica musica)
		{ 
			var model = new Models.Musica();

			if (Mapper.FindTypeMapFor<Domain.Musica, Models.Musica>() == null)
				Mapper.CreateMap<Domain.Musica, Models.Musica>();

			return Mapper.Map<Domain.Musica, Models.Musica>(musica);
		}

		public static Domain.Musica ConverteParaEntidade(this Models.Musica musica)
		{
			var domain = new Domain.Musica();

			if (Mapper.FindTypeMapFor<Models.Musica, Domain.Musica>() == null)
				Mapper.CreateMap<Models.Musica, Domain.Musica>();

			return Mapper.Map<Models.Musica, Domain.Musica>(musica);
		}

		public static Domain.Musica ConverteParaEntidade(this Models.Musica musica, Domain.Musica musicaDomain)
		{
			var domain = new Domain.Musica();

			if (Mapper.FindTypeMapFor<Models.Musica, Domain.Musica>() == null)
				Mapper.CreateMap<Models.Musica, Domain.Musica>();

			return Mapper.Map<Models.Musica, Domain.Musica>(musica, musicaDomain);
		}

		public static IList<Models.Musica> ConverteParaModel(this IEnumerable<Domain.Musica> musicas)
		{
			var lista = new List<Models.Musica>();

			if (Mapper.FindTypeMapFor<Domain.Musica, Models.Musica>() == null)
				Mapper.CreateMap<Domain.Musica, Models.Musica>();

			foreach (var m in musicas)
				lista.Add(Mapper.Map<Domain.Musica, Models.Musica>(m));

			return lista;
		}
	}
}