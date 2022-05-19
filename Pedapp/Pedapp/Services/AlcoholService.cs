using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pedapp.API;
using Pedapp.DataModel;

namespace Pedapp.Services
{
    public class AlcoholService
    {
        RestClient<Alcohol> _restClient = new RestClient<Alcohol>();

        public async Task<List<Alcohol>> retrieveAlcohols()
        {
            var data = await _restClient.listAlcohols();

            return data;
        }
    }
}
