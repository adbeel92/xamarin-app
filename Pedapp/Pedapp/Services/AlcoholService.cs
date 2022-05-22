using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pedapp.API;
using Pedapp.DataModel;

namespace Pedapp.Services
{
    public class AlcoholService
    {
        RestClient<AlcoholType> _restClient = new RestClient<AlcoholType>();

        public async Task<List<AlcoholType>> retrieveAlcohols()
        {
            var data = await _restClient.listAlcohols();

            return data;
        }
    }
}
