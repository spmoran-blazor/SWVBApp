using Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using WVBApp.Shared.Entities;

namespace Api
{
    public class GetMemberByEmail
    {
        private SWVBADbContext _dbContext;

        public GetMemberByEmail(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetMemberByEmail")]
        public IActionResult run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getmemberbyemail/{email}")] HttpRequest req,
            string email, ILogger log)
        {

            log.LogInformation("C# HTTP trigger function processed a request.");

            //email = req.Query["email"];
            var member = _dbContext.Member.FirstOrDefault<Member>(a => a.Email == $"{email}");
            //string requestBody = new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(email)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {member.FirstName}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
