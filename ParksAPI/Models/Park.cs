using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace ParksAPI.Models
{
  public class Park
  {
    [Required]
    public int ParkId { get; set; }
    [Required]
    public string ParkName { get; set; }
    public string State { get; set; }
    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
    public int Rating { get; set; }
    public string Highlight { get; set; }
    public bool Visited { get; set; }

    public static List<Park> GetParks()
    {
      var apiCallTask = ApiHelper.GetAll();
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Park> parkList = JsonConvert.DeserializeObject<List<Park>>(jsonResponse.ToString());

      return parkList;
    }

    public static Park GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      Park park = JsonConvert.DeserializeObject<Park>(jsonResponse.ToString());

      return park;
    }

    public async static Task Post(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      await ApiHelper.Post(jsonPark);
    }

    public async static Task Put(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      await ApiHelper.Put(park.ParkId, jsonPark);
    }

    public async static Task Delete(int id)
    {
      await ApiHelper.Delete(id);
    }
  }
}