﻿using System.Dynamic;
using System.Net;

namespace IntegraBancoAPI.Dtos
{
    public class ResponseDto<T> where T : class
    {
        public HttpStatusCode CodigoHttp { get; set; }
        public T? DadosRetorno { get; set; }
        public ExpandoObject? ErroRetorno { get; set; }
    }
}
