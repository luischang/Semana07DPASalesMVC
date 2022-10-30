using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Semana07DPASalesMVC.WEB.Models;
using System.Text;

namespace Semana07DPASalesMVC.WEB.Services
{
    public class UsersService
    {


        public static async Task<UsersLoginResponseViewModel> Login(UsersAuthenticationViewModel auth)
        {
            var url = "http://localhost:5152/api/Users/Login";
            var json = JsonConvert.SerializeObject(auth);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url, data);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<UsersLoginResponseViewModel>(apiResponse);

            return userResponse;        
        }



    }
}
