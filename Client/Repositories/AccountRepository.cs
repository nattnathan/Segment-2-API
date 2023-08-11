using API.DTOs.Account;
using API.DTOs.Employee;
using API.Models;
using API.Utilities;
using Client.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class AccountRepository : GeneralRepository<LoginDto, Guid>, IAccountRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;
        public AccountRepository(string request="Accounts/") : base(request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7256/api/")
            };
        }

        public async Task<ResponseHandler<string>> Login(LoginDto entity)
        {
            ResponseHandler<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Login", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<string>>(apiResponse);
            }
            return entityVM;
        }
    }
}
