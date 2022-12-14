using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    public class GetAvailableGamesByMemberId
    {
        private SWVBADbContext _dbContext;

        public GetAvailableGamesByMemberId(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetAvailableGamesByMemberId")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getavailablegamesbymemberId/{Id}")] HttpRequest req,
            int Id, ILogger log)
        {
            var sql = $"SELECT evt.* FROM Event evt, dbo.EventSchedulingCode esc, dbo.Member mem WHERE evt.EventSchedulingCodeId = esc.Id AND mem.PlayLevel BETWEEN esc.MinLevelEdge AND esc.MaxLevelEdge AND mem.Id={Id} ORDER BY evt.EventDate DESC";
            var data = _dbContext.Event.FromSqlRaw<Event>(sql).ToList();

            return new OkObjectResult(data);
        }
    }
}