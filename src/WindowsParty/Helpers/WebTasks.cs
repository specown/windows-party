using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WindowsParty.Interfaces;
using WindowsParty.Models;

namespace WindowsParty.Helpers
{
    public class WebTasks : IWebTasks
    {
        private RestClient _restClient;

        public async Task<AuthModel> AuthenticateUser(UserModel userModel)
        {
            _restClient = new RestClient(ConfigurationManager.AppSettings["baseUrl"]);

            RestRequest restRequest = BuildRestRequest(userModel);

            var restResponse = await _restClient.ExecuteTaskAsync(restRequest);

            AuthModel authResponse = JsonConvert.DeserializeObject<AuthModel>(restResponse.Content);

            return authResponse;
        }

        private RestRequest BuildRestRequest(UserModel userModel)
        {
            var restRequest = new RestRequest(ConfigurationManager.AppSettings["baseUrl"] + ConfigurationManager.AppSettings["tokenPath"], Method.POST, DataFormat.Json)
            {
                JsonSerializer = new Serializer()
            };

            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.Formatting = Formatting.Indented;

            var userModelSerialized = JsonConvert.SerializeObject(userModel, jsonSettings);

            restRequest.AddParameter("application/json", userModelSerialized, ParameterType.RequestBody);

            return restRequest;
        }

        public Task<List<ServerModel>> RetrieveServerList(AuthModel authModel)
        {
            throw new NotImplementedException();
        }
    }
}
