using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste_pratico_reserve.Models.DTO
{
    public class CovidSummaryDTO
    {
        public string id { get; set; }
        public List<Countries> countries { get; set; }
    }

    public class Countries
    {
        public string Country { get; set; }
        public int TotalConfirmed { get; set; }
        public int TotalRecovered { get; set; }
    }
}