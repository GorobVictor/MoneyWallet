using Core.Model;
using Core.Model.Dto;
using Core.Model.Interface;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.Utils
{
    class MyRestClient
    {
        public static RestClient Client { get; set; } = new RestClient("https://localhost:44312/api");
        public static async Task<GetTokenResult> LoginAsync(IUserAuth userAuth)
        {

            var request = new RestRequest("account", RestSharp.DataFormat.Json)
                .AddJsonBody(userAuth);
            var response = await Client.PostAsync<GetTokenResult>(request);
            if (response != null)
            {
                Client.Authenticator = new JwtAuthenticator(response.Token);
            }
            return response;
        }

        public static async Task<User> GetUserAsync()
        {
            var request = new RestRequest("account");
            return await Client.GetAsync<User>(request);
        }

        public static async Task AddUserAsync(User user)
        {
            var request = new RestRequest("account/add", Method.POST, RestSharp.DataFormat.Json)
                .AddJsonBody(user);
            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($"AddCosts error\nstatus code: {response.StatusCode}", "Error");
            }
        }

        public static async Task<bool> CheckLoginAsync(string login)
        {
            var request = new RestRequest($"account/check?login={login}");
            return await Client.GetAsync<bool>(request);
        }

        public static async Task<List<Costs>> GetCostsAsync()
        {
            var request = new RestRequest("costs");
            return await Client.GetAsync<List<Costs>>(request);
        }

        public static async Task AddCostsAsync(IEnumerable<Costs> costs)
        {
            var request = new RestRequest("costs/add", Method.POST, RestSharp.DataFormat.Json)
                .AddJsonBody(costs);
            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($"AddCosts error\nstatus code: {response.StatusCode}", "Error");
            }
        }

        public static async Task UpdateCostsAsync(IEnumerable<Costs> costs)
        {
            var request = new RestRequest("costs/update", Method.PUT, RestSharp.DataFormat.Json)
                .AddJsonBody(costs);
            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($"UpdateCosts error\nstatus code: {response.StatusCode}", "Error");
            }
        }
    }
}
