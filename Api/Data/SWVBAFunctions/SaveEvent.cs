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
    public class SaveEvent
    {
        private SWVBADbContext _dbContext;

        public SaveEvent(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("SaveEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "saveevent")] HttpRequest req,
            ILogger log)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var requestBody = new StreamReader(req.Body).ReadToEndAsync();
            var data = requestBody.Result;

            Event evt = JsonSerializer.Deserialize<Event>(data, options);
            _dbContext.Add<Event>(evt);
            
            try
            {
                await _dbContext.SaveChangesAsync();
                return new OkObjectResult(evt);
            }
            catch(System.Exception e) 
            { return new BadRequestObjectResult(e); 
            }


        }
    }
}