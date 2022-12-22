using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    public class GetMessages
    {
        private SWVBADbContext _dbContext;

        public GetMessages(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetMessages")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getmessages")] HttpRequest req,
            ILogger log)
        {
            var data = _dbContext.Message.Where(a => a.DateSent < DateTime.Now.AddDays(-7));
            var messages = data.ToList<Message>().OrderByDescending(messages => messages.DateSent);

            return new OkObjectResult(messages);
        }
    }
}