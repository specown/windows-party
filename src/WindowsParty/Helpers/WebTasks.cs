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
        private AuthModel _authModel;
        private List<ServerModel> _serverList;

        public async Task<AuthModel> AuthenticateUser(UserModel userModel)
        {
            _restClient = new RestClient(ConfigurationManager.AppSettings["baseUrl"]);

            RestRequest restRequest = BuildAuthRequest(userModel);

            var restResponse = await _restClient.ExecuteTaskAsync(restRequest);

            _authModel = JsonConvert.DeserializeObject<AuthModel>(restResponse.Content);

            return _authModel;
        }

        private RestRequest BuildAuthRequest(UserModel userModel)
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

        public async Task<List<ServerModel>> RetrieveServerList()
        {
            _restClient = new RestClient(ConfigurationManager.AppSettings["baseUrl"]);

            RestRequest restRequest = BuildServerRequest(_authModel);

            var restResponse = await _restClient.ExecuteTaskAsync(restRequest);

            _serverList = JsonConvert.DeserializeObject<List<ServerModel>>(restResponse.Content);

            return _serverList;
        }

        private RestRequest BuildServerRequest(AuthModel authModel)
        {
            var restRequest = new RestRequest(ConfigurationManager.AppSettings["baseUrl"] + ConfigurationManager.AppSettings["serverPath"], Method.GET, DataFormat.Json);

            restRequest.AddHeader("Authorization", "Bearer " + authModel.AuthToken);

            return restRequest;
        }
    }
}
