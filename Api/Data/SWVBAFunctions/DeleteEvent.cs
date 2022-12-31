using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    public class DeleteEvent
    {
        private SWVBADbContext _dbContext;
        public DeleteEvent(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("DeleteEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "deleteevent")] HttpRequest req,
            ILogger log)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var requestBody = new StreamReader(req.Body).ReadToEndAsync();
            var data = requestBody.Result;
            Event evt = null;

            if (data != null)
            {
                evt = System.Text.Json.JsonSerializer.Deserialize<Event>(data, options);
            }

            if (evt is not null)
            {
                _dbContext.Remove(evt);
                await _dbContext.SaveChangesAsync();
            }

            return new OkResult();
        }
    }
}
