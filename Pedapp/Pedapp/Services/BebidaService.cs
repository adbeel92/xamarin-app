using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using Pedapp.API;
using Pedapp.DataModel;

namespace Pedapp.Services
{
    public class BebidaService
    {
        RestClient<Bebida> _restClient = new RestClient<Bebida>();

        public async Task<List<Bebida>> retrieveBebidas()
        {
            var data = await _restClient.listDrinks();

            return data;
        }

        public async Task<bool> createDrink(string name, int alcohol_type_id, string how_to_prepare, string filePath, double percentage, Ingrediente[] ingredients)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(name), name: "drink[name]");
            content.Add(new StringContent(Convert.ToString(alcohol_type_id)), name: "drink[alcohol_type_id]");
            content.Add(new StringContent(how_to_prepare), name: "drink[how_to_prepare]");
            content.Add(new StringContent(Convert.ToString(percentage)), name: "drink[percentage]");

            int index = 0;
            foreach (Ingrediente ingredient in ingredients)
            {
                content.Add(new StringContent(Convert.ToString(ingredient.Id)), name: $"drink[ingredients_attributes][{index}][id]");
                content.Add(new StringContent(ingredient.Name), name: $"drink[ingredients_attributes][{index}][name]");
                content.Add(new StringContent(Convert.ToString(ingredient.Quantity)), name: $"drink[ingredients_attributes][{index}][quantity]");
                content.Add(new StringContent(ingredient.Unit), name: $"drink[ingredients_attributes][{index}][unit]");
                //content.Add(new StringContent(Convert.ToString(ingredient._destroy)), name: $"drink[ingredients_attributes][{index}][_destroy]");
                index = index + 1;
            }

            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            content.Add(fileStreamContent, name: "drink[photo]", fileName: "picture.png");

            return await _restClient.createDrink(content);
        }

        private object MultipartFormDataContent()
        {
            throw new NotImplementedException();
        }
    }
}
