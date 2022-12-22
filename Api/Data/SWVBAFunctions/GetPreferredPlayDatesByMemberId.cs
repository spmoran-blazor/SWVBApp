using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Api.Data.SWVBAFunctions
{
    public class GetMemberPreferredDaysById
    {
        private SWVBADbContext _dbContext;

        public GetMemberPreferredDaysById(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetMemberPreferredDaysById")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getgemberpreferreddaysbyid/{Id}")] HttpRequest req,
            int Id, ILogger log)
        {
            List<WVBApp.Shared.Entities.MemberPreferredDays> daysOfWeek = _dbContext.MemberPreferredDays.Where(a => a.MemberId == Id).ToList();

            if(daysOfWeek.Count == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(daysOfWeek);
        }
    }
}