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
    public class SaveExceptionDate
    {
        private SWVBADbContext _dbContext;

        public SaveExceptionDate(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("SaveExceptionDate")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "saveexceptiondate")] HttpRequest req,
            ILogger log)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var requestBody = new StreamReader(req.Body).ReadToEndAsync();
            var data = requestBody.Result;

            MemberExceptionDate mxd = JsonSerializer.Deserialize<MemberExceptionDate>(data, options);
            if (mxd.Id == 0)
            {
                _dbContext.Add<MemberExceptionDate>(mxd);
            }

            await _dbContext.SaveChangesAsync();



            return new OkObjectResult(mxd);
        }
    }
}