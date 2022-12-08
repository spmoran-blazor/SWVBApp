using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Api.Data.SWVBAFunctions
{
    public class GetMemberById
    {
        private SWVBADbContext _dbContext;

        public GetMemberById(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetMemberById")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getgemberbyid/{Id}")] HttpRequest req,
            int Id, ILogger log)
        {
            var member = _dbContext.Member.Where(a => a.Id == Id);

            return new OkObjectResult(member);
        }
    }
}