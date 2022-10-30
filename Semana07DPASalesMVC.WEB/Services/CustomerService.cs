using Newtonsoft.Json;
using Semana07DPASalesMVC.WEB.Models;
using System.Security.Policy;

namespace Semana07DPASalesMVC.WEB.Services
{
    public class CustomerService
    {

        public static async Task<IEnumerable<CustomerCountryViewModel>> GetCustomers()
        {
            var url = "http://localhost:5152/api/Customer";
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var customerResponse = JsonConvert.DeserializeObject<IEnumerable<CustomerCountryViewModel>>(apiResponse);

            return customerResponse;

        }



    }
}
