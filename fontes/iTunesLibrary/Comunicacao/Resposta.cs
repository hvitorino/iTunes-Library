using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTunesLibrary.Web.Comunicacao
{
    public class Resposta
    {
		public int Codigo { get; set; }
        public dynamic Dados { get; set; }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public long Total { get; set; }

        public static Resposta Ok( dynamic dados, long total = 0, string mensagem = "Operação realizada com sucesso" )
        {
            return new Resposta
            {
				Codigo = 1,
                Dados = dados,
                Mensagem = mensagem,
                Sucesso = true,
                Total = total
            };
        }

        public static Resposta Erro( long total = 0, string mensagem = "Não foi possível realizar operação" )
        {
            return new Resposta
            {
				Codigo = 2,
                Dados = null,
                Mensagem = mensagem,
                Sucesso = false,
                Total = total
            };
        }

		public static Resposta UsuarioNaoAutorizado()
		{
			return new Resposta
			{
				Codigo = 3,
				Dados = null,
				Mensagem = "Usuário não autenticado. Faça o login.",
				Sucesso = false,
				Total = 0
			};
		}
	}
}