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
    public class DeleteExceptionDate
    {
        private SWVBADbContext _dbContext;
        public DeleteExceptionDate(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("DeleteExceptionDate")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "deleteexceptiondate")] HttpRequest req,
            ILogger log)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var requestBody = new StreamReader(req.Body).ReadToEndAsync();
            var data = requestBody.Result;
            MemberExceptionDate mxd = null;

            if (data != null)
            {
                mxd = System.Text.Json.JsonSerializer.Deserialize<MemberExceptionDate>(data, options);
            }

            if(mxd is not null)
            {
                _dbContext.Remove(mxd);
                await _dbContext.SaveChangesAsync();
            }    

            return new OkResult();
        }
    }
}
