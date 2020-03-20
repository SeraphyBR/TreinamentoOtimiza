using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using P12_NossoChat.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace P12_NossoChat.Service
{
    public class WebService
    {
        private static HttpClient hc = new HttpClient();
        private static readonly string baseurl = "http://ws.spacedu.com.br/xf2018/rest/api";

        public async static Task<Usuario> GetUsuario(Usuario u)
        {
            var url = $"{baseurl}/usuario";

            // Querystring:
            // var content = new StringContent($"?nome={u.nome}&password={u.password}");

            var param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome", u.nome),
                new KeyValuePair<string,string>("password", u.password),
            });

            var resposta = await hc.PostAsync(url, param);
            Usuario user = null;
            if (resposta.StatusCode is HttpStatusCode.OK) {
                string content = await resposta.Content.ReadAsStringAsync();
                if (content.Length > 2) {
                    user = JsonConvert.DeserializeObject<Usuario>(content);
                }
            }
            return user;
        }

        public async static Task<List<Chat>> GetChats()
        {
            var url = $"{baseurl}/chats";

            var resposta = await hc.GetAsync(url);
            List<Chat> lista = null;

            if (resposta.StatusCode is HttpStatusCode.OK) {
                string content = await resposta.Content.ReadAsStringAsync();
                if (content.Length > 2) {
                    lista = JsonConvert.DeserializeObject<List<Chat>>(content);
                }
            }

            return lista;
        }

        public static bool InsertChat(Chat c)
        {
            var url = $"{baseurl}/chat";

            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome", c.nome)
            });

            var resposta = hc.PostAsync(url, content).GetAwaiter().GetResult();

            var hasInserted = resposta.StatusCode is HttpStatusCode.OK;
            return hasInserted;
        }
        public static bool RenameChat(Chat c)
        {
            var url = $"{baseurl}/chat/{c.id}";

            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome", c.nome)
            });

            var resposta = hc.PutAsync(url, content).GetAwaiter().GetResult();

            var hasRenamed = resposta.StatusCode is HttpStatusCode.OK;
            return hasRenamed;
        }

        public static bool DeleteChat(Chat c)
        {
            var url = $"{baseurl}/chat/delete/{c.id}";

            var resposta = hc.DeleteAsync(url).GetAwaiter().GetResult();

            var hasDeleted = resposta.StatusCode is HttpStatusCode.OK;
            return hasDeleted;
        }

        public async static Task<List<Mensagem>> GetMensagens(Chat c)
        {
            var url = $"{baseurl}/chat/{c.id}/msg";

            var resposta = await hc.GetAsync(url);

            List<Mensagem> lista = null;

            if(resposta.StatusCode is HttpStatusCode.OK) {
                string content = await resposta.Content.ReadAsStringAsync();
                if (content.Length > 2) {
                    lista = JsonConvert.DeserializeObject<List<Mensagem>>(content);
                }
            }

            return lista;
        }

        public static bool SendMensagem(Mensagem m)
        {
            var url = $"{baseurl}/chat/{m.id_chat}/msg";

            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("mensagem", m.mensagem),
                new KeyValuePair<string,string>("id_usuario", m.id_usuario.ToString())
            });

            var resposta = hc.PostAsync(url, content).GetAwaiter().GetResult();

            var hasSend = resposta.StatusCode is HttpStatusCode.OK;
            return hasSend;
        }

        public static bool RemoveMensagem(Mensagem m)
        {
            var url = $"{baseurl}/chat/{m.id_chat}/delete/{m.id}";

            var resposta = hc.DeleteAsync(url).GetAwaiter().GetResult();

            var hasRemoved = resposta.StatusCode is HttpStatusCode.OK;
            return hasRemoved;
        }
    }
}
