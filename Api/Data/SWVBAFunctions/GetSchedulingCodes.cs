using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    public class GetSchedulingCodes
    {
        private SWVBADbContext _dbContext;

        public GetSchedulingCodes(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetSchedulingCodes")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getschedulingcodes")] HttpRequest req,
            ILogger log)
        {
            var data = _dbContext.EventSchedulingCode;
            var codes = data.ToList<EventSchedulingCode>().OrderBy(codes => codes.Id);

            return new OkObjectResult(codes);
        }
    }
}
