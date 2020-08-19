using CadastroWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CadastroWPF.DAL
{
    /// <summary>
    /// Serviço para Comunicar com a API
    /// </summary>
    public class DAL_SERVICES
    {
        /// <summary>
        /// Url da API
        /// </summary>
        //private const string _urlBase = "https://localhost:44320";
        private const string _urlBase = "https://cadastrocontato.azurewebsites.net";
        public string messageAPI = string.Empty;

        /// <summary>
        /// Pega um Contato.
        /// </summary>
        /// <param name="id">Id Contato.</param>
        /// <returns>Objeto Contato.</returns>
        public async Task<User> GetById(int? id)
        {
            User LcReturn = null;
            messageAPI = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_urlBase);

                string urlteste = _urlBase + "/api/User/GetById/" + id;
                HttpResponseMessage response = await client.GetAsync(new Uri(urlteste));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LcReturn = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    messageAPI = await response.Content.ReadAsStringAsync();
                    LcReturn = null;
                }
            }
            catch (Exception ex)
            {
                messageAPI = ex.Message.ToString();
                LcReturn = null;
            }
            return LcReturn;
        }

        /// <summary>
        /// Pega todos os Contatos Cadastrados.
        /// </summary>
        /// <returns>Lista de Contatos.</returns>
        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> LcReturn = null;
            messageAPI = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_urlBase);

                string urlteste = _urlBase + "/api/User/GetAll";
                HttpResponseMessage response = await client.GetAsync(new Uri(urlteste));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LcReturn = JsonConvert.DeserializeObject<IEnumerable<User>>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    messageAPI = await response.Content.ReadAsStringAsync();
                    LcReturn = null;
                }
            }
            catch (Exception ex)
            {
                messageAPI = ex.Message.ToString();
                LcReturn = null;
            }
            return LcReturn;
        }

        /// <summary>
        /// Inclui um Contato
        /// </summary>
        /// <param name="user">objeto Contato.</param>
        /// <returns>True (Incluiu) ou False (Não Incluiu).</returns>
        public async Task<bool> Insert(User user)
        {
            bool LcReturn = false;
            messageAPI = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_urlBase);

                HttpResponseMessage response = client.PostAsync(
                            _urlBase + "/api/User/Insert", new StringContent(
                                JsonConvert.SerializeObject(new
                                {
                                    user.Name,
                                    user.LastName,
                                    user.Phone,
                                }), Encoding.UTF8, "application/json")).Result;


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LcReturn = true;
                }
                else
                {
                    messageAPI = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                messageAPI = ex.Message.ToString();
            }
            return LcReturn;
        }

        /// <summary>
        /// Alteração em um Contato
        /// </summary>
        /// <param name="user">Objeto Contato</param>
        /// <returns>True (Alterou) ou False (Não Alterou).</returns>
        public async Task<bool> Update(User user)
        {
            bool LcReturn = false;
            messageAPI = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_urlBase);

                HttpResponseMessage response = client.PutAsync(
                            _urlBase + "/api/User/Update", new StringContent(
                                JsonConvert.SerializeObject(new
                                {
                                    user.Id,
                                    user.Name,
                                    user.LastName,
                                    user.Phone,
                                }), Encoding.UTF8, "application/json")).Result;


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LcReturn = true;
                }
                else
                {
                    messageAPI = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                messageAPI = ex.Message.ToString();
            }
            return LcReturn;
        }

        /// <summary>
        /// Exclui um Contato
        /// </summary>
        /// <param name="id">Id do Contato.</param>
        /// <returns>True (Excluiu) ou False (Não Excluiu).</returns>
        public async Task<bool> Delete(int id)
        {
            bool LcReturn = false;
            messageAPI = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_urlBase);

                string urlteste = _urlBase + "/api/User/Delete/" + id;
                HttpResponseMessage response = await client.DeleteAsync(new Uri(urlteste));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LcReturn = true;
                }
                else
                {
                    messageAPI = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                messageAPI = ex.Message.ToString();
            }
            return LcReturn;
        }
    }
}
