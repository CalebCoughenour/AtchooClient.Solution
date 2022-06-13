using System.Threading.Tasks;
using RestSharp;
using AtchooClient.ViewModels;

namespace AtchooClient.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiPostRegister(RegisterViewModel body)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"accounts/register", Method.POST);
      request.AddJsonBody(body);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiPostLogin(LoginViewModel body)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"accounts/login", Method.POST);
      request.AddJsonBody(body);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}