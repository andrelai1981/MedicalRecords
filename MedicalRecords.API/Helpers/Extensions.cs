using System;
using MedicalRecords.API.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MedicalRecords.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddPagination(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination"); 
        }

        public static DateTime CalculateAnticipatedDestructionDate(this File file)
        {
            int clientAge = DateTime.Today.Year - file.Client.DOB.Year;
            DateTime clientTurns18On = file.Client.DOB.AddYears(18);
            int DestructionPeriod = 7;
            DateTime DateOfLastServicePlus7 =  file.Client.LastDateOfService.AddYears(DestructionPeriod);
            DateTime result = DateOfLastServicePlus7;

            if (clientAge < 18 && clientTurns18On >= DateOfLastServicePlus7)
            {
                result =  clientTurns18On;
            }
            return result;
        }
    }
}