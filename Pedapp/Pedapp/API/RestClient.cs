using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pedapp.DataModel;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net.Http.Headers;

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

        public async Task<bool> createDrink(string name, int alcohol_type_id, string how_to_prepare, string filePath)
        {
            var httpClient = new HttpClient();

            var content = new MultipartFormDataContent();

            //var drinkObject = new {
            //    name = name,
            //    alcohol_type_id = alcohol_type_id,
            //    how_to_prepare = how_to_prepare
            //};
            //var jsonObject = new { drink = drinkObject };
            //var jsonString = JsonConvert.SerializeObject(jsonObject);

            //var dataContent = new StringContent(jsonString);

            content.Add(new StringContent(name), name: "drink[name]");
            content.Add(new StringContent(Convert.ToString(alcohol_type_id)), name: "drink[alcohol_type_id]");
            content.Add(new StringContent(how_to_prepare), name: "drink[how_to_prepare]");

            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            content.Add(fileStreamContent, name: "drink[photo]", fileName: "picture.png");

            var response = await httpClient.PostAsync(CreateDrinksUrl, content);

            return response.IsSuccessStatusCode;
        }
    }
}
