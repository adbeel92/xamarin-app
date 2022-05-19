using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public bool createDrink(string name, int alcohol_type_id, string how_to_prepare)
        {
            var data = _restClient.createDrink(name, alcohol_type_id, how_to_prepare);

            return data.Result;
        }
    }
}
