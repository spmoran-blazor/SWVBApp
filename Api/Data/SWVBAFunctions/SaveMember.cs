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
    public class SaveMember
    {
        private SWVBADbContext _dbContext;

        public SaveMember(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("SaveMember")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "savemember")] HttpRequest req,
            ILogger log)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var requestBody = new StreamReader(req.Body).ReadToEndAsync();
            var data = requestBody.Result;

            Member member = JsonSerializer.Deserialize<Member>(data, options);
            if(member.Id == 0)
            {
                _dbContext.Add<Member>(member);
            }
            else
            {
                if(member.Id> 0)
                {
                    _dbContext.Update<Member>(member);
                }
            }

            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(member);
        }
    }
}