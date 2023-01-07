using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using WVBApp.Shared.DTOs;


namespace Api.Data.SWVBAFunctions
{
    public class GetScheduledEvents
    {
        private SWVBADbContext _dbContext;

        public GetScheduledEvents(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetScheduledEvents")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getscheduledevents")] HttpRequest req,
            ILogger log)
        {
            var sql = $"SELECT e.Id, e.EventDate, e.EventTime, e.AreaOfPlayId,  a.Area, e.EventSchedulingCodeId, e.ParticipantLimit, e.EventComment, e.IsCancelled, e.IsPartial, e.PartialGameId, e.UpdatedDate, e.UpdatedBy, b.Code, b.Description, b.Notes FROM [dbo].[Event] e JOIN [dbo].[EventSchedulingCode] b ON e.EventSchedulingCodeId = b.Id JOIN [dbo].AreaOfPlay a ON e.AreaOfPlayId = a.Id WHERE CONVERT(date, e.EventDate, 101) >= CONVERT(date, GETDATE(), 101) ORDER BY e.EventDate, e.EventTime, e.AreaOfPlayId";
            var data = _dbContext.EventWithCodeInfo.FromSqlRaw<EventWithCodeInfo>(sql).ToList();

            return new OkObjectResult(data);
        }
    }
}
