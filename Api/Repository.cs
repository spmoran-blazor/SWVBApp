using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WVBApp.Shared.Entities;

namespace Api
{
    public static class GetMembers
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

    public static class GetMemberById
    {
        [FunctionName("GetMemberById")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberbyid/{Id}")] HttpRequest req,
            ILogger log,
            [Sql("GetMemberById", CommandType = System.Data.CommandType.StoredProcedure,
                Parameters = "@Id={Id}",
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<Member> Members)
        {
            return new OkObjectResult(Members);
        }
    }

    public static class GetMemberByEmail
    {
        [FunctionName("GetMemberByEmail")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberbyemail/{email}")] HttpRequest req,
            ILogger log,
            [Sql("GetMemberByemail", CommandType = System.Data.CommandType.StoredProcedure,
                Parameters = "@Email={email}",
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<Member> Members)
        {
            return new OkObjectResult(Members);
        }
    }

    public static class GetMemberIdByEmail
    {
        [FunctionName("GetMemberIdByEmail")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberidbyemail/{email}")] HttpRequest req,
            ILogger log,
            [Sql("GetMemberIdByEmail", CommandType = System.Data.CommandType.StoredProcedure,
                Parameters = "@Email={email}",
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<int> Id)
        {
            return new OkObjectResult(Id);
        }
    }
}
