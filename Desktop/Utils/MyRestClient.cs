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

            var request = new RestRequest("account", Method.POST, RestSharp.DataFormat.Json)
                .AddJsonBody(userAuth);
            var response = await Client.ExecuteAsync<GetTokenResult>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Client.Authenticator = new JwtAuthenticator(response.Data.Token);
                return response.Data;
            }
            else
            {
                return null;
            }
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

        public static async Task<List<GetSetCosts>> GetCostsAsync()
        {
            var request = new RestRequest("costs");
            return await Client.GetAsync<List<GetSetCosts>>(request);
        }

        public static async Task AddCostsAsync(IEnumerable<GetSetCosts> costs)
        {
            var request = new RestRequest("costs/add", Method.POST, RestSharp.DataFormat.Json)
                .AddJsonBody(costs);
            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($"AddCosts error\nstatus code: {response.StatusCode}", "Error");
            }
        }

        public static async Task UpdateCostsAsync(IEnumerable<GetSetCosts> costs)
        {
            var request = new RestRequest("costs/update", Method.PUT, RestSharp.DataFormat.Json)
                .AddJsonBody(costs);
            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($"UpdateCosts error\nstatus code: {response.StatusCode}", "Error");
            }
        }

        public static async Task<List<GetSetSalary>> GetSalaryAsync()
        {
            var request = new RestRequest("salary/getbydate");
            return await Client.GetAsync<List<GetSetSalary>>(request);
        }

        public static async Task UpdateSalaryAsync(IEnumerable<GetSetSalary> salary)
        {
            var request = new RestRequest("salary/update", Method.PUT, RestSharp.DataFormat.Json)
                .AddJsonBody(salary);
            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($"UpdateCosts error\nstatus code: {response.StatusCode}", "Error");
            }
        }
    }
}
