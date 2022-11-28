using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
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


    public static class CreateEvent
    {
        [FunctionName("CreateEvent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "PostEvent")] HttpRequest req,
            ILogger log,
            [Sql("dbo.Event", ConnectionStringSetting = "SqlConnection")] IAsyncCollector<Event> eventscollector)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic newEvent = JsonSerializer.Deserialize<Event>(requestBody);

            newEvent.Id = Guid.NewGuid();
            await eventscollector.AddAsync(newEvent);
            await eventscollector.FlushAsync();

            return new OkObjectResult(newEvent);
        }
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

    #region "Events"



    //@EventDate
    //@EventTime
    //@AreaOfPlayId
    //@EventSchedulingCodeId
    //@PartialGameId
    //@ParticipantLimit
    //@EventComment
    //@IsCancelled
    //@IsPartial
    //@UpdatedDate
    //@UpdatedBy

    public static class GetEventSchedulingCodes
    {
        [FunctionName("GetEventSchedulingCodes")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "geteventschedulingcodes")] HttpRequest req,
            ILogger log,
            [Sql("GetSchedulingCodes", CommandType = System.Data.CommandType.StoredProcedure,
                ConnectionStringSetting = "SqlConnection")]
                IEnumerable<EventSchedulingCode> eventSchedulingCodes)
        {
            return new OkObjectResult(eventSchedulingCodes);
        }


    }
    #endregion
}
