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
                IEnumerable<Member> members)
        {
            return new OkObjectResult(members);
        }


    }

    public static class GetMemberExceptionDates
    {
        [FunctionName("GetMembersExceptionDates")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberexceptiondates/{Id}")] HttpRequest req,
            ILogger log,
            [Sql("[GetMemberExceptionDatesById]", CommandType = System.Data.CommandType.StoredProcedure,
                Parameters = "@Id={Id}",
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<MemberExceptionDates> memberExceptionDates)
        {
            return new OkObjectResult(memberExceptionDates);
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
                IEnumerable<Member> members)
        {
            return new OkObjectResult(members);
        }
    }

    
    public static class GetMemberByEmail
    {
        [FunctionName("GetMemberByEmail")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberbyemail/{email}")] HttpRequest req,
            ILogger log,
            [Sql("GetMemberByEmail", CommandType = System.Data.CommandType.StoredProcedure,
                Parameters = "@Email={email}",
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<Member> members)
        {
            return new OkObjectResult(members);
        }
    }

    public static class GetMemberPreferredDaysById
    {
        [FunctionName("GetMemberPreferredDaysById")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getgemberpreferreddaysbyid/{Id}")] HttpRequest req,
            ILogger log,
            [Sql("GetMemberPreferredDaysById", CommandType = System.Data.CommandType.StoredProcedure,
                Parameters = "@Id={Id}",
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<PlayDay> playDays)
        {
            return new OkObjectResult(playDays);
        }
    }

    public static class GetEventSchedulingCodes
    {
        [FunctionName("GetEventSchedulingCodes")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "geteventschedulingcodes")] HttpRequest req,
            ILogger log,
            [Sql("GetSchedulingCodes", CommandType = System.Data.CommandType.StoredProcedure,
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<EventSchedulingCode> eventSchedulingCodes )
        {
            return new OkObjectResult(eventSchedulingCodes);
        }


    }
    public static class Future
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

    public static class GetMessages
    {
        [FunctionName("GetMessages")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmessages")] HttpRequest req,
            ILogger log,
            [Sql("GetMessages", CommandType = System.Data.CommandType.StoredProcedure,
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<Message> messages)
        {
            return new OkObjectResult(messages);
        }


    }
}
