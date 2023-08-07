﻿using IntegraBancoAPI.Dtos;
using IntegraBancoAPI.Inteface;
using IntegraBancoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace IntegraBancoAPI.Rest
{
    public class BancoApiRest : IBancoApi
    {
        public async Task<ResponseDto<List<BancoModel>>> BuscarTodosBancos()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/");

            var response = new ResponseDto<List<BancoModel>>();
            using (var client = new HttpClient())
            {
                var responseBancoApi = await client.SendAsync(request);
                var contentResp = await responseBancoApi.Content.ReadAsStringAsync();
                var objReponse = JsonSerializer.Deserialize<List<BancoModel>>(contentResp);

                if (responseBancoApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBancoApi.StatusCode;
                    response.DadosRetorno = objReponse;
                }
                else
                {
                    response.CodigoHttp = responseBancoApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }

            }
            return response;

        }
        public Task<ResponseDto<BancoModel>> BuscarBancoId(string codigoBanco)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<EnderecoModel>> BuscarEnderecoPorCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            var response = new ResponseDto<EnderecoModel>();
            using (var client = new HttpClient())
            {
                var responseBancoApi = await client.SendAsync(request);
                var contentResp = await responseBancoApi.Content.ReadAsStringAsync();
                var objReponse = JsonSerializer.Deserialize<EnderecoModel>(contentResp);

                if (responseBancoApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBancoApi.StatusCode;
                    response.DadosRetorno = objReponse;
                }
                else
                {
                    response.CodigoHttp = responseBancoApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
                return response;
                
            }

        }

    }
}
