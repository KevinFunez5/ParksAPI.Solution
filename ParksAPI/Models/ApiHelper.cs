using System;
using System.Threading.Tasks;
using RestSharp;

namespace ParksAPI.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"parks");
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"parks/{id}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task Post(string newPark)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"parks", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPark);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }
    public static async Task Put(int id, string newPark)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"parks", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPark);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }
    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"parks/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }
  }
}