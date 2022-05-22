using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pedapp.DataModel;
using Newtonsoft.Json;

namespace Pedapp.API
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "https://pedapp-api.herokuapp.com/";

        private const string ListAlcoholsUrl = MainWebServiceUrl + "alcohol_types.json";
        private const string ListDrinksUrl = MainWebServiceUrl + "drinks.json";
        private const string CreateDrinksUrl = MainWebServiceUrl + "drinks.json";

        public async Task<List<AlcoholType>> listAlcohols()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(ListAlcoholsUrl);

            return JsonConvert.DeserializeObject<List<AlcoholType>>(response);
        }

        public async Task<List<Bebida>> listDrinks()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(ListDrinksUrl);

            return JsonConvert.DeserializeObject<List<Bebida>>(response);
        }

        public async Task<bool> createDrink(MultipartFormDataContent content)
        {
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.PostAsync(CreateDrinksUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.Write("Error al crear la bebida:", e);
                return false;
            }
        }
    }
}
