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
    public class PlayerOffersByGameId
    {
        private SWVBADbContext _dbContext;

        public PlayerOffersByGameId(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("PlayerOffersByGameId")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "playeroffersbygameid/{Id}")] HttpRequest req,
            int Id, ILogger log)
        {
            var sql = $"SELECT mem.* FROM Event evt, dbo.EventSchedulingCode esc, dbo.Member mem WHERE evt.EventSchedulingCodeId = esc.Id AND mem.PlayLevel BETWEEN esc.MinLevelEdge AND esc.MaxLevelEdge AND evt.Id = {Id} AND mem.IsCurrent = 1 ORDER BY mem.PlayScore DESC";
            var data = _dbContext.Member.FromSqlRaw<Member>(sql).ToList();

            return new OkObjectResult(data);
        }
    }
}