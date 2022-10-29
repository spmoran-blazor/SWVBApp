using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        public static class PostEvent
    {
        //[FunctionName("InsertNewEvent")]
        //public static IActionResult Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "insertnewevent"] HttpRequest req,
        //    ILogger log,
        //    [Sql("GetMemberIdByEmail", CommandType = System.Data.CommandType.StoredProcedure,
        //        Parameters = "@Email={email}",
        //        ConnectionStringSetting = "SqlConnection")]
        //        IEnumerable<int> Id)
        //{
        //    return new OkObjectResult(Id);
        //}

        //[FunctionName("PostEvent")]
        //public static async Task<IActionResult> Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "PostEvent")] HttpRequest req,
        //    ILogger log,
        //    [Sql("dbo.Event", ConnectionStringSetting = "SqlConnection")] IAsyncCollector<Event> events)
        //{
        //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //    Event newEvent = JsonConvert.DeserializeObject<Event>(requestBody);

        //    // generate a new id for the todo item
        //    //toDoItem.Id = Guid.NewGuid();

        //    // set Url from env variable ToDoUri
        //    toDoItem.url = Environment.GetEnvironmentVariable("ToDoUri") + "?id=" + toDoItem.Id.ToString();

        //    // if completed is not provided, default to false
        //    if (toDoItem.completed == null)
        //    {
        //        toDoItem.completed = false;
        //    }

        //    await toDoItems.AddAsync(toDoItem);
        //    await toDoItems.FlushAsync();
        //    List<ToDoItem> toDoItemList = new List<ToDoItem> { toDoItem };

        //    return new OkObjectResult(toDoItemList);

        //}
    }
}
