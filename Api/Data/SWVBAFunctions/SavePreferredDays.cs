using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WVBApp.Shared.DTOs;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    public class SavePreferredDays
    {
        private SWVBADbContext _dbContext;

        public SavePreferredDays(SWVBADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("SavePreferredDays")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "savepreferreddays")] HttpRequest req,
            ILogger log)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var requestBody = new StreamReader(req.Body).ReadToEndAsync();
            var data = requestBody.Result;
            PreferredDaysPackage pdp = null;

            if (data != null )
            {
                pdp = JsonSerializer.Deserialize<PreferredDaysPackage>(data, options);
            }


            List<MemberPreferredDays> deletempds = pdp.DeleteDays;
            List<MemberPreferredDays> membermpds = pdp.AddDays;

            foreach(MemberPreferredDays item in pdp.DeleteDays)
            {
                _dbContext.Remove(item);
            }
            await _dbContext.SaveChangesAsync();

            foreach (MemberPreferredDays item in pdp.AddDays)
            {
                _dbContext.Add(item);
            }
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(pdp.AddDays);
        }
    }
}