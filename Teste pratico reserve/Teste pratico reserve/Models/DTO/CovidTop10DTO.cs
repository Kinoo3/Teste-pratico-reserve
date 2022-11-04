using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste_pratico_reserve.Models.DTO
{
    public class CovidTop10DTO
    {
        public string Name { get; set; }
        public int rankPos { get; set; }
        public int ActiveCases { get; set; }
    }
}