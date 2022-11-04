using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teste_pratico_reserve.Models.DTO;

namespace Teste_pratico_reserve.Models.BusinessRules
{
    public class CovidRiskManager
    {

        public CovidTop10DTO[] GetTop10(CovidSummaryDTO dto)
        {
            Countries[] top10 = CalcTop10(dto);

            var orderedTop10 = top10.OrderByDescending(x => (x.TotalConfirmed - x.TotalRecovered));

            CovidTop10DTO[] list = new CovidTop10DTO[10];
            int count = 0;
            foreach (var item in orderedTop10)
            {
                CovidTop10DTO current = new CovidTop10DTO();
                current.Name = item.Country;
                current.rankPos = count + 1;
                current.ActiveCases = item.TotalConfirmed - item.TotalRecovered;
                list[count] = current;
                count++;
            }

            return list;

        }

        public Countries[] CalcTop10(CovidSummaryDTO dto)
        {
            int[] auxTop10 = new int[10];

            int currentlyMin = 0;
            int currentlyPos = 0;
            int countFirst10 = 0;

            Countries[] top10 = new Countries[10];

            foreach(Countries country in dto.countries)
            {
                int activeCases = country.TotalConfirmed - country.TotalRecovered;
                if(activeCases > currentlyMin || countFirst10 < 10)
                {
                    currentlyPos = Array.IndexOf(auxTop10, auxTop10.Min());
                    currentlyMin = activeCases;

                    top10[currentlyPos] = country;
                    auxTop10[currentlyPos] = activeCases;
                    countFirst10++;
                }
            }

            return top10;
        }
    }
}