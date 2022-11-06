using Newtonsoft.Json;
using Semana07DPASalesMVC.WEB.Models;
using System.Security.Policy;
using System.Text;

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

        public static async Task<CustomerViewModel> GetCustomerById(int id)
        {
            var url = "http://localhost:5152/api/Customer/" + id.ToString();
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var customerResponse = JsonConvert.DeserializeObject<CustomerViewModel>(apiResponse);

            return customerResponse;

        }

        public static async Task<bool> InsertCustomer(CustomerInsertViewModel customer)
        {
            var url = "http://localhost:5152/api/Customer";
            using var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(url, data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;
        }

        public static async Task<bool> DeleteCustomer(int id)
        {
            var url = "http://localhost:5152/api/Customer/" + id.ToString();
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .DeleteAsync(url);
            if ((int)response.StatusCode == 404)
                return false;
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);
            return result.response;
        }

        public static async Task<bool> UpdateCustomer(CustomerViewModel customer)
        {
            var url = "http://localhost:5152/api/Customer/" + customer.Id.ToString();
            using var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(url, data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;
        }


    }
}
