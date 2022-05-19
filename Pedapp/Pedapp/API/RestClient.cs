using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pedapp.DataModel;
using Newtonsoft.Json;
using System.Text;

namespace Pedapp.API
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "https://pedapp-api.herokuapp.com/";

        private const string ListAlcoholsUrl = MainWebServiceUrl + "alcohol_types.json";
        private const string ListDrinksUrl = MainWebServiceUrl + "drinks.json";
        private const string CreateDrinksUrl = MainWebServiceUrl + "drinks.json";

        public async Task<List<Alcohol>> listAlcohols()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(ListAlcoholsUrl);

            return JsonConvert.DeserializeObject<List<Alcohol>>(response);
        }

        public async Task<List<Bebida>> listDrinks()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(ListDrinksUrl);

            return JsonConvert.DeserializeObject<List<Bebida>>(response);
        }

        public async Task<bool> createDrink(string name, int alcohol_type_id, string how_to_prepare)
        {
            var httpClient = new HttpClient();
            var drinkObject = new {
                name = name,
                alcohol_type_id = alcohol_type_id,
                how_to_prepare = how_to_prepare
            };
            var jsonObject = new { drink = drinkObject };
            var jsonString = JsonConvert.SerializeObject(jsonObject);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(CreateDrinksUrl, content);

            return response.IsSuccessStatusCode;
        }
    }
}
