using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging; 
using Newtonsoft.Json;
using System.Collections.Generic;
using WVBApp.Shared.Entities;

namespace Api
{
    public static class Repository 
    {

        [FunctionName("GetMembers")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmembers")] HttpRequest req,
            ILogger log,
            [Sql("GetMembers", CommandType = System.Data.CommandType.StoredProcedure,
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<Member> Members)
        {
            return new OkObjectResult(Members);
        }
    }
}
