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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetMembers")] HttpRequest req,
            ILogger log,
            [Sql("GetMembers", CommandType = System.Data.CommandType.StoredProcedure,
                ConnectionStringSetting = "Server=tcp:swvb.database.windows.net,1433;Initial Catalog=SWVB;Persist Security Info=False;User ID=spmoran;Password=1SPm081563_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")]
                IEnumerable<Member> toDoItems)
        {
            return new OkObjectResult(toDoItems);
        }
    }
}
