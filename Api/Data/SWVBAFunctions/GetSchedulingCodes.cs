using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    public class GetEventSchedulingCodes
    {
        private SWVBADbContext _dbContext;

        public GetEventSchedulingCodes(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetSchedulingCodes")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "geteventschedulingcodes")] HttpRequest req,
            ILogger log)
        {
            var data = _dbContext.EventSchedulingCode;
            var codes = data.ToList<EventSchedulingCode>().Where(act => act.IsActive == true).OrderBy(codes => codes.Id);

            return new OkObjectResult(codes);
        }
    }
}
