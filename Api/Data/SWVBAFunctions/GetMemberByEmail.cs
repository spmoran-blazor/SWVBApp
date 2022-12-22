using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Api.Data.SWVBAFunctions
{
    public class GetMemberByEmail
    {
        private SWVBADbContext _dbContext;

        public GetMemberByEmail(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetMemberByEmail")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getmemberbyemail/{email}")] HttpRequest req,
            string email, ILogger log)
        {

            var member = _dbContext.Member.FirstOrDefault(a => a.Email == $"{email}");

            return new OkObjectResult(member);
        }

    }

    //    public static class GetMemberExceptionDates
    //    {
    //        [FunctionName("GetMembersExceptionDates")]
    //        public static IActionResult Run(
    //            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberexceptiondates/{Id}")] HttpRequest req,
    //            ILogger log,
    //            [Sql("[GetMemberExceptionDatesById]", CommandType = System.Data.CommandType.StoredProcedure,
    //                Parameters = "@Id={Id}",
    //                ConnectionStringSetting = "SqlConnection")]
    //                IEnumerable<MemberExceptionDate> memberExceptionDates)
    //        {
    //            return new OkObjectResult(memberExceptionDates);
    //        }
    //    }

    //    public static class GetMemberById
    //    {
    //        [FunctionName("GetMemberById")]
    //        public static IActionResult Run(
    //            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberbyid/{Id}")] HttpRequest req,
    //            ILogger log,
    //            [Sql("GetMemberById", CommandType = System.Data.CommandType.StoredProcedure,
    //                Parameters = "@Id={Id}",
    //                ConnectionStringSetting = "SqlConnection")]
    //                IEnumerable<Member> members)
    //        {
    //            return new OkObjectResult(members);
    //        }
    //    }

    //    public static class GetMemberByEmail
    //    {
    //        [FunctionName("GetMemberByEmail")]
    //        public static IActionResult Run(
    //            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getmemberbyemail/{email}")] HttpRequest req,
    //            ILogger log,
    //            [Sql("GetMemberByEmail", CommandType = System.Data.CommandType.StoredProcedure,
    //                Parameters = "@Email={email}",
    //                ConnectionStringSetting = "SqlConnection")]
    //                Member member)
    //        {
    //            return new OkObjectResult(member);
    //        }
    //    }

    //    public static class GetMemberPreferredDaysById
    //    {
    //        [FunctionName("GetMemberPreferredDaysById")]
    //        public static IActionResult Run(
    //            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getgemberpreferreddaysbyid/{Id}")] HttpRequest req,
    //            ILogger log,
    //            [Sql("GetMemberPreferredDaysById", CommandType = System.Data.CommandType.StoredProcedure,
    //                Parameters = "@Id={Id}",
    //                ConnectionStringSetting = "SqlConnection")]
    //                IEnumerable<WVBApp.Shared.Entities.PreferredPlayDays> playDays)
    //        {
    //            return new OkObjectResult(playDays);
    //        }
    //    }

    //    //public static class CreateEvent
    //    //{
    //    //    [FunctionName("CreateEvent")]
    //    //    public static IActionResult Run(
    //    //        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "postevent")] HttpRequest req,
    //    //        ILogger log,
    //    //        [Sql("dbo.Event", ConnectionStringSetting = "SqlConnection")] out Event foo)
    //    //    {
    //    //        Task<string> requestBody = new StreamReader(req.Body).ReadToEndAsync();
    //    //        Event newevent = JsonSerializer.Deserialize<Event>(requestBody.Result);

    //    //        foo = new Event
    //    //        {
    //    //            Id = Guid.NewGuid()
    //    //            ,
    //    //            EventDate = Convert.ToDateTime("2022-11-30T00:00:00")
    //    //,
    //    //            EventTime = "18:30:00"
    //    //,
    //    //            AreaOfPlayId = 1
    //    //,
    //    //            EventSchedulingCodeId = 1
    //    //,
    //    //            PartialGameId = 0
    //    //,
    //    //            ParticipantLimit = 10
    //    //,
    //    //            EventComment = null
    //    //,
    //    //            IsCancelled = false
    //    //,
    //    //            IsPartial = false
    //    //,
    //    //            UpdatedDate = Convert.ToDateTime("0001-01-01T00:00:00")
    //    //,
    //    //            UpdatedBy = "spmoran@hotmail.com"

    //    //        };
    //    //        //newevent.Id = Guid.NewGuid();
    //    //        //await eventscollector.AddAsync(newEvent);
    //    //        //await eventscollector.FlushAsync();

    //    //        return new CreatedResult($"/api/postevent", foo);
    //    //    }
    //    //}

    //    //public static class CreateEvent
    //    //{
    //    //    [FunctionName("CreateEvent")]
    //    //    public static async Task<IActionResult> Run(
    //    //        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "createactivity")] HttpRequest req,
    //    //        ILogger log,
    //    //        [Sql("[dbo].[Activity]", ConnectionStringSetting = "SqlConnection")] IAsyncCollector<Event> activities)
    //    //    {
    //    //        string? requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    //    //        Event data = JsonSerializer.Deserialize<Event>(requestBody);
    //    //        //Event foo = new Event();
    //    //        //{
    //    //            //data.Id = Guid.NewGuid();
    //    //            //foo.EventDate = Convert.ToDateTime("2022-11-30T00:00:00");
    //    //            //foo.EventTime = "18:30:00";

    //    //            //foo.AreaOfPlayId = 1;

    //    //            //foo.EventSchedulingCodeId = 1;

    //    //            //foo.PartialGameId = 0;

    //    //            //foo.ParticipantLimit = 10;

    //    //            //foo.EventComment = null;

    //    //            //foo.IsCancelled = false;

    //    //            //foo.IsPartial = false;

    //    //            //data.UpdatedDate = DateTime.Now;

    //    //            //foo.UpdatedBy = "spmoran@hotmail.com";

    //    //        //};
    //    //        //await activities.AddAsync(data);
    //    //        //await activities.FlushAsync();
    //    //        //List<Activity> activityList = new List<Activity> { data };

    //    //        return new OkObjectResult(data);
    //    //    }
    //    //}


        //    #region "Events"



    //    //@EventDate
    //    //@EventTime
    //    //@AreaOfPlayId
    //    //@EventSchedulingCodeId
    //    //@PartialGameId
    //    //@ParticipantLimit
    //    //@EventComment
    //    //@IsCancelled
    //    //@IsPartial
    //    //@UpdatedDate
    //    //@UpdatedBy

    

    //    }
    //    #endregion
}
