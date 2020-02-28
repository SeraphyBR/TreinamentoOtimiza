using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using P01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace P01_ConsultarCEP.Servico
{
    public class ViaCEPService
    {
        private static string URL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string finalURL = string.Format(URL, cep);
            WebClient wc = new WebClient();
            string response = wc.DownloadString(finalURL);
            Endereco e = JsonConvert.DeserializeObject<Endereco>(response);
            if (e.Cep == null) return null;
            return e;
        }
    }
}
