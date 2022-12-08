using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Linq;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    public class GetMemberExceptionDatesById
    {
        private SWVBADbContext _dbContext;

        public GetMemberExceptionDatesById(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetMemberExceptionDatesById")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getmemberexceptiondatesbyid/{Id}")] HttpRequest req,
            int Id, ILogger log)
        {
            var data = _dbContext.MemberExceptionDate.Where(a => a.MemberId == Id);
            var dates = data.ToList<MemberExceptionDate>();
            return new OkObjectResult(dates);
        }
    }
}