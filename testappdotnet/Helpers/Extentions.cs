using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testappdotnet.Helpers
{
    public static class Extentions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-error", message);
            response.Headers.Add("Access-Control-ExposeHeaders", "Application-error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

        }

        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage,int totalItems, int totalPages)
        {
            var paginationHeades = new PaginationHeaders(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeades,camelCaseFormatter));
            response.Headers.Add("Access-Control-Allow-Origin", "Pagination");
        }
        public static int CalculateAge(this DateTime theDate)
        {
            var age = DateTime.Today.Year - theDate.Year;
            if (theDate.AddYears(age) > DateTime.Today) {
                age--;
            } ;

            return age;
        }
    }
}
