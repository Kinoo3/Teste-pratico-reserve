using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Teste_pratico_reserve.Models.BusinessRules;
using Teste_pratico_reserve.Models.DTO;

namespace Teste_pratico_reserve.Controllers
{
    public class CovidRiskController : ApiController

    {
        private HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api.covid19api.com/")
        };

        // GET: api/CovidRisk
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public async Task<HttpResponseMessage> GetTop10()
        {
            var response = await _httpClient.GetAsync("summary");
            if(response.IsSuccessStatusCode)
            {
                string contentJson = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CovidSummaryDTO>(contentJson);

                CovidRiskManager manager = new CovidRiskManager();
                var a = manager.GetTop10(data);


                return Request.CreateResponse(HttpStatusCode.OK, a);

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // GET: api/CovidRisk/5
        public string Get(int id)
        {
            return "value";
        }


    }
}
