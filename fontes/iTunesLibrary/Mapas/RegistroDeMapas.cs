using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using iTunesLibrary.Domain = Domain;
using iTunesLibrary.Web.Models = Models;

namespace iTunesLibrary.Web.Mapas
{
	public class RegistroDeMapas
	{
		public static Mapper Musica
		{
			get
			{
				var mapa = Mapper.FindTypeMapFor<Domain.Musica, Models.Musica>();

				if(mapa == null)
					Mapper.CreateMap<Domain.Musica, Models.Musica>();

				return Mapper.Map;
			}
		}
	}
}